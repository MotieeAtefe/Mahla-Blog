$(document).ready(function () {
    LoadCkeditor4();
});
function LoadCkeditor4()
{
    if (!document.getElementById("ckEditor4"))
        return;

    $("body").append("<script src='/ckeditor/ckeditor.js'></script>");

    CKEDITOR.Replace("ckEditor4",
    {
            coustomConfig: '/ckeditor/config.js'

    });

}