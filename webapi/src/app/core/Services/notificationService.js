(function () {
    'use strict';

    angular.module('TP.core.services')
        .factory('notificationService', notificationService);

    function notificationService(toastr) {

        function success(message) {
            toastr.success(message);
        }

        function info(message) {
            toastr.info(message);
        }

        function error(message) {
            toastr.error(message);
        }

        return {
            success: success,
            info: info,
            error: error
        }
    }

    notificationService.$inject = ['toastr']
})();