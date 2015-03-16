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

backlogServices.factory("Twitter", ["$q", "UserService", function ($q, UserService) {
    var authorizationResult = false;
    var user = "Guest";

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
        getAuthenticatedUser: function () {
            return user;
        },
        authenticate: function () {
            var deferred = $q.defer();
            OAuth.popup("twitter", { cache: true })
                 //.then(function (result) {
                     //User.signin(result);
                 //})
                 .done(function (result) {
                     authorizationResult = result;
                     result.me()
                           .done(function (response) {
                               // REVIEW: This is unreliable
                               var u = new UserService();
                               u.username = response.alias;
                               u.name = response.name;
                               u.avatar = response.avatar;
                               u.socialId = response.id;
                               u.$update(function() {
                                   var u1 = UserService.get({ id: response.id }, function() {
                                       
                                   });
                               });

                                
                           });

                     deferred.resolve();

                 });
            return deferred.promise;
        },
        clearCache: function () {
            OAuth.clearCache("twitter");
            authorizationResult = false;
            user = "Guest";
        }
    }
}]);

