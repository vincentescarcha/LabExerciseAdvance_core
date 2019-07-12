(function () {

	var app = angular.module("LabExercise");

	var RegistrationController = function ($scope, $http, $filter, sharedProperties) {
		$scope.message = "Registration Area";
		$scope.registrations = [
			{ name: "Voters Registration" },
			{ name: "School Registration" },
			{ name: "DayCare Registration" }
		];

		$scope.registrationType = sharedProperties.getRegistration();
		var onGetComplete = function (response) {
			$scope.error = "";
			response.data.forEach(function (item) {
				if (item.gender === 0) item.gender = "Male";
				if (item.gender === 1) item.gender = "Female";

				if (item.status === 0) item.status = "Single";
				if (item.status === 1) item.status = "Married";
			});
			$scope.persons = response.data;
		};

		//$filter('date')('2019-02-13', "dd/MM/yyyy");

		var onError = function (reason) {
			$scope.error = "Error:";
			alert("Error Fetching")
		};

		$scope.getData = function () {
			$http.get("http://localhost:6600/api/person")
				.then(onGetComplete, onError);
		}

		$scope.getData();
	}

	app.controller("RegistrationController", ["$scope", "$http", "$filter", "sharedProperties", RegistrationController]);

}());