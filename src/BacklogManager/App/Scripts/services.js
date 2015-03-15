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

backlogServices.factory("Twitter", ["$q", function ($q) {
    var authorizationResult = false;
    var userName = "";

    return {
        initialize: function () {
            // Initialize OAuth.io with public key
            OAuth.initialize("mXmUMUFVm37zUdMeXpgWancUJJ8", { cache: true });
            // Try to create an authorization result when called
            authorizationResult = OAuth.create('twitter');
        },
        isReady: function () {
            return authorizationResult;
        },
        authenticatedUserName: function () {
            return userName;
        },
        connectTwitter: function () {
            var deferred = $q.defer();
            OAuth.popup('twitter', { cache: true }, function (err, res) {
                if (!err) {
                    authorizationResult = res;
                    userName = res.name;
                    deferred.resolve();
                } else {
                    //TODO: Something if there's an error
                }
            });
            return deferred.promise;
        },
        clearCache: function () {
            OAuth.clearCache('twitter');
            authorizationResult = false;
            userName = "";
        }
    }
}]);

