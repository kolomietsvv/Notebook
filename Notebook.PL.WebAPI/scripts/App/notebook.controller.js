/// <reference path="../lodash.js" />
/// <reference path="../libs/angular.js" />
'use strict';

App.controller('NotebookCtrl', ['$scope', '$timeout', 'NotebookService', 'modal', function ($scope, $timeout, NotebookService, modal) {

    $scope.editedNotebookId = null;
    $scope.newNotebook = {
        Text: ''
    };
    $scope.refreshNotebookList = refreshNotebookList;
    $scope.editRow = editRow;
    $scope.editOff = editOff;
    $scope.currentYear = new Date().getFullYear();
    $scope.remove = remove;
    $scope.save = save;
    $scope.addNew = addNew;
    $scope.order = order;
    $scope.changePropForSearch = changePropForSearch;

    $scope.criteriaMatch = criteriaMatch;

    $scope.NotebookList = null;

    $(window).on('beforeunload', function () {
        NotebookService.patch();
        return 'Saved';
    });

    window.onbeforeunload= function () {
        NotebookService.patch();
        return 'Saved';
    };

    init();

    function init() {
        refreshNotebookList();
        $scope.order('Surname', true);
        $scope.search = '';
        changePropForSearch('Surname');

        $scope.$on('$responseError', function (event, errorMessage) {
            errorMessage = errorMessage.split('\n');
            modal(errorMessage, 7000);
        });
    }

    function changePropForSearch(newVal) {
        $scope.propertyForSearch = newVal;
    }

    function criteriaMatch(searchData, property) {
        return function (item) {
            return _.includes(item[property].toLowerCase(), searchData.toLowerCase());
        };
    };

    function order(predicate) {
        $scope.predicate = predicate;
        $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
    };

    function editRow(id) {
        $scope.editedNotebookId = id;
    }

    function editOff() {
        $scope.editedNotebookId = null;
    }

    function save(Notebook) {
        editOff();
        updateNotebook(Notebook);
    }

    $scope.$watch('myFile', function (newVal) {
        if (angular.isDefined(newVal)) {
            $timeout(function () {
                uploadFile(newVal);
            });
        }
    });

    //GET 
    function refreshNotebookList() {
        NotebookService.get().then(function (response) {
            $timeout(function () {
                $scope.NotebookList = response && response.data;
            });
        });
    }

    //POST 
    function addNew() {
            NotebookService.post($scope.newNotebook).then(function () {
                refreshNotebookList();
            });
    }

    //PUT 
    function updateNotebook(Notebook) {
        NotebookService.update(Notebook).then(function () {
            refreshNotebookList();
        });
    }

    //DELETE 
    function remove(id) {
        NotebookService.remove(id).then(function () {
            refreshNotebookList();
        });
    }
}]);