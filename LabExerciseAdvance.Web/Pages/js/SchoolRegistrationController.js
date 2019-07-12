(function () {

	var app = angular.module("LabExercise");

	var SchoolRegistrationController = function ($scope, $http, $filter, $window, sharedProperties) {
		$scope.registrationType = "School Registration";
		$scope.message = $scope.registrationType + " List";

		var onGetComplete = function (response) {
			$scope.error = "";
			
			$scope.persons = response.data;
		};

		var onError = function (reason) {
			$scope.error = "Error:" + reason.data;
			alert($scope.error);
		};

		$scope.getData = function () {
			$http.get("http://localhost:6600/api/schoolregistration")
				.then(onGetComplete, onError);
		}

		$scope.addRegistered = function () {
			sharedProperties.setRegistration($scope.registrationType);
			$window.location.href = "/#!/registration";
		};

		$scope.getData();
	}

	app.controller("SchoolRegistrationController", ["$scope", "$http", "$filter", "$window", "sharedProperties", SchoolRegistrationController]);

}());