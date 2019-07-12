(function () {

	var app = angular.module("LabExercise");

	var VotersRegistrationController = function ($scope, $http, $filter, $window, sharedProperties) {
		$scope.registrationType = "Voters Registration";
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
			$http.get("http://localhost:6600/api/votersregistration")
				.then(onGetComplete, onError);
		}

		$scope.addRegistered = function () {
			sharedProperties.setRegistration($scope.registrationType);
			$window.location.href = "/#!/registration";
		};

		$scope.getData();
	}

	app.controller("VotersRegistrationController", ["$scope", "$http", "$filter", "$window", "sharedProperties", VotersRegistrationController]);

}());