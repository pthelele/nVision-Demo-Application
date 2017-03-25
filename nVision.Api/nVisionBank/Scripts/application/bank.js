var bankApp = angular.module("nVisionBank", []);

bankApp.factory("AuthenticateService",
[
    "$http", function($http) {
        return {
            authenticate: function(authmodel) {
                $http({
                    url: "http://localhost:5094/nVisionBank/Authenticate?authmodel=" + JSON.stringify(authmodel),
                        method: "GET",
                        data: JSON.stringify(authmodel)
                    })
                    .then(function (response) {
                        var data = JSON.parse(response.data);
                        if (data.Status == false || data.Blocked == true) {
                            $("#errorModalDiv").html(data.ResponseMessage);
                            $("#errorModal").modal("show");
                        }
                        console.log(response);
                    });
            }
        }
    }
]);

bankApp.controller("AuthenticateController",
[
    "$scope", "$http", "AuthenticateService", function ($scope, $http, authenticateService) {
        $scope.message = "";
        $scope.authenticate = function () {
            console.log($scope.cardNumber);
                var authmodel = {
                    cardNumber: $scope.cardNumber,
                    pin : $scope.pin
                };
                console.log(authmodel);
                var response = authenticateService.authenticate(authmodel);

        }
    }
]);