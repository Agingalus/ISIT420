
function Movie(pTitle, pGenre, pReleaseYear) {
    this.title= pTitle;
    this.genre = pGenre;
    this.releaseYear = pReleaseYear;
  }
  var ClientNotes = [];  // our local copy of the cloud data


document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("submit").addEventListener("click", function () {
        var tTitle = document.getElementById("addtitle").value;
        var tGenre = document.getElementById("addgenre").value;
        var tReleaseYear = document.getElementById("addreleaseYear").value;
        var oneMovie = new Movie(tTitle, tGenre, parseInt(tReleaseYear));

        $.ajax({
            url: '/NewMovie' ,
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(oneMovie),
            success: function (result) {
                console.log("added new movie")
                updateList();
            }

        });
    });

    document.getElementById("get").addEventListener("click", function () {
        updateList()
    });
  


    document.getElementById("delete").addEventListener("click", function () {
        
        var whichMovie = document.getElementById('deleteTitle').value;
        var idToDelete = "";
        for(i=0; i< ClientNotes.length; i++){
            if(ClientNotes[i].title === whichMovie) {
                idToDelete = ClientNotes[i]._id;
           }
        }
        
        if(idToDelete != "")
        {
                     $.ajax({  
                    url: 'DeleteMovie/'+ idToDelete,
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
        var oneMovie = new Movie(tTitle, tGenre, parseInt(tReleaseYear));
       
        
            $.ajax({
                url: 'UpdateMovie/'+idToFind,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(oneMovie),
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
        for(i=0; i< ClientNotes.length; i++){
            if(ClientNotes[i].title === tTitle) {
                idToFind = ClientNotes[i]._id;
           }
        }
        console.log(idToFind);
 
        $.get("/FindMovie/"+ idToFind, function(data, status){ 
            console.log(data[0].title);
            document.getElementById("mtitle").value = data[0].title;
            document.getElementById("mgenre").value= data[0].genre;
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

$.get("/Movies", function(data, status){  // AJAX get
    ClientNotes = data;  // put the returned server json data into our local array

    // sort array by one property
    ClientNotes.sort(compare);  // see compare method below
    console.log(data);
    //listDiv.appendChild(ul);
    ClientNotes.forEach(ProcessOneMovie); // build one li for each item in array
    function ProcessOneMovie(item, index) {
        var li = document.createElement('li');
        ul.appendChild(li);

        li.innerHTML=li.innerHTML + (index + 1) + ": " + " Title: " + item.title + ", Genre: " + item.genre + ", Release Year: " + item.releaseYear;
    }
});
}

function compare(a,b) {
    if (a.title > b.title) {
        return -1;
    }
    return 1;
}
