(function () {
    'use strict';

    angular.module('TP', [
    	'ui.router',
        'TP.core'
    ])
    .config(moduleConfig).run(initialize);

    function moduleConfig($stateProvider, $urlRouterProvider, $httpProvider) {

        // Static Routes
        $stateProvider.state('home', {
            url: '/home',
            templateUrl: 'src/app/core/views/home.tpl.html',
            controller: 'HomeViewController as vm'
        });

        $urlRouterProvider.otherwise(function ($injector, $location) {
            var path = $location.path().split('/').slice(0, 2).join('/');
            if (location.hash === '' && location.pathname === '/') {
                return '/home';
            } else {
                return '/error/404/?path=' + $location.$$path;
            }
        });

    }

    function initialize($log) {
        $log.info("app initialized!");
    }
    initialize.$inject = ['$log'];



})();
