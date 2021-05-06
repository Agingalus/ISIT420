var uri = 'api/store'

$(document).ready(function () {
    getEmployee();
    getStore();
    
});


function getEmployee() {
    $.getJSON(uri)
        .done(function (data) {
            console.log("uh oh");
            console.log(data);
            console.log($("#employees").children("option:selected").val());
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<option>', { text: item }).appendTo($('#employees'))
            })

        })
        .fail(function (data) {
            console.log("uh oh");
        });
                
}

function getStore() {
    $.getJSON('api/city')
        .done(function (data) {
            console.log(data);
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<option>', { text: item }).appendTo($('#stores'))
            })
        })
        .fail(function (data) {
            console.log("uh oh");
        });

}

function getMarkUps() {
    $.getJSON('api/markUp')
        .done(function (data) {
            console.log(data);
            $('#sales').empty();
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: item }).appendTo($('#sales'))
            })
        })
}

function getSpecificEmployee() {
    var lastName = $("#employees").children("option:selected").val();
    $.getJSON('api/store' + '/' + lastName)
        .done(function (data) {
            console.log(data);
            $('#employeeResult').empty();
            $('<p>', { text: `${lastName} sold $${data[0]} of goods.` }).appendTo($('#employeeResult'))

            
        });
}
function getTotalSalesForStore() {
    var cityName = $("#stores").children("option:selected").val();
    $.getJSON('api/city' + '/' + cityName)
        .done(function (data) {
            console.log(data);
            $('#storeResult').empty();
            $('<p>', { text: `The ${cityName} store sold $${data[0]} of goods.` }).appendTo($('#storeResult'))


        });
}