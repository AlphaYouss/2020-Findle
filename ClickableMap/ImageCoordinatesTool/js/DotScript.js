var count = 0;


function CreateDot(ev)
{
    count++;

    $("body").append(            
        $('<div id="test"></div>').css
        ({
            top: ev.pageY + 'px',
            left: ev.pageX + 'px',
        })              
    )     
}


function DeleteDots(){       
    for (var i = 0; i < count ; i++)
    {
        var element = document.getElementById("test");
        element.parentNode.removeChild(element);
    }     
}
