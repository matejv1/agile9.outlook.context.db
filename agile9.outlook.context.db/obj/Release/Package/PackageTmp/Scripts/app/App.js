'use strict';

var app = angular.module("App", [
    'appServices',
    'appControllers',
    'dwqd',
    'ngRoute'
]);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/company/edit/:companyId', {
            templateUrl: '/Scripts/app/Views/edit-company.html',
            controller: 'CompanyController'
        }).
        when('/company/:companyId', {
            templateUrl: '/Scripts/app/Views/view-company.html',
            controller: 'CompanyController'
        }).
        when('/phones/:phoneId', {
            templateUrl: 'partials/phone-detail.html',
            controller: 'PhoneDetailCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });
  }]);
