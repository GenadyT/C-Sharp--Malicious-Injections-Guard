/***************** AJAX Data Layer (utils)  *****************/
DL = (function () {
    var _ajaxRequest = function (webApiPrefix, apiController, apiMethod, requestType, sendData, resultHandlers) {
        var apiUrl = webApiPrefix + apiController + "/" + apiMethod;

        $.ajax({
            type: requestType,
            url: apiUrl,            
            data: JSON.stringify(sendData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                resultHandlers.onSuccess(data);
            },
            error: function (xhr, status, error) {
                if (resultHandlers.onError) {
                    resultHandlers.onError(xhr, status, error);
                }
            },
            complete: function (jqXHR, textStatus) {
                if (resultHandlers.onComplete) {
                    resultHandlers.onComplete(jqXHR, textStatus);
                }
            }
        });
    };

    var dal = {

        ajaxPost(apiController, apiMethod, sendData, resultHandler) {
            _ajaxRequest(DL.WebApiPrefix, apiController, apiMethod, "POST", sendData, resultHandler);
        },

        ajaxGet(controller, apiMethod, sendData, resultHandler) {
            _ajaxRequest(DL.WebApiPrefix, controller, apiMethod, "GET", sendData, resultHandler);
        },
    };

    return dal;

}());

DL.WebApiPrefix = "api/";