var backlogControllers = angular.module("backlogControllers", []);

backlogControllers.controller("BacklogListCtrl", ["$scope", "$modal", "BacklogItem", function ($scope, $modal, BacklogItem) {

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

    $scope.addNewStory = function () {
        var modal = $modal.open(
            {
                templateUrl: '/App/Views/Partials/card-new.html',
                controller: 'NewStory',
                backdrop: 'static'
            }
        );

        modal.result
            .then(function (details) {
                if (details) {
                    details.$save();
                    $scope.populate();
                }
            });
    };

    $scope.populate();
}]);

backlogControllers.controller("NewStory", ["$scope", "$modalInstance", "BacklogItem", function ($scope, $modalInstance, BackLogItem) {
    function init(scope) {
        scope.discipline = "";
        scope.action = "";
        scope.goal = "";
        scope.ownerId = 2;
    }

    $scope.addNewStory = function () {
        // TODO: Ensure form is valid before dismissing!
        //if (!this.NewStoryForm.$valid) {
        //    return false;
        //}
        var story = new BackLogItem();
        story.discipline = $scope.discipline;
        story.action = $scope.action;
        story.goal = $scope.goal;
        story.ownerId = $scope.ownerId;

        $modalInstance.close(story);
    };

    $scope.close = function () {
        $modalInstance.close();
    }

    init($scope);
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