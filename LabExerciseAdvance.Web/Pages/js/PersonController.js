(function () {

	var app = angular.module("LabExercise");

	var PersonController = function ($scope, $http, $filter) {
		$scope.message = "Person List";


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
			$scope.error = "Error:" + reason.data;
			alert($scope.error);
		};

		$scope.getData = function () {
			$http.get("http://localhost:6600/api/person")
				.then(onGetComplete, onError);
		}

		$scope.getData();
	}

	app.controller("PersonController", ["$scope", "$http", "$filter", PersonController]);

}());