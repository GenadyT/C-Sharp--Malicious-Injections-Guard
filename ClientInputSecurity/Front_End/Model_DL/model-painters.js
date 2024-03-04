(function () {
    MODEL = $.extend(
        MODEL,
        (function (dlLayer) {

            var PainterDataSupplier_Class = function (dlLayer, webApiControllerName) {
                this._dlLayer = dlLayer;
                this._webApiControllerName = webApiControllerName;
            };            

            PainterDataSupplier_Class.prototype.insertPainter = function (painterData, onSuccessHandler, onErrorHandler) {
                var requestParams = painterData;

                var eventHandlers = {
                    onSuccess: function (data) {
                        onSuccessHandler(data);
                    },
                    onError: function (jqXHR, textStatus, errorThrown) {
                        onErrorHandler(MESSAGES.SYSTEM_ERROR_MESSAGE + ', errorThrown=' + errorThrown);
                    },
                    onComplete: function (jqXHR, textStatus) {
                        return true;
                    }
                };

                //--- ajaxPost(controller, apiMethod, sendData, resultHandler) ---
                this._dlLayer.ajaxPost(this._webApiControllerName, "InsertPainter", requestParams, eventHandlers);
            }
             
            return {
                "PainterDataSupplier_Class": PainterDataSupplier_Class,
                "PainterDataSupplier": new PainterDataSupplier_Class(DL, "Painter")
            };
        })(DL)
    );
}());
