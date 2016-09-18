﻿(function () {
    'use strict';

    angular.module('TP.student.controllers')
        .controller('studentCreateViewController', studentCreateViewController);

    function studentCreateViewController($scope, studentService, $log, $stateParams) {
        var vm = this;
        $scope.student = {};
        $scope.id = $stateParams.studentId;
        $scope.mode = studentService.getCurrentMode();
        $scope.operation = null;

        function createStudent() {
            var promise = studentService.createStudent($scope.student);
            promise.then(function (payload) {
                $scope.studentId = payload.data;
                studentService.gotoState('students.list');
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        function getStudent() {
            var promise = studentService.getStudent($scope.id);
            promise.then(function (payload) {
                $scope.student = payload.data;
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        function updateStudent() {
            var promise = studentService.updateStudent($scope.student);
            promise.then(function (payload) {
                $scope.student = payload.data;
                studentService.gotoState('students.list');
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        switch ($scope.mode) {
            case "edit":
                getStudent();
                $scope.operation = updateStudent;
                break;
            case "create":
                $scope.operation = createStudent;
                break;
        }

        $scope.createStudent = createStudent;
        $scope.getStudent = getStudent;
        $scope.updateStudent = updateStudent;
    }

    studentCreateViewController.$inject = ['$scope', 'studentService', '$log', '$stateParams'];

})();