{
    var lan = 35.699739;
    var lon = 51.338097;
    var address = "";
    //init the map
    var myMap = new L.Map('map', {
        key: 'web.0672d81da5734d0f8f35ce7beb9637f2',
        maptype: 'dreamy',
        poi: true,
        traffic: false,
        center: [lan, lon],
        zoom: 25,

    });
    var marker = L.marker([35.699739, 51.338097]).addTo(myMap);
    myMap.on('click', function (data) {
        console.log("click");
        console.log(data);
        console.log(data.latlng.lat);
        ReverseGeocoding(data.latlng.lat, data.latlng.lng);
        marker.setLatLng([data.latlng.lat, data.latlng.lng]);
        marker.bindPopup(address).openPopup();
        //set map center to address
        myMap.flyTo([lat, lng], 15);

    });

    function ReverseGeocoding(lat, lng) {
        console.log("reverse");
        var url = `https://api.neshan.org/v5/reverse?lat=${lat}&lng=${lng}`;
        var params = {
            headers: {
                'Api-Key': 'service.92d0b5a1cd814d78adfce4df575293e8'
            },

        };
        $.ajax({
            url: url,
            headers: params.headers,
            datatype: "json",
            type: "GET",
            success: function (data) {

                console.log(data);
                console.log(data['formatted_address']);
                console.log(data['status']);
                address = data['formatted_address'];
            }
        });

    }

    //sending request to Geocoding API
    async function geocoding() {
        var log = document.getElementById("log");
        //getting adrress value from input tag
        var addresswrite = document.getElementById("address").value;
        //making url 
        var url = `https://api.neshan.org/v4/geocoding?address=${addresswrite}`;
        console.log(url);
        //add your api key
        var params = {
            headers: {
                'Api-Key': 'service.92d0b5a1cd814d78adfce4df575293e8'
            },

        };
        alert(url + params.headers["Api-Key"]);

        $.ajax({
            url: url,
            headers: params.headers,
            datatype: "json",
            type: "GET",
            success: function (data) {
                console.log(data);
                console.log(data['location']['x']);
                console.log(data['location']['y']);
                marker.setLatLng([data['location']['y'], data['location']['x']]);
                marker.bindPopup(addresswrite).openPopup();
                //set map center to address
                myMap.flyTo([data['location']['y'], data['location']['x']], 15);

            }
        });


    }
}
