/***************** Model Layer  *****************/
var MODEL = {};

$(document).ready(function () {
    (function () {

        MODEL = $.extend(
            MODEL,
            (function (dataLayer) {
                var Dictionaries_Class = function () {
                    var dictionaries = {};                   

                    //--- Art Movements --------
                    dictionaries["ArtMovements"] = [
                        //{ ID: , Caption: "" },
                        { ID: 1, Caption: "Renaissance" },
                        { ID: 2, Caption: "Baroque and Rococo" },
                        { ID: 3, Caption: "Italian Impressionism" }
                    ];
                    
                    /*this.getDictionary = function (dictionaryName, callBack) {
                        var result;

                        switch (dictionaryName) {                            
                            case "ArtMovements":
                                result = dictionaries["ArtMovements"];
                                break;
                            case "Painters":                                
                                result = dictionaries["Painters"];
                                break;                            
                            default:
                                result = null;
                                break;
                        }

                        return result;
                    }*/

                }
            })(DL)
        );
        
    }());
});
