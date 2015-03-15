var backlogServices = angular.module("backlogServices", ["ngResource"]);

backlogServices.factory("BacklogItem", ["$resource", function ($resource) {
    return $resource(
        "/api/:backlogItemId",
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
            authorizationResult = OAuth.create("twitter");
        },
        isReady: function () {
            return authorizationResult;
        },
        authenticatedUserName: function () {
            return userName;
        },
        connectTwitter: function () {
            var deferred = $q.defer();
            OAuth.popup("twitter", { cache: true })
                 .done(function (result) {
                     authorizationResult = result;
                     result.me()
                           .done(function (response) {
                               userName = response.name;
                     });

                     deferred.resolve();

                 });
            return deferred.promise;
        },
        clearCache: function () {
            OAuth.clearCache("twitter");
            authorizationResult = false;
            userName = "";
        }
    }
}]);

