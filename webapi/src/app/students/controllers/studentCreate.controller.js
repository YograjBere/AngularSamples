(function () {
    'use strict';

    angular.module('TP.student.controllers')
        .controller('studentCreateViewController', studentCreateViewController);

    function studentCreateViewController($log) {
        /*jshint validthis: true */
        var vm = this;
        function createStudent() {
            console.log('form submitted');
        }

        vm.createStudent = createStudent;
    }

    studentCreateViewController.$inject = ['$log'];

})();