(function () {
    'use strict';

    angular.module('TP.core.controllers')
        .controller('HomeViewController', homeViewController);

    function homeViewController($log) {
        /*jshint validthis: true */
        var vm = this;

        function test() {
            $log.info('home controller loaded');
        }
        vm.test = test;
    }
    homeViewController.$inject = ['$log'];

})();