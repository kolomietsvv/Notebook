'use strict';
App.config(['$httpProvider', function ($httpProvider) {
	$httpProvider.interceptors.push(['$rootScope', function ($rootScope) {
		return {
			'responseError': function (rejection) {
				if (angular.isDefined(rejection.data.Message)) {
					$rootScope.$broadcast('$responseError', rejection.data.Message);
				}
			}
		};
	}]);
}]);