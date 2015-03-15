var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "BacklogItem", function ($scope, BacklogItem) {
    $scope.productBacklogItems = BacklogItem.query();
    $scope.orderProp = "age";
}]);

backlogControllers.controller("Navigation", ["$rootScope", "$scope", "$location", "Twitter", function ($rootScope, $scope, $location, Twitter) {
    Twitter.initialize();
    var authenticate = function () {
        Twitter.connectTwitter()
            .then(function () {
                if (Twitter.isReady()) {
                    $rootScope.authenticated = true;
                } else {
                    $scope.error = true;
                }
            });
    };

    if (User.isLogged()) {
        $rootScope.authenticated = true;
        $scope.authenticatedUser = { "name": Twitter.authenticatedUserName() };

    } else {
        authenticate();
    }

    $scope.signIn = function () {
        authenticate();
    }

    $scope.signOut = function () {
        Twitter.clearCache();
    }
}]);