$(function () {
    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});


function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function validationCheckAddOrEdit() {

    var contactName = $('#contactName').val().trim();
    if (contactName == "") {
        toastr.error("Name can't be Empty.");
        return false;
    }

    var contactSubject = $('#contactSubject').val();
    if (contactSubject == "") {
        toastr.error("Subject can't be Empty");
        return false;
    }

    var contactEmail = $('#contactEmail').val();
    var validEmail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    if (contactEmail == "" || !validEmail.test(contactEmail)) {
        toastr.error("Email must be valid");
        return false;
    }

    return true;
}


function jQueryAjaxPost(form) {
    if (validationCheckAddOrEdit()) {

        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $.alert({
                    title: 'Alert!',
                    content: response.ReturnMessage

                });
                clear();

            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);

    }
    return false;
}

function clear() {
    $('#contactName').val('');
    $('#contactSubject').val('');
    $('#contactEmail').val('');
    $('#contactMessage').val('');

}
$("#submit").click(function () {
    clear();
});
function refreshA(resetUrl) {

    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('');
           
        }

    });
}

function refreshAddNewTab(resetUrl, showViewTab) {

    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }

    });
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }

    });
}

function Delete(url) {
    //if (confirm('Are you sure to delete this record ?') == true) {
    //    $.ajax({
    //        type: 'POST',
    //        url: url,
    //        success: function (response) {
    //            if (response.success) {
    //                $("#firstTab").html(response.html);
    //                $.notify(response.message, "warn");
    //                if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
    //                    activatejQueryTable();
    //            }
    //            else {
    //                $.notify(response.message, "error");
    //            }
    //        }

    //    });

    //}
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this record!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            debugger;
            if (willDelete) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    success: function (response) {
                        if (response.messageType == 1) {
                            $("#firstTab").html(response.html);
                            if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                                activatejQueryTable();
                            toastr.success(response.message);
                        } else {
                            toastr.error(response.message);
                        }
                    }
                });

            } else {
                swal("Cancelled!");
            }
        });
}
