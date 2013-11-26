function NavigationCtrl($scope, $http, User, Security) {

    var init = function () {
        $scope.user = User.current();
        $scope.logout = logout;
    }

    var logout = function () {
        Security.logout().then(function () {
            window.location = "/";
        });
    }

    init();
}