(function () {
    'use strict';

    angular.module('TP.student', [
        'TP.student.controllers',
        'TP.student.Services'
    ])
    .config(moduleConfig);

    function moduleConfig($stateProvider) {
        $stateProvider.state('error', {
            url: '/error/:errorCode/?path',
            templateUrl: 'src/app/core/views/error.tpl.html',
        });
    }

    moduleConfig.$inject = ['$stateProvider'];
    angular.module('TP.student.controllers', ['ui.router']);
    angular.module('TP.student.services', ['$http']);
})();