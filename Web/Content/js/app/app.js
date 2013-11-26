'use strict';

/* App Module */

var app = angular.module('bk.app', [
    'ui.router',
    'ui.bootstrap',
    'bk.controllers']);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/expences/period/week");

    $stateProvider
        .state("expences", {
            url: "/expences/period/:periodType",
            templateUrl: '/view-expences',
            controller: 'ExpencesCtrl'
        })
        .state("stats", {
            url: "/stats/period/:periodType",
            templateUrl: '/view-stats',
            controller: 'StatsCtrl'
        })
        .state("edit", {
            url: "/expences/edit/id/:id",
            onEnter: ['$stateParams', '$state', '$modal', '$q', function ($stateParams, $state, $modal, $q) {

                //var modalPromise = $modal({
                //    template: '/expEditModal',
                //    persist: true,
                //    show: false,
                //    backdrop: 'static',
                //    //scope : $scope,
                //    controller: ['$scope', function ($scope) {
                //        $scope.updateExpence = function (selectedExpence, hide) {
                //            console.log('save');
                //            hide();
                //        }
                //    }]
                //});

                //$q.when(modalPromise).then(function (modalEl) {
                //    modalEl.modal('show');
                //});

                $modal.open({
                    template: '/expEditModal',
                    //persist: true,
                    //show: false,
                    backdrop: 'static'
                    //scope: $scope
                });

                console.log("expences.edit");
            }]
        });
}]);

//app.config(['$routeProvider',
//    function ($routeProvider) {
//        $routeProvider.
//            when('/expences', {
//                templateUrl: '/view-expences',
//                controller: 'ExpencesCtrl'
//            }).
//            when('/statistics', {
//                templateUrl: '/view-stats'
//            }).
//            //when('/phones/:phoneId', {
//            //    templateUrl: 'partials/phone-detail.html',
//            //    controller: 'PhoneDetailCtrl'
//            //}).
//            otherwise({
//                redirectTo: '/expences'
//            });
//    }]);