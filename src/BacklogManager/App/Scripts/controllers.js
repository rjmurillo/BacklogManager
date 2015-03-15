var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "$http", function ($scope, $http) {
    $scope.productBacklogItems = [
        { "title": "My first PBI" },
        { "title": "My second PBI" },
        { "title": "My third PBI" },
        { "title": "My fourth PBI" },
        { "title": "My fifth PBI" },
    ];

    $scope.orderProp = "age";
}]);