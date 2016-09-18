(function () {
    'use strict';

    angular.module('TP.student.controllers')
    .controller('studentEditViewController', studentEditViewController);

    function studentEditViewController($scope, $q, $http, studentService, $state, $stateParams) {
        var vm = this;
        $scope.id = $stateParams.studentId;
        $scope.student = {};
        $scope.mode = studentService.getCurrentMode();

        function getStudent() {
            var promise = studentService.getStudent($scope.id);
            promise.then(function (payload) {
                $scope.student = payload.data;
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        function updateStudent(student) {
            var promise = studentService.updateStudent($scope.id);
            promise.then(function (payload) {
                $scope.student = payload.data;
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        vm.getStudent = getStudent;
        vm.updateStudent = updateStudent;
        getStudent();
    }

    studentEditViewController.$inject = ['$scope', '$q', '$http', 'studentService', '$state', '$stateParams']
})();