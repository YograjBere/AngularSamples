(function () {
    'use strict';

    angular.module('TP.student.controllers')
        .controller('studentListViewController', studentListViewController);

    function studentListViewController($scope, studentService, $log, notificationService) {
        var vm = this;
        $scope.studentList = [];

        function getStudentList() {
            var promise = studentService.getStudents();
            promise.then(function (payload) {
                $scope.studentList = payload.data;
            }, function (errorPayload) {
                $log.error(errorPayload);
            });
        }

        function deleteStudent(id) {
            bootbox.confirm("Are you sure you want to delete student ?", function (result) {
                if (result) {
                    var promise = studentService.deleteStudent(id);
                    promise.then(function (payload) {
                        angular.forEach($scope.studentList, function (student, key) {
                            if (student.id == id) {
                                var index = $scope.studentList.indexOf(student);
                                $scope.studentList.splice(index, 1);
                                //studentService.reloadState();
                                notificationService.success('Deleted student successfully.');
                            }
                        });
                        studentService.gotoState('students.list');
                    }, function (errorPayload) {
                        $log.error(errorPayload);
                        notificationService.error('Error deleting student..!');
                    });
                }
            });
        }

        vm.getStudentList = getStudentList;
        $scope.deleteStudent = deleteStudent;
        getStudentList();
    }
    studentListViewController.$inject = ['$scope', 'studentService', '$log', 'notificationService'];

})();