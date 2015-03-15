var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "BacklogItem", function ($scope, BacklogItem) {
    $scope.productBacklogItems = BacklogItem.query();
    $scope.orderProp = "-id";
}]);

backlogControllers.controller("Navigation", ["$rootScope", "$scope", "$location", "Twitter", function ($rootScope, $scope, $location, Twitter) {
    Twitter.initialize();

    var setUserScope = function () {
        if (User.isLogged()) {
            var user = User.getIdentity();
            $scope.authenticatedUser = user.data;
        }
    };

    var authenticate = function () {
        Twitter.connectTwitter()
            .then(function () {
                if (Twitter.isReady()) {
                    $rootScope.authenticated = true;
                    Twitter.isReady().me().done(function(me) {
                        $scope.me = me;
                    });
                    setUserScope();
                } else {
                    $scope.error = true;
                }
            }, null, function (update) {
                setUserScope();
            });
    };



    if (User.isLogged()) {
        $rootScope.authenticated = true;
        setUserScope();
    } else {
        authenticate();
        setUserScope();
    }

    $scope.signIn = function () {
        authenticate();
        setUserScope();
    }

    $scope.signOut = function () {
        Twitter.clearCache();
        setUserScope();
    }
}]);