(function () {

	var app = angular.module("LabExercise");

	var RegistrationController = function ($scope, $http, $filter, sharedProperties) {
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

		var onError = function (reason) {
			$scope.error = "Error:" + reason.data;
			alert($scope.error);
		};

		$scope.loadPersons = function () {
			$http.get("http://localhost:6600/api/person")
				.then(onGetComplete, onError);
		};

		var onRegisterComplete = function(response){
			alert("Successfully Registered!");
		}

		$scope.register = function(id){
			if($scope.registrationType === ""){
				alert("Please select registration first.");
				return;
			}
			var url="http://localhost:6600/api/"+$scope.registrationType.replace(" ","")+"/"+id;
			$http.post(url).then(onRegisterComplete, onError);
		};

		$scope.loadPersons();
	}

	app.controller("RegistrationController", ["$scope", "$http", "$filter", "sharedProperties", RegistrationController]);

}());