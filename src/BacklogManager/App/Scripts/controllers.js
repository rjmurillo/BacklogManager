var backlogApp = angular.module("backlogApp", []);

backlogApp.controller("BacklogListCtrl", function ($scope) {
    $scope.PBIs = [
        { "title": "My first PBI" }
    ];
});