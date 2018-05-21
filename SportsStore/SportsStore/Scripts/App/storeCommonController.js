var app = angular.module("App", []);
app.controller("commonController", function ($scope) {
    var authenticateUrl = "/authenticate";

    $scope.testAuth = function () {
        username = "Admin";
        password = "secret";
        this.authenticate();
    }
    $scope.authenticate = function (successCallback) {
        sendRequest(
            authenticateUrl,
            "POST",
            { "grant_type": "password", username: username, password: password },
            function (data) {
                model.authenticated = true;
                setAjaxHeaders({ Authorization: "bearer " + data.access_token });
                if (successCallback) {
                    successCallback();
                }
            });
    };
});
