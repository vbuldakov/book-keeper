
var navigationViewModel = (function () {

    var userName = ko.observable("N/A");

    //Public operations
    var init = function () {
        $.get('/members/user', setUserFromServer)
    };

    var logout = function () {
        $.post('/members/logout', security.createSecureData(), goHome);
    }

    //Private operations
    var setUserFromServer = function (data) {
        userName(data.userName);
    };

    var goHome = function () {
        window.location = "/";
    }

    // Interface
    return {
        userName: userName,
        init: init,
        logout: logout
    };
})();

$(document).ready(function () {

    navigationViewModel.init();
    ko.applyBindings(navigationViewModel, document.getElementById('navigation'));

});