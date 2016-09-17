(function () {
    'use strict';

    angular.module('TP', [
    	'ui.router',
        'TP.core'
    ])
    .config(moduleConfig).run(initialize);

    function moduleConfig($stateProvider, $urlRouterProvider, $httpProvider) {

        //stateHelperProvider.state({

        //});

        //students views

        /*var students = {
            name: 'students',
            templateUrl: 'students.html'
        };

        var studentsList = {
            name: 'students.list',
            parent: students,
            templateUrl: 'studentsListView.tpl.html',
            controller: 'StudentListViewController as vm'
        };

        var studentCreate = {
            name: 'students.create',
            parent: students,
            templateUrl: 'studentCreateView.tpl.html',
            controller: 'studentCreateViewController as vm'
        };

        $stateProvider
            .state(students)
            .state(studentsList)
            .state(studentCreate)*/

        // Static Routes
        $stateProvider.state('home', {
            url: '/home',
            templateUrl: 'src/app/core/views/home.tpl.html',
            controller: 'HomeViewController as vm'
        })
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
        });

        $urlRouterProvider.otherwise(function ($injector, $location) {
            var path = $location.path().split('/').slice(0, 2).join('/');
            if (location.hash === '' && location.pathname === '/') {
                return '/students/list';
            } else {
                return '/error/404/?path=' + $location.$$path;
            }
        });

    }

    function initialize($log) {
        $log.info("app initialized!");
    }
    initialize.$inject = ['$log'];
})();
