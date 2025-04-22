function getLatLong() {
    var Lat = document.getElementById("Latitude").value;
    var Long = document.getElementById("Longitude").value;
    PrintLatLong(Lat, Long);
}


function PrintLatLong(value1, value2) {
    document.getElementById("output").innerText = "you entered " + value1 + " , " + value2 + ".";
}

