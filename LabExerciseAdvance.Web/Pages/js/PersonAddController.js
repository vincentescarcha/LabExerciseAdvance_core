(function () {

    var app = angular.module("LabExercise");



    var PersonAddController = function ($scope, $http, $filter, $window) {
        $scope.message = "Person Add";
        $scope.dateOfBirth = new Date();
        $scope.gender = "Male";
        $scope.status = "Single";

        var onAddComplete = function (response) {
            console.log(response.data);
            $scope.error = "";
            alert("success!");
            $window.location.href = "/#!/person";
        };
    
        var onError = function (reason) {
            $scope.error = "Error:"+reason.data;
            alert($scope.error);
        };

        $scope.addPerson = function () {
            var data = {
                firstName: $scope.firstName,
                lastName: $scope.lastName,
                dateOfBirth: $filter('date')($scope.dateOfBirth, "yyyyMMdd"),
                gender: $scope.gender,
                status: $scope.status,
                city: $scope.city,
                other: $scope.other,
                other2: $scope.other2,
            };
            $http.post("http://localhost:6600/api/person", data)
                .then(onAddComplete, onError);
        };

        var onLoadCitiesComplete = function (response) {
            $scope.cities = response.data;
        };

        $scope.loadCities = function(){
            $http.get("http://localhost:6600/api/city")
                .then(onLoadCitiesComplete, onError);
        }

        $scope.loadCities()
    }

    app.controller("PersonAddController", ["$scope", "$http", "$filter", "$window", PersonAddController]);

}());