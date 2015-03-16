var backlogServices = angular.module("backlogServices", ["ngResource"]);

backlogServices.factory("BacklogItem", ["$resource", function ($resource) {
    return $resource(
        "/api/backlog/:backlogId",
        { backlogId: '@id' },
        {
            update: {
                method: "PUT"
            }
        }
        );
}]);

backlogServices.factory("UserService", ["$resource", function ($resource) {
    return $resource(
        "/api/user/:userId",
        { userId: "@id" },
        {
            update: {
                method: "PUT"
            }
        });
}]);

backlogServices.factory("ProjectService", ["$resource", function ($resource) {
    return $resource(
        "/api/project/:projectId",
        { projectId: "@id" },
        { update: { method: "PUT" } }
    );
}]);

backlogServices.factory("Twitter", ["$q", "$log", "$rootScope", "UserService", function ($q, $log, $rootScope, UserService) {
    window.authorizationResult = false;
    var user = "Guest";

    return {
        initialize: function () {
            // Initialize OAuth.io with public key
            OAuth.initialize("mXmUMUFVm37zUdMeXpgWancUJJ8", { cache: true });
            // Try to create an authorization result when called
            window.authorizationResult = OAuth.create("twitter");

            if (!window.authorizationResult) {
                $log.log("User has not authorized application");
            } else {
                $log.log("User has previously authorized this application and credentials are cached");
            }
        },
        isReady: function () {
            return (window.authorizationResult);
        },
        getAuthenticatedUser: function () {
            return user;
        },
        authenticate: function () {
            var deferred = $q.defer();
            OAuth.popup("twitter", { cache: true }, function (error, result) {
                if (!error) {
                    $log.log("Twitter successful auth: " + result.oauth_token);
                    $rootScope.$broadcast("oauth:token", result.oauth_token);
                    $rootScope.$broadcast("oauth:token:secret", result.oauth_token_secret);

                    window.authorizationResult = result;

                    if (user === "Guest") {
                        result.me()
                            .done(function (response) {
                                // REVIEW: This is unreliable
                                var u = new UserService();
                                u.username = response.alias;
                                u.name = response.name;
                                u.avatar = response.avatar;
                                u.socialId = response.id;
                                u.$update(function () {
                                    var u1 = UserService.get({ id: response.id }, function () {
                                        user = u1;
                                        $rootScope.$broadcast("oauth:profile", user);
                                        deferred.resolve();
                                    });
                                });


                            });
                    } else {
                        $log.log("Authenticated user already set");
                    }
                } else {
                    $log.error(error);
                }
            });
            return deferred.promise;
        },
        clearCache: function () {
            OAuth.clearCache("twitter");
            window.authorizationResult = false;
            user = "Guest";
        }
    }
}]);

