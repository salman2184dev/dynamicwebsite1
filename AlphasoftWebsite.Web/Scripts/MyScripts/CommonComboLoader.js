
function GetAllDesignations(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllDesignations';
    LoadComboWithCondition(controlId, url, identityCode,  isDefaultRecordRequired);
}

function GetAllProductCategories(controlId, identityCode, isDefaultRecordRequired) {
    
    var url = '/Common/GetAllProductCategories';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllNewsLetterEmails(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllNewsLetterEmails';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllBlogCategories(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllBlogCategories';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}
function GetAllIconList(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllIconList';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllCompanyList(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllCompanyList';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllSocialAccountTypeList(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllSocialAccountTypeList';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllSoftwareCategories(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllSoftwareCategories';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllService(controlId, identityCode, isDefaultRecordRequired) {
    
    var url = '/Common/GetAllService';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllPricingTableType(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllPricingTableType';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllPricingDetailType(controlId, identityCode, isDefaultRecordRequired) {
    debugger;
    var url = '/Common/GetAllPricingDetailType';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}


function GetAllHostTypes(controlId, identityCode, isDefaultRecordRequired) {
    var url = '/Common/GetAllHostTypes';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}

function GetAllSmtpHosts(controlId, identityCode, isDefaultRecordRequired) {
    var url = '/Common/GetAllSmtpHosts';
    LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired);
}
//function LoadCombo(controlId, url, identityCode, isDefaultRecordRequired) {
function LoadCombo(controlId, url, isDefaultRecordRequired) {

    $.ajax({
        url: url,
        data: {},
        type: 'get',
        async: false,
        cache: false,
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);
                });
            }
        },
        error: function () {
            alert('Error');
        }
    });
}

function LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired) {
    $.ajax({
        url: url,
        type: 'get',
        async: false,
        data: {
            identityCode: identityCode
        },
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);//chancge later
                });
            }
        },
        error: function () {
            alert('Error');
        }
    });
}

function LoadComboWithIcon(controlId, url, isDefaultRecordRequired) {

    $.ajax({
        url: url,
        data: {},
        type: 'get',
        async: false,
        cache: false,
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);
                });

            }
        },
        error: function () {
            alert('Error');
        }
    });
}
