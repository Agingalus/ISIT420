
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
    document.getElementById("CreateEntry").addEventListener("click", function () {
        createNewEntry()
    });

    CreateEntry



});


function compare(a, b) {
    if (a.title > b.title) {
        return -1;
    }
    return 1;
}
let arrayOfZipCodes = [98053, 98007, 98077, 98055, 98011, 98046]
let arrayOfEmploees = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16], [17, 18, 19, 20], [21, 22, 23, 24]]
let arrayOfCdID = [123456, 123654, 321456, 321654, 654123,
    654321, 543216, 354126, 621453, 623451]
function createNewEntry() {
    let randomNumberForZip = Math.floor(Math.random() * arrayOfZipCodes.length);
    let randomNumberForEmploees = Math.floor(Math.random() * arrayOfEmploees[0].length);
    let randomNumberForCdID = Math.floor(Math.random() * arrayOfCdID.length);
    let randomNumeberforPricePaid = Math.floor(Math.random() * 11) + 5;

    document.getElementById("addStoreID").value = arrayOfZipCodes[randomNumberForZip];
    document.getElementById("addSalesPersonID").value = arrayOfEmploees[randomNumberForZip][randomNumberForEmploees];
    document.getElementById("addCdID").value = arrayOfCdID[randomNumberForCdID];
    document.getElementById("addPricePaid").value = randomNumeberforPricePaid;

}
