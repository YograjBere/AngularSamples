'use strict';

describe('TP.core.controllers.HomeViewController', function () {

    var $log, $scope, createController;

    beforeEach(module('TP.core.controllers'));


    beforeEach(module('TP.core.controllers', function ($provide) {
        // Output messages
        $provide.value('$log', console);
    }));

    beforeEach(inject(function (_$rootScope_, $controller, _$log_) {

        createController = function () {
            $log = _$log_;
            $scope = _$rootScope_.$new();

            return $controller('HomeViewController', {
                '$log': $log,
                '$scope': $scope
            });
        };

    }));

    it('controller should exist', function () {
        var vm = createController();
        spyOn($log, "info").and.callThrough();
        expect(vm).toBeTruthy();
        vm.test();
        expect($log.info).toHaveBeenCalledWith('home controller loaded');
    });
});