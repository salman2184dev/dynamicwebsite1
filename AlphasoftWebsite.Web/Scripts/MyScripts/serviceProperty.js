﻿$(function () {

    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

$(document).ready(function () {
    debugger;
    GetAllService("ddlServiceList", true);
});


function ShowImagePreview(uploadedFile, previewImage) {
    debugger;
    if (uploadedFile.files && uploadedFile.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(uploadedFile.files[0]);
    }
}
function validationCheckAddOrEdit() {
    var PorpartyName = $('#PorpartyName').val().trim();
    if (PorpartyName == "") {
        toastr.error("Porparty Name can't be Empty.");
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

                if (response.messageType == 1) {
                    $("#firstTab").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    debugger;
                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable)) {
                        activatejQueryTable();
                    }
                    //swal("Success", response.message, "success");
                    toastr.success(response.message);
                }
                else {
                    toastr.error(response.message);
                }
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

function refreshAddNewTab(resetUrl, showViewTab) {

    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {

            debugger;
            $("#secondTab").html(response);
            GetAllService("ddlServiceList", true);

            $('#ddlServiceList').addClass("select2");
            $('.select2').select2();
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)

                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }

    });
}

//function Edit(url) {
//    $.ajax({
//        type: 'GET',
//        url: url,
//        success: function (response) {
//            debugger;
//            $("#secondTab").html(response);
//            var servicePropertyId = $('#modelServicePropertyId').val();
//            $.ajax({
//                type: 'GET',
//                url: '/ServiceProperty/GetAServicePropertyById/',
//                data: { servicePropertyId: servicePropertyId },
//                success: function (response) {
//                    debugger;
//                    $('.select2').select2();
//                    var data = JSON.parse(response);
//                    GetAllService("ddlServiceList", true);
//                    $('#ddlServiceList').val(data.ServicePropertyId).change();

//                }
//            });
//            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
//            $('ul.nav.nav-tabs a:eq(1)').tab('show');
//        }

//    });
//}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            debugger;
            $("#secondTab").html(response);
            var servicePropertyId = $('#modelServicePropertyId').val();
            $.ajax({
                type: 'GET',
                url: '/ServiceProperty/GetAServicePropertyById/',
                data: { servicePropertyId: servicePropertyId },
                success: function (response) {
                    debugger;
                    $('.select2').select2();
                    var data = JSON.parse(response);
                    GetAllService("ddlServiceList", true);
                    $('#ddlServiceList').val(data.ServicePropertyId).change();

                }
            });
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }

    });
}

function Delete(url) {

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
