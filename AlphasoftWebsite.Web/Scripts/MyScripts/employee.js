$(function () {

    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

$(document).ready(function() {
    debugger;
    GetAllDesignations("ddlDesignation", true);
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

    var EName = $('#EName').val().trim();
    if (EName == "") {
        toastr.error("Employee Name  can't be Empty.");
        return false;
    }
    var EAddress = $('#EAddress').val().trim();
    if (EAddress == "") {
        toastr.error("Address can't be Empty.");
        return false;
    }
    var ddlDesignation = $('#ddlDesignation').val();
    if (ddlDesignation == "") {
        toastr.error("Designation  can't be Empty.");
        return false;
    }

    var eImage = $('#eImage').val();
    var image = $('#modelEmployeeImage').val();
    if (image == eImage) {
        if (image == "") {
            toastr.error("Image can't be Empty.");
            return false;
        }

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
            
            GetAllDesignations("ddlDesignation", true);
            $('#ddlDesignation').addClass("select2");
            $('.select2').select2();
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
            debugger;             
            $("#secondTab").html(response);           
            var employeeId = $('#modelEmployeeId').val();
            $.ajax({
                type: 'GET',
                url: '/Employee/GetAnEmployeeById/',
                data: { employeeId: employeeId },
                success: function (response) {
                    $('.select2').select2();
                    var data = JSON.parse(response);
                    GetAllDesignations("ddlDesignation", true);
                    $('#ddlDesignation').val(data.DesignationId).change();

                }
            });           
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
