using System.Data;
using System.Data.SqlClient;
using System.IO;

// MigraDoc
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;


namespace OutsourcingMWProject.Tools
{
    class PDF
    {
        //using this u can call upon the file
        public string fileName { get; private set; }

        //Every MigraDoc document needs at least one section
        Section section = new Section();

        Document document;



        public Document CreatePDF(string GivenFileName)
        {
            DeleteOldPDF();

            // Create a new PDF incl. info
            document = new Document();
            document.Info.Title = GivenFileName;
            document.Info.Author = "MW Projects";
            fileName = GivenFileName + ".pdf";


            DefineStyles();

            FillPDF();

            SavePDF();

            return document;
        }


        private void DefineStyles()
        {
            Style style = document.Styles["Normal"];

            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Size = 11;
        }


        private Table CreateTable(string HeaderName)
        {
            Table table = new Table();

            // Create the table
            table = section.AddTable();
            table.Style = "Table";
            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.5;

            // Before you can add a row, you must define the columns
            Column column;
            column = table.AddColumn("4cm");
            column = table.AddColumn("2.5cm");
            column = table.AddColumn("2.5cm");
            column = table.AddColumn("2.5cm");
            column = table.AddColumn("4cm");

            // Create a table Header
            Row Header = table.AddRow();
            Header.Cells[0].AddParagraph(HeaderName);
            Header.Cells[0].MergeRight = table.Columns.Count - 1;
            Header.Cells[0].Borders.Color = Colors.White;
            Header.Cells[0].Borders.Bottom.Color = Colors.Black;

            //Create the Collumn header(s)
            Row row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Left;
            row.Format.Font.Bold = true;
            row.Format.Font.Italic = true;
            row.Shading.Color = Colors.Azure;

            row.Cells[0].AddParagraph("Naam");
            row.Cells[1].AddParagraph("Begintijd");
            row.Cells[2].AddParagraph("eindtijd");
            row.Cells[3].AddParagraph("Bondsnmr.");
            row.Cells[4].AddParagraph("Telefoonnummer");

            return table;
        }


        private void CreateHeader()
        {
            Databasehandler dbh = new Databasehandler();

            // Vul hier de laaste sql statement in
            SqlCommand sql = new SqlCommand("");

            dbh.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(sql);
            adapt.Fill(dbh.table);

            dbh.CloseConnectionToDB();

            section.AddParagraph(dbh.table.Rows[0].ItemArray[0].ToString());
            section.AddParagraph(dbh.table.Rows[1].ItemArray[0].ToString());
            section.AddParagraph();
            section.AddParagraph("----------------------------------------------------------------------------");
            section.AddParagraph();
        }


        private void FillPDF()
        {

            CreateHeader();

            Databasehandler dbh = new Databasehandler();

            SqlCommand GetData = new SqlCommand
                (@" SELECT	[RegDienst].[RegDienst_Naam] as Dienst,
		            CONCAT ([Leden].[Roepnaam], ' ' , [Leden].[Achternaam] ) AS Naam,
		            CONCAT ([RegDienst].[RegDienst_BeginDatum], ' ' , [RegDienst].[RegDienst_BeginUur], ':' , [RegDienst].[RegDienst_BeginMinuut]) As Begintijd,
		            CONCAT ([RegDienst].[RegDienst_EindDatum], ' ' , [RegDienst].[RegDienst_EindUur], ':' , [RegDienst].[RegDienst_EindMinuut]) as Eindtijd,
		            [Leden].[BondsNr],[Leden].[Telefoon] as Telefoonnummer
                    FROM	[GenBB_Regels]
                    INNER JOIN [RegDienst]
                        ON [GenBB_Regels].[RegDienst_ID] = [RegDienst].[RegDienst_ID]
                    INNER JOIN [Leden] 
                        ON [GenBB_Regels].[Leden_ID] = [Leden].[Leden_ID]", dbh.GetCon()
                );

            SqlCommand GetJob = new SqlCommand
                (
                @"  SELECT DISTINCT [RegDienst].RegDienst_Naam FROM[GenBB_Regels]
                    INNER JOIN[RegDienst] 
                        ON[GenBB_Regels].[RegDienst_ID] = [RegDienst].[RegDienst_ID] ", dbh.GetCon()
                );


            DataTable Jobs = new DataTable();



            // Connect to the database and fill the datatables
            dbh.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(GetData);
            adapt.Fill(dbh.table);

            adapt = new SqlDataAdapter(GetJob);
            adapt.Fill(Jobs);

            dbh.CloseConnectionToDB();



            //Test tables
            Jobs = CreateTestJobs();
            dbh.FillTable(CreateTestData());

            section = document.AddSection();

            int count = 0;
            foreach (DataRow DataRow in Jobs.Rows)
            {
                // Get a job from the datatable
                string Job = DataRow.Table.Rows[count].ItemArray[0].ToString();

                // Create the table
                Table table = CreateTable(Job + "-dienst");

                // Loop trough every datarow
                foreach (DataRow dtRow in dbh.table.Rows)
                {
                    // Add the row to the table if the job is the same
                    if (dtRow.ItemArray[0].ToString() == Job)
                    {
                        Row row = table.AddRow();

                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            int x = i + 1;
                            row.Cells[i].AddParagraph(dtRow.ItemArray[x].ToString());
                        }
                    }
                }
                count++;

                // Create spaces in between tables
                section.AddParagraph();
                section.AddParagraph();
            }
        }


        private void SavePDF()
        {
            // Create a renderer
            bool unicode = true;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document
            pdfRenderer.PdfDocument.Save(fileName);
        }


        private void DeleteOldPDF()
        {
            // This deletes any other PDF file saved.
            foreach (string sFile in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf"))
            {
                File.Delete(sFile);
                
            }
        }



        private DataTable CreateTestJobs()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Dienst", typeof(string));

            table.Rows.Add("Schoonmaak");
            table.Rows.Add("Bar");
            table.Rows.Add("EHBO");

            return table;
        }


        private DataTable CreateTestData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Dienst", typeof(string));
            table.Columns.Add("Naam", typeof(string));
            table.Columns.Add("Begintijd", typeof(string));
            table.Columns.Add("Eindtijd", typeof(string));
            table.Columns.Add("Bondnmr", typeof(int));
            table.Columns.Add("Telefoonnummer", typeof(int));

            table.Rows.Add("Schoonmaak", "Pietje Bel", "23-02-2020 11:00", "23-02-2020 17:00", 123454321, 1454321);
            table.Rows.Add("Schoonmaak", "Meridith Grey", "12-04-2020 7:00", "12-04-2020 13:00", 3157908, 7891488);
            table.Rows.Add("Schoonmaak", "Tarzan Clayton", "23-02-2020 8:00", "23-02-2020 14:00", 152309, 315809133);
            table.Rows.Add("Schoonmaak", "Fred Flintstone", "23-02-2020 11:00", "23-02-2020 17:00", 78913141, 547893131);
            table.Rows.Add("Schoonmaak", "Dora Marquez", "23-02-2020 15:00", "23-02-2020 22:00", 4645686, 75487645);
            table.Rows.Add("Schoonmaak", "Laurel Lance", "23-02-2020 7:00", "23-02-2020 13:00", 75744245, 1375945824);

            table.Rows.Add("Bar", "Peter Pan", "23-02-2020 15:00", "23-02-2020 22:00", 7236878, 956235);
            table.Rows.Add("Bar", "Wendy Schat", "23-02-2020 11:00", "23-02-2020 17:00", 85258785, 85236589);
            table.Rows.Add("Bar", "Oliver Queen", "23-02-2020 7:00", "23-02-2020 13:00", 258745854, 875258548);
            table.Rows.Add("Bar", "Howard Philips Lovecraft", "23-02-2020 7:00", "23-02-2020 13:00", 526598584, 85256845);

            table.Rows.Add("EHBO", "Roy Harper", "23-02-2020 15:00", "23-02-2020 22:00", 412658796, 69874585);
            table.Rows.Add("EHBO", "Walter White", "23-02-2020 7:00", "23-02-2020 13:00", 145899635, 4583548);
            table.Rows.Add("EHBO", "Jeff Winger", "23-02-2020 7:00", "23-02-2020 13:00", 258745854, 8758548);
            table.Rows.Add("EHBO", "Pierce Webber", "23-02-2020 7:00", "23-02-2020 13:00", 865378524, 8973214);

            return table;
        }
    }
}