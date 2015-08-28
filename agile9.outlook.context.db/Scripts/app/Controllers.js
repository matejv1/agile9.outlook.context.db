'use strict';

var appControllers = angular.module('appControllers', []);

appControllers.controller("appControllers", ['$scope', 'RestService',
    function ($scope, RestService) {
        RestService.getInsurances().success(function (data) {
            $scope.movies = data;
        })
    }]);

appControllers.controller("CompanyController", ['$scope', 'RestService',
    function ($scope, RestService) {
        $scope.submit = function () {

        }
        $scope.editMode = false;
        $scope.addMode = false;

        //getCompanies
        RestService.getCompanies().success(function (data) {
            $scope.companies = data;
        })
        
        //addCompany
        $scope.addCompany = function () {
            var name = $scope.company.Name;
            var email = $scope.company.Email;
            var logoUrl = $scope.company.LogoUrl;

            RestService.addCompany(name, email, logoUrl).success(function (data) {
                $scope.companies = data;
            })

        }

    }]);



appControllers.controller("TestCtrl", ['$scope', 'RestService',
    function ($scope, RestService) {
        
        //getCompanies
        RestService.getCompanies().success(function (data) {
            $scope.companies = data;
        })

    }]);



angular.module('dwqd', []).
  directive('showErrors', function () {
      return {
          restrict: 'A',
          require: '^form',
          link: function (scope, el, attrs, formCtrl) {
              // find the text box element, which has the 'name' attribute
              var inputEl = el[0].querySelector("[name]");
              // convert the native text box element to an angular element
              var inputNgEl = angular.element(inputEl);
              // get the name on the text box so we know the property to check
              // on the form controller
              var inputName = inputNgEl.attr('name');

              // only apply the has-error class after the user leaves the text box
              inputNgEl.bind('blur', function () {
                  el.toggleClass('has-error', formCtrl[inputName].$invalid);
              })
          }
      }
  });


//angular.module('ui.bootstrap.demo',[]).controller('AccordionDemoCtrl', function ($scope) {
//    $scope.oneAtATime = true;

//    $scope.groups = [
//      {
//          title: 'Dynamic Group Header - 1',
//          content: 'Dynamic Group Body - 1'
//      },
//      {
//          title: 'Dynamic Group Header - 2',
//          content: 'Dynamic Group Body - 2'
//      }
//    ];

//    $scope.items = ['Item 1', 'Item 2', 'Item 3'];

//    $scope.addItem = function () {
//        var newItemNo = $scope.items.length + 1;
//        $scope.items.push('Item ' + newItemNo);
//    };

//    $scope.status = {
//        isFirstOpen: true,
//        isFirstDisabled: false
//    };
//});
