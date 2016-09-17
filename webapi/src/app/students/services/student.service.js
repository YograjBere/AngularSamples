(function () {
    'use strict';

    angular.module('TP.student.services')
        .factory('studentService', studentService);

    function studentService($http) {
        /*jshint validthis: true */
        var vm = this;

        function createStudent() {
            console.log('form submitted');
        }

        function GetStudents() {
            var url = "/Students";
            $http.get(url)
                .success(function (data, status, headers, config) {
                    console.log(data);
                })
                .error(function (data, status, headers, config) {
                    console.log(data);
                });
        }

        function GetStudent(id) {
            var url = "/Students/" + id;
            $http.get(url)
                .success(function (data, status, headers, config) {
                    console.log(data);
                })
                .error(function (data, status, headers, config) {
                    console.log(data);
                });
        }

        function DeleteStudent() {

        }

        vm.createStudent = createStudent;
    }

    studentService.$inject = ['$http'];




})();