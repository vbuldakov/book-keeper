function MainCtrl($scope, $state, $stateParams) {
    var init = function () {
        $scope.$state = $state;
        $scope.params = $stateParams;
    }

    init();
}