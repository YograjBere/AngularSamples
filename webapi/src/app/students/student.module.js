(function () {
    'use strict';

    angular.module('TP.student', [
        'TP.student.controllers',
        'TP.student.services'
    ])
    .config(moduleConfig);

    function moduleConfig($stateProvider) {
        $stateProvider
            .state('students', {
                url: '/students',
                templateUrl: 'src/app/students/views/studentsView.tpl.html'
            })
        .state('students.list', {
            url: '/list',
            templateUrl: 'src/app/students/views/studentListView.tpl.html',
            controller: 'studentListViewController as vm'
        })
        .state('students.create', {
            parent: 'students',
            url: '/create',
            templateUrl: 'src/app/students/views/studentCreateView.tpl.html',
            controller: 'studentCreateViewController as vm'
        })
        .state('students.edit', {
            parent: 'students',
            url: '/edit/:studentId',
            templateUrl: 'src/app/students/views/studentCreateView.tpl.html',
            controller: 'studentCreateViewController as vm'
        });
    }

    moduleConfig.$inject = ['$stateProvider'];
    angular.module('TP.student.services', []);
    angular.module('TP.student.controllers', ['TP.student.services', 'ui.router']);
})();