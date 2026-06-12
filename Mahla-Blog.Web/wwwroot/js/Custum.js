$(document).ready(function () {
    LoadCkeditor4();
});
function LoadCkeditor4()
{
    if (!document.getElementById("Ckeditor4"))
        return;

    $("body").append("<script src='/ckeditor/ckeditor.js'></script>");

    CKEDITOR.replace("Ckeditor4", {
        customConfig: '/ckeditor/config.js'
    });

}


