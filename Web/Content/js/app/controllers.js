'use strict';

/* Controllers */

var controllers = angular.module('bk.controllers', [
    'ui.router',
    '$strap.directives',
    'bk.services']);


controllers.controller('NavigationCtrl', ['$scope', '$http', 'User', 'Security', NavigationCtrl]);
controllers.controller('ExpencesCtrl', ['$scope', '$q', '$modal', '$timeout', '$stateParams', ' $state', '$log', 'CategoriesRepository', 'ExpencesRepository', ExpencesCtrl]);
controllers.controller('MainCtrl', ['$scope', '$state', '$stateParams', MainCtrl]);
controllers.controller('StatsCtrl', ['$scope', '$stateParams', 'StatsRepository', StatsCtrl]);
