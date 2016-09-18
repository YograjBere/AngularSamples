(function () {
    'use strict';

    angular.module('TP.student.services')
        .factory('studentService', studentService);

    function studentService($http, $q, $state) {
        var vm = this;
        var servicePrefix = "/Students";
        this.mode = "";

        function createStudent(student) {
            var url = servicePrefix;
            var defer = $q.defer();
            $http.post(url, student).then(function (response) {
                defer.resolve(response);
            });
            return defer.promise;
        }

        function getStudents() {
            var url = servicePrefix;
            return getPromiseForGetOperation(url);
        }

        function getStudent(id) {
            var url = servicePrefix + "/" + id;
            return getPromiseForGetOperation(url);
        }

        function getPromiseForGetOperation(url) {
            var defer = $q.defer();
            $http.get(url).then(function (response) {
                defer.resolve(response);
            });
            return defer.promise;
        }

        function getPromiseForOperation(operation) {
            var defer = $q.defer();
            operation.then(resolvePromise);
            return defer.promise;
        }

        function deleteStudent(studentId) {
            var url = servicePrefix + "/" + studentId;
            var defer = $q.defer();
            $http.delete(url, studentId).then(function (response) {
                defer.resolve(response);
            });
            return defer.promise;
        }

        function updateStudent(student) {
            var url = servicePrefix;
            var defer = $q.defer();
            $http.put(url, student).then(function (response) {
                defer.resolve(response);
            });
            return defer.promise;
        }

        function resolvePromise() {
            return function (response) {
                defer.resolve(response);
            }
        }

        function gotoState(state) {
            $state.go(state);
        }

        function reloadState() {
            $state.reload();
        }

        function getCurrentMode() {
            this.mode = $state.current.name == "students.edit" ? "edit" : "create";
            return this.mode;
        }

        function convertTextToDate(dateStr) {
            return new Date(dateStr);
        }

        return {
            createStudent: createStudent,
            getStudent: getStudent,
            getStudents: getStudents,
            deleteStudent: deleteStudent,
            updateStudent: updateStudent,
            gotoState: gotoState,
            getCurrentMode: getCurrentMode
        }
    }

    studentService.$inject = ['$http', '$q', '$state'];
})();