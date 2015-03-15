var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "BacklogItem", function ($scope, BacklogItem) {
    //$http.get("/App/Data/backlog.json")
    //    .success(function(data) { $scope.productBacklogItems = data; });
    $scope.productBacklogItems = BacklogItem.query();
    $scope.orderProp = "age";
}]);