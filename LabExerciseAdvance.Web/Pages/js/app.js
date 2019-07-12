(function () {

    var app = angular.module("LabExercise", ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "pages/site_map.html"
            });

        $routeProvider
            .when("/person", {
                templateUrl: "pages/person_list.html",
                controller: "PersonController"
            });

        $routeProvider
            .when("/person/add", {
                templateUrl: "pages/person_add.html",
                controller: "PersonAddController"
            });

        $routeProvider
            .when("/school", {
                templateUrl: "pages/registration.html",
                controller: "SchoolRegistrationController"
            });

        $routeProvider
            .when("/voters", {
                templateUrl: "pages/registration.html",
                controller: "VotersRegistrationController"
            });

        $routeProvider
            .when("/daycare", {
                templateUrl: "pages/registration.html",
                controller: "DayCareRegistrationController"
            });

        $routeProvider
            .when("/registration", {
                templateUrl: "pages/registration_area.html",
                controller: "RegistrationController"
            });

        $routeProvider.otherwise({redirectTo: "/"});
    });

    app.service("sharedProperties", function () {
        //for passing between data between controllers
        var registration = "";

        return {
            getRegistration: function () {
                return registration;
            },
            setRegistration: function(value) {
                registration = value;
            }
        };
    });
}());