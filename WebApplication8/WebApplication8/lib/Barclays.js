function ShowTransactionResult(result) {
    ShowResult("TransactionStatus", result.status);
    ShowResult("TransactionStatusName", result.statusName);

    ShowResult("Alias", result.alias);
    ShowResult("CardNumber", result.cardNumber);
    ShowResult("ExpiryDate", result.expiryDate);
    ShowResult("CardholderName", result.cardholderName);
}

function ShowResult(elementName, elementValue) {
    parent.document.getElementById(elementName).value = elementValue;
}