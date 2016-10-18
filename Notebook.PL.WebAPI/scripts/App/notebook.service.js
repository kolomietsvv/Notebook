'use strict';

App.service('NotebookService', ['$http', function ($http) {
	var API_PATH = '/api/Notebook/';

	this.get = function () {
		return $http.get(API_PATH);
	};

	this.post = function (data) {
		return $http.post(API_PATH, data);
	};

	this.update = function (data) {
		return $http.put(API_PATH + data.Id, data);
	};

	this.remove = function (id) {
		return $http.delete(API_PATH + id);
	};

	this.patch = function () {
	    return $http.patch(API_PATH);
	};
}]);