
app.controller('authController',  function ($scope, authService) {//no pasar en []
    $scope.userName = "Admin";
    $scope.password = "";
    $scope.isAuthenticated = false;

    $scope.authenticate = function () {
        console.log('----BEGIN----');
        authService.authenticate({ userName: $scope.userName, password: $scope.password })
            .then(function (response) { $scope.isAuthenticated = response.isAuth; $('#_password').val('') }, function (response) { $scope.isAuthenticated = response});
       
        console.log('----END----');
    };
    
});