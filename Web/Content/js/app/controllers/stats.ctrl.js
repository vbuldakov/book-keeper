function StatsCtrl($scope, $stateParams, StatsRepository) {

    var init = function () {
        $scope.stats = StatsRepository.get({ period: $stateParams.periodType });
    }

    init();
}