(function () {
    'use strict';

    angular.module('TP.student.controllers')
        .controller('studentListViewController', studentListViewController);

    function studentListViewController($scope, studentService, $log) {
        var vm = this;

        function getStudentList() {
            var promise = studentService.getStudents();
            promise.then(function (payload) {
                $scope.studentList = payload.data;
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        function deleteStudent(id) {
            var promise = studentService.deleteStudent(id);
            promise.then(function (payload) {

            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        vm.getStudentList = getStudentList;
        vm.deleteStudent = deleteStudent;
        getStudentList();
    }
    studentListViewController.$inject = ['$scope', 'studentService', '$log'];

})();