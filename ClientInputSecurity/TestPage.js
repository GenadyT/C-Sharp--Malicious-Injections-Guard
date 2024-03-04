function submit_OnClick() {
    var painterData = {};
    painterData.ID = parseInt($("#painterID").val());
    if (!Number.isInteger(painterData.ID)) {
        painterData.ID = 0;
    }

    painterData.Name = $("#painterName").val();

    painterData.MovementID = parseInt($("#artMovementId").val());
    if (!Number.isInteger(painterData.MovementID)) {
        painterData.MovementID = 0;
    }

    painterData.InternetInfoLink = $("#infoLink").val();
    painterData.MyComments = $("#myCommentsElem").val();    

    var resultTextElem = $("#resultText");
    resultTextElem.removeClass("report-malicious-text");
    resultTextElem.html("just a minute ..");

    var onSuccess = function (respondData) {
        var isMalicious = respondData.IsMalicious;
        //var maliciousDescription = respondData.MaliciousDescription.replace(/(\r\n|\r|\n)/g, '&#13;&#10;');
        var maliciousDescription = respondData.MaliciousDescription.replace(/(\r\n|\r|\n)/g, '<br>');        

        //resultTextElem.text(maliciousDescription);
        resultTextElem.html(maliciousDescription);

        if (isMalicious) {
            resultTextElem.addClass("report-malicious-text");
        }
    };

    var onError = function (respondData) {
        alert(respondData);
    };

    MODEL.PainterDataSupplier.insertPainter(painterData, onSuccess, onError);
}

$(document).ready(function () {    
    $('#artMovementId').val($('#artMovementIds').val());    
    $('#artMovementIds').on('change', function () {
        $('#artMovementId').val(this.value);
    });
});

