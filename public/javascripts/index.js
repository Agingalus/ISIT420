
function RecordOfSales(pStoreID, pSalesPersonID, pCdID, pPricePaid) {
    this.StoreID = pStoreID;
    this.SalesPersonID = pSalesPersonID;
    this.CdID = pCdID;
    this.PricePaid = pPricePaid;
}
var ClientNotes = [];  // our local copy of the cloud data


document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("submit").addEventListener("click", function () {
        var tStoreID = document.getElementById("addStoreID").value;
        var tSalesPersonID = document.getElementById("addSalesPersonID").value;
        var tCdID = document.getElementById("addCdID").value;
        var tPricePaid = document.getElementById("addPricePaid").value;
        var oneRecordOfSales = new RecordOfSales(parseInt(tStoreID), parseInt(tSalesPersonID), parseInt(tCdID), parseInt(tPricePaid));

        $.ajax({
            url: '/NewRecordOfSales',
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(oneRecordOfSales),
            success: function (result) {
                console.log("added new record of sales")
                // updateList();
            }

        });
    });

    document.getElementById("get").addEventListener("click", function () {
        updateList()
    });



});


function compare(a, b) {
    if (a.title > b.title) {
        return -1;
    }
    return 1;
}
