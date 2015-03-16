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
                backdrop: 'static',
                size: 'lg'
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

backlogControllers.controller("NewStory", ["$scope", "$modalInstance", "BacklogItem", "UserService", "Twitter", function ($scope, $modalInstance, BackLogItem, UserService, Twitter) {
    function init(scope) {
        scope.discipline = "";
        scope.action = "";
        scope.goal = "";
        scope.owner = Twitter.getAuthenticatedUser();
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
        story.ownerId = $scope.owner.id;

        $modalInstance.close(story);
    };

    $scope.close = function () {
        $modalInstance.close();
    }

    init($scope);
}]);


backlogControllers.controller("Navigation", ["$rootScope", "$scope", "$location", "$localStorage", "Twitter", function ($rootScope, $scope, $location, $localStorage, Twitter) {
    Twitter.initialize();
    var authenticate = function () {
        Twitter.authenticate()
               .then(function () {
                   if (Twitter.isReady()) {
                       $rootScope.authenticated = true;
                       $rootScope.authenticatedUser = Twitter.getAuthenticatedUser();
                       $scope.$storage = $localStorage.$default({
                           authenticatedUser: Twitter.getAuthenticatedUser()
                       });
                   } else {
                       $scope.error = true;
                   }
               });
    };




    //authenticate();


    $scope.signIn = function () {
        authenticate();
    }

    $scope.signOut = function () {
        Twitter.clearCache();
        $rootScope.authenticated = false;
        $rootScope.authenticatedUser = null;
    }
}]);