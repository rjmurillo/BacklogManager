﻿var backlogApp = angular.module("backlogApp", ["ngRoute", "ui.sortable", "backlogControllers", "backlogServices"]);

backlogApp.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/backlog", {
            templateUrl: "/App/views/backlog-list.html",
            controller: "BacklogListCtrl"
        }).otherwise({
            redirectTo: "/backlog"
        });
}]);