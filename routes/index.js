var express = require('express');
var router = express.Router();

// mongoose is a API wrapper overtop of mongodb, just like
// .ADO.Net is a wrapper over raw SQL server interface
const mongoose = require("mongoose");

const Movies = require("../Movies");

// edited to include my non-admin, user level account and PW on mongo atlas
// and also to include the name of the mongo DB that the collection
const dbURI = 
"mongodb+srv://BCStudent:BCStudent@cluster0.gdypt.mongodb.net/MovieDB?retryWrites=true&w=majority";

// Make Mongoose use `findOneAndUpdate()`. Note that this option is `true`
// by default, you need to set it to false.
mongoose.set('useFindAndModify', true);

const options = {
  reconnectTries: Number.MAX_VALUE,
  poolSize: 10
};

mongoose.connect(dbURI, options).then(
  () => {
    console.log("Database connection established!");
  },
  err => {
    console.log("Error connecting Database instance due to: ", err);
  }
);



/* GET home page. */
router.get('/', function(req, res) {
  res.sendFile('index.html');
});

/* GET all movies */
router.get('/Movies', function(req, res) {
  // find {  takes values, but leaving it blank gets all}
  Movies.find({}, (err, AllMovies) => {
    if (err) {
      console.log(err);
      res.status(500).send(err);
    }
    res.status(200).json(AllMovies);
  });
});




/* post a new movie and push to Mongo */
router.post('/NewMovie', function(req, res) {

    let oneNewMovie = new Movies(req.body);  // call constuctor in movies code that makes a new mongo movie object
    console.log(req.body);
    console.log("failing here");
    oneNewMovie.save((err, movies) => {
      if (err) {
        res.status(500).send(err);
      }
      else {
      console.log(movies);
      res.status(201).json(movies);
      }
    });
});


router.delete('/DeleteMovie/:id', function (req, res) {
  Movies.deleteOne({ _id: req.params.id }, (err, note) => { 
    if (err) {
      res.status(404).send(err);
    }
    res.status(200).json({ message: "Movie successfully deleted" });
  });
});


router.put('/UpdateMovie/:id', function (req, res) {
  Movies.findOneAndUpdate(
    { _id: req.params.id },
    { title: req.body.title, genre: req.body.genre, releaseYear: req.body.releaseYear },
   { new: true },
    (err, movie) => {
      if (err) {
        res.status(500).send(err);
    }
    res.status(200).json(movie);
    })
  });


  /* GET one movies */
router.get('/Findmovie/:id', function(req, res) {
  console.log(req.params.id );
  movies.find({ _id: req.params.id }, (err, onemovie) => {
    if (err) {
      console.log(err);
      res.status(500).send(err);
    }
    res.status(200).json(onemovie);
  });
});

module.exports = router;
