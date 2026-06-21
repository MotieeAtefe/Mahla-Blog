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

function changePage(pageId) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;

    search_params.set('pageId', pageId);
    url.search = search_params.toString();

    var new_url = url.toString();
    window.location.replace(new_url);
}


