'use strict';

App.factory('modal', ['$uibModal', function ($modal) {
	return function (errors, timeout) {
		var modalInstance = $modal.open({
			templateUrl: '/Home/ModalTemplate',
			controller: 'ModalCtrl',
			size: '',
			backdrop: false,
			windowClass: 'modal-alert',
			resolve: {
				errors: function () {
					return errors;
				},
				timeout: function () {
					return timeout;
				}
			}
		});

		return modalInstance.result;
	};
}])
.controller('ModalCtrl', ['$scope', '$uibModalInstance', '$uibModalStack', '$timeout', 'errors', 'timeout', function ($scope, $modalInstance, $modalStack, $timeout, errors, timeout) {
	$scope.errors = errors;

	$scope.ok = function () {
		$modalInstance.close();
	};

	$timeout($scope.ok, timeout);
	$modalStack.dismissAll();
}]);