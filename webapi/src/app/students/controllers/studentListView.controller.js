(function () {
    'use strict';

    angular.module('TP.student.controllers')
        .controller('studentListViewController', studentListViewController);

    function studentListViewController($resource, $log) {
        /*jshint validthis: true */
        var vm = this;

        function getStudentList() {


        }

        vm.getStudentList = getStudentList;
    }
    studentListViewController.$inject = ['$resource, $log'];

})();