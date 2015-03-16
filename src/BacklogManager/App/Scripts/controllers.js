var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "BacklogItem", function ($scope, BacklogItem) {

    $scope.orderProp = "globalRank";

    $scope.editInProgressBacklogItem = {
        action: "",
        discipline: "",
        goal: "",
        upvotes: 0,
        globalRank: 0,
        id: 0
    };

    $scope.populate = function () {
        $scope.productBacklogItems = BacklogItem.query();
    };

    $scope.upvote = function (item) {
        var item2 = BacklogItem.get({ id: item.id }, function () {
            item2.upvotes += 1;
            item2.$update(function () {
                $scope.populate();
            });
        });
    }

    $scope.dragControlListeners = {
        itemMoved: function (event) {
            alert("moved");
        },
        orderChanged: function (event) {
            alert("changed");
        },
        containment: '#sortable'
    };

    $scope.populate();
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