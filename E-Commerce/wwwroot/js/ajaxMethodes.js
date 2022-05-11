////jQueryAjaxDelete = (form) => {
////    $.ajax({
////        type: "POST",
////        url: form.action,
////        data: new FormData(form.data),
////        contentType: false,
////        processData: false,
////        success: function (res) {
////            alert(res);
////            console.log("cccccccccccccccccc")
////        },
////        error: function (err) {
////            console.log(err);
////        }

////    })
        
////    return false;

////}
jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#all-cartitems").html(res.html);
                    alert(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}
AddToCart = (form) => {

    try {
        $.ajax({
            type: "post",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {

                if (res.isvalid) {

                    //$('#myModal .').modal('show')
                    $('#myModal').modal('show');

                }
                else {
                    alert("error")
                }

            }
        })
    } catch (ex) {
        alert(ex)

    }
    $(document).ajaxError(function (e, xhr) {
        //ajax error event handler that looks for either a 401 (regular authorized) or 403 (AjaxAuthorized custom actionfilter). 
        if (xhr.status == 403 || xhr.status == 401) {
            $('#myModal').modal('show');
            $('#myModal .err').html('<h1 class="text-center">please login first  <i class="fa-solid fa-triangle-exclamation text-info"></i>')
        }
    });
    //prevent default 
    return false;

}