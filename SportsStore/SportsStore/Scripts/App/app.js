/*Booting up our app and configuring routes*/

var app = angular.module('App', [/*'ngRoute', 'LocalStorageModule', 'angular-loading-bar'*/]);

//routes later

app.run(['authService', function (authService) {
    authService.welcome();
    //authService.authenticate({ username: "Admin", password: "secret" });
}]);