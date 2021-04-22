
function RecordOfSales(pStoreID, pSalesPersonID, pCdID, pPricePaid) {
    this.StoreId = pStoreID;
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
                updateList();
            }

        });
    });

    document.getElementById("get").addEventListener("click", function () {
        updateList()
    });



    document.getElementById("delete").addEventListener("click", function () {

        var whichRecordOfSales = document.getElementById('deleteTitle').value;
        var idToDelete = "";
        for (i = 0; i < ClientNotes.length; i++) {
            if (ClientNotes[i].title === whichRecordOfSales) {
                idToDelete = ClientNotes[i]._id;
            }
        }

        if (idToDelete != "") {
            $.ajax({
                url: 'DeleteRecordOfSales/' + idToDelete,
                type: 'DELETE',
                contentType: 'application/json',
                success: function (response) {
                    console.log(response);
                    updateList();
                },
                error: function () {
                    console.log('Error in Operation');
                }
            });
        }
        else {
            console.log("no matching Subject");
        }
    });



    document.getElementById("msubmit").addEventListener("click", function () {
        var tTitle = document.getElementById("mtitle").value;
        var tGenre = document.getElementById("mgenre").value;
        var tReleaseYear = document.getElementById("mreleaseYear").value;
        var oneRecordOfSales = new RecordOfSales(tTitle, tGenre, parseInt(tReleaseYear));


        $.ajax({
            url: 'UpdateRecordOfSales/' + idToFind,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(oneRecordOfSales),
            success: function (response) {
                console.log(response);
                updateList();
            },
            error: function () {
                console.log('Error in Operation');
            }
        });


    });



    var idToFind = ""; // using the same value from the find operation for the modify
    // find one to modify
    document.getElementById("find").addEventListener("click", function () {
        var tTitle = document.getElementById("modTitle").value;
        idToFind = "";
        for (i = 0; i < ClientNotes.length; i++) {
            if (ClientNotes[i].title === tTitle) {
                idToFind = ClientNotes[i]._id;
            }
        }
        console.log(idToFind);

        $.get("/FindRecordOfSales/" + idToFind, function (data, status) {
            console.log(data[0].title);
            document.getElementById("mtitle").value = data[0].title;
            document.getElementById("mgenre").value = data[0].genre;
            document.getElementById("mreleaseYear").value = data[0].releaseYear;


        });
    });

    // get the server data into the local array
    updateList();

});


function updateList() {
    var ul = document.getElementById('listUl');
    ul.innerHTML = "";  // clears existing list so we don't duplicate old ones

    //var ul = document.createElement('ul')

    $.get("/RecordOfSales", function (data, status) {  // AJAX get
        ClientNotes = data;  // put the returned server json data into our local array

        // sort array by one property
        ClientNotes.sort(compare);  // see compare method below
        console.log(data);
        //listDiv.appendChild(ul);
        ClientNotes.forEach(ProcessOneRecordOfSales); // build one li for each item in array
        function ProcessOneRecordOfSales(item, index) {
            var li = document.createElement('li');
            ul.appendChild(li);

            li.innerHTML = li.innerHTML + (index + 1) + ": " + " Title: " + item.title + ", Genre: " + item.genre + ", Release Year: " + item.releaseYear;
        }
    });
}

function compare(a, b) {
    if (a.title > b.title) {
        return -1;
    }
    return 1;
}
