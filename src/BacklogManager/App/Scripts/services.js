var backlogServices = angular.module("backlogServices", ["ngResource"]);

backlogServices.factory("BacklogItem", ["$resource", function ($resource) {
    return $resource(
        "backlogItems/:backlogItemId.json",
        {},
        {
            query:
            {
                method: "GET",
                params: { backlogItemId: "backlogItems" },
                isArray: true
            }
        });
}]);

