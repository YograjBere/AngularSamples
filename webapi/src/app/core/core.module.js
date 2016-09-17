(function () {
    'use strict';

    angular.module('TP.core', [
        'TP.core.controllers'
    ])
    .config(moduleConfig);

    function moduleConfig($stateProvider) {
        $stateProvider.state('error', {
            url: '/error/:errorCode/?path',
            templateUrl: 'src/app/core/views/error.tpl.html',
        });
    }
    moduleConfig.$inject = ['$stateProvider'];


    // child module definitions
    angular.module('TP.core.controllers', ['ui.router']);

})();