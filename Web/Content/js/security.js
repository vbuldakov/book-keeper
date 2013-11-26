
var security = (function () {
    var antiForgeryToken = "";

    // Operations 
    var init = function () {
        antiForgeryToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
    }

    var createSecureData = function (data) {
        if (typeof data == 'undefined') {
            data = { };
        }
        data.__RequestVerificationToken = antiForgeryToken;
        return data;
    };

    // Interface
    return {
        init: init,
        createSecureData: createSecureData
    };
})();

$(document).ready(function () {
    security.init();
});