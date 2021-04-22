var express = require('express');
var router = express.Router();

// mongoose is a API wrapper overtop of mongodb, just like
// .ADO.Net is a wrapper over raw SQL server interface
const mongoose = require("mongoose");

const RecordOfSales = require("../RecordOfSale");

// edited to include my non-admin, user level account and PW on mongo atlas
// and also to include the name of the mongo DB that the collection
const dbURI =
  "mongodb+srv://BCStudent:BCStudent@cluster0.gdypt.mongodb.net/recordsOfSales?retryWrites=true&w=majority";

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
router.get('/', function (req, res) {
  res.sendFile('index.html');
});

/* GET all recordOfSales */
router.get('/RecordOfSales', function (req, res) {
  // find {  takes values, but leaving it blank gets all}
  RecordOfSales.find({}, (err, AllRecordOfSales) => {
    if (err) {
      console.log(err);
      res.status(500).send(err);
    }
    res.status(200).json(AllRecordOfSales);
  });
});

//banana


/* post a new recordOfSales and push to Mongo */
router.post('/NewRecordOfSales', function (req, res) {

  let oneNewrecordOfSales = new RecordOfSales(req.body);  // call constuctor in recordOfSales code that makes a new mongo recordOfSales object
  console.log(req.body);
  oneNewrecordOfSales.save((err, recordOfSales) => {
    if (err) {
      res.status(500).send(err);
    }
    else {
      console.log(recordOfSales);
      res.status(201).json(recordOfSales);
    }
  });
});


module.exports = router;
