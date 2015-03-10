$(document).ready(function()
{
    $(".thumbnail img").on("mouseover", function ()
    {
        $("#MainImage").attr("src", $(this).attr("src"));
    });
});