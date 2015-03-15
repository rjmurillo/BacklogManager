var backlogServices = angular.module("backlogServices", ["ngResource"]);

backlogServices.factory("BacklogItem", ["$resource", function ($resource) {
    return $resource(
        "/App/Data/:backlogItemId.json",
        {},
        {
            query:
            {
                method: "GET",
                params: { backlogItemId: "backlog" },
                isArray: true
            }
        });
}]);

