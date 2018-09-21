$(function () {

    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

$(document).ready(function () {
    GetAllBlogCategories("ddlBlogCategory", true);
});


function ShowImagePreview(uploadedFile, previewImage) {
    if (uploadedFile.files && uploadedFile.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(uploadedFile.files[0]);
    }
}
//function getSelectedFile() {
//    var fileInput = document.getElementById("bimage");
//    var fileIsSelected = fileInput && fileInput.files && fileInput.files[0];
//    if (fileIsSelected)
//        return fileInput.files[0];
//    else
//        return false;
//}
function validationCheckAddOrEdit(){

    var blogName = $('#blogName').val().trim();
    if (blogName == "") {
        toastr.error("Blog Name can't be Empty.");
        return false;
    }

    var blogDescription = $('#blogDescription').val();
    if (blogDescription == "") {
        toastr.error("Description can't be Empty.");
        return false;
    }
 
    var bimage = $('#bimage').val();
    var image = $('#modelBlogImage').val();
    if (image == bimage) {
      
        if (bimage == "") {
            toastr.error("Image can't be Empty.");
            return false;
        }
    }
    return true;
}


function jQueryAjaxPost(form) {

    if (validationCheckAddOrEdit()){
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function(response) {

                if (response.messageType == 1) {
                    $("#firstTab").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);

                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable)) {
                        activatejQueryTable();
                    }
                    //swal("Success", response.message, "success");
                    toastr.success(response.message);
                } else {
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
            
            $("#secondTab").html(response);
            GetAllBlogCategories("ddlBlogCategory", false);
            
            $('#ddlBlogCategory').addClass("select2");
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
            var blogId = $('#modelBlogId').val();
            $.ajax({
                type: 'GET',
                url: '/Blog/GetAnBlogById/',
                data: { blogId: blogId },
                success: function (response) {
                    $('.select2').select2();
                    var data = JSON.parse(response);
                    GetAllBlogCategories("ddlBlogCategory", true);
                    $('#ddlBlogCategory').val(data.BlogCategoryId).change();

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
