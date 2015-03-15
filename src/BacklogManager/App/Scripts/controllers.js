var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "$http", function ($scope, $http) {
    $http.get("/App/Data/backlog.json")
        .success(function(data) { $scope.productBacklogItems = data; });

    $scope.orderProp = "age";
}]);