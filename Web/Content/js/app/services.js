'use strict';

/* Services */

var services = angular.module('bk.services', ['ngResource']);

services.factory('User', [ '$resource', function ($resource) {
    return $resource('api/user', {}, {
        current: { method: 'GET' }
    });
}]);

services.factory('Security', ['$http', function ($http) {
    return {
        logout: function () {
            return $http.post('api/user/logout');
        }
    }
}]);

services.factory('CategoriesRepository', function ($resource) {
    return $resource('api/categories', {}, {
        create: { method: 'POST' }
    });
});


services.factory('ExpencesRepository', function ($resource) {
    return $resource('api/expences/:id', {}, {
        create: { method: 'POST' },
        delete: { method: 'DELETE', params: { id: '@Id' } },
        update: { method : 'PUT', params: { id: '@Id' } }
    });
});

services.factory('StatsRepository', function ($resource) {
    return $resource('api/statistics', {}, {
        get: { method: 'GET' }
    });
});

services.factory('UserFactory', function ($resource) {
    return $resource('/ngdemo/web/users/:id', {}, {
        show: { method: 'GET' },
        update: { method: 'PUT', params: { id: '@id' } },
        delete: { method: 'DELETE', params: { id: '@id' } }
    })
});
