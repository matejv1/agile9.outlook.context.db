'use strict';

var appServices = angular.module('appServices', []);

appServices.factory("RestService", ['$http', createServiceObject]);

function createServiceObject($http) {
    var service = {};
    var requestGetHeaders = 'application/json';

    service.getInsurances = function () {
        var restQueryUrl = "http://localhost:27599/api/insurances";

        return $http({
            method: 'GET',
            url: restQueryUrl,
            headers: {
                "accept": "application/json",
            }
        })
    }

    service.getCompanies = function () {
        var restQueryUrl = "http://localhost:27599/api/companies";

        return $http({
            method: 'GET',
            url: restQueryUrl,
            headers: {
                "accept": "application/json",
            }
        })
    }

    service.addCompany = function (Name, Email, LogoUrl) {
        var restQueryUrl = "http://localhost:27599/api/companies";

        var companyData = {
            Name: Name,
            Email: Email,
            LogoUrl: LogoUrl
        };

        var requestBody = JSON.stringify(companyData);

        return $http({
            method: 'POST',
            url: restQueryUrl,
            contentType: "application/json",
            data: requestBody,
            headers: {
                "Accept": "application/json",
                "content-type": "application/json"
            }
        });
    }

    service.getCompany = function (email) {
        var restQueryUrl = "https://localhost:44301/api/companies?$filter=substringof(Email,'" + email + "')";

        return $http({
            method: 'GET',
            url: restQueryUrl,
            headers: requestGetHeaders
        })
    }



    service.getReports = function () {
        var restQueryUrl = "https://localhost:44301/api/reports";

        return $http({
            method: 'GET',
            url: restQueryUrl,
            headers: requestGetHeaders
        })
    }

    service.getReportsByEmail = function (mail) {

        var restQueryUrl = "https://localhost:44301/api/reports?mail=" + mail;

        return $http({
            method: 'GET',
            url: restQueryUrl,
            headers: requestGetHeaders
        })
    }

    //sharepoint:search-rest api
    service.getSearchResult = function (query) {

        var restQueryUrl = "https://agile9.sharepoint.com/_api/search/query?querytext='" + query + "'";

        return $http({
            url: restQueryUrl,
            method: "GET",
            headers: {
                "accept": "application/json; odata=verbose",
            }
        })
    }

    service.getDocumentsSearchResult = function (query) {

        var restQueryUrl = "https://agile9.sharepoint.com/_api/search/query?querytext='" + query + "'&selectproperties='Title,Author,LinkingUrl,FileExtension,Write,LastModifiedTime'&refinementfilters='fileExtension:equals(\"docx\")'";

        return $http({
            url: restQueryUrl,
            method: "GET",
            headers: {
                "accept": "application/json; odata=verbose",
            }
        })
    }

    //exchange:search-rest api
    service.getEmails = function (query) {

        var restQueryUrl = "https://outlook.office365.com/api/v1.0/me/messages?$filter=From/EmailAddress/Address eq '" + query + "'&$top=5";

        return $http({
            url: restQueryUrl,
            method: "GET",
            headers: {
                "accept": "application/json",
            }
        })
    }

    return service;
}