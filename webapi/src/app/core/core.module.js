(function () {
    'use strict';

    angular.module('TP.core', [
        'TP.core.controllers',
        'TP.core.services'
    ])
    .config(moduleConfig);

    function moduleConfig($stateProvider, toastrConfig) {
        $stateProvider.state('error', {
            url: '/error/:errorCode/?path',
            templateUrl: 'src/app/core/views/error.tpl.html',
        });

        angular.extend(toastrConfig, {
            autoDismiss: false,
            containerId: 'toast-container',
            maxOpened: 0,
            newestOnTop: true,
            positionClass: 'toast-bottom-right',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            target: 'body'
        });
    }
    moduleConfig.$inject = ['$stateProvider', 'toastrConfig'];

    // child module definitions
    angular.module('TP.core.controllers', ['ui.router']);
    angular.module('TP.core.services', ['ngAnimate', 'toastr']);

})();