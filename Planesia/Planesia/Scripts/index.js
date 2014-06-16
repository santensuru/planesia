//Untuk JavaScript Galeri Foto

jQuery(document).ready(function ($) {
    var options = {
        $AutoPlay: true,
        $AutoPlayInterval: 4000,
        $SlideDuration: 500,
        $DragOrientation: 3,

        $ThumbnailNavigatorOptions: {
            $Class: $JssorThumbnailNavigator$,
            $ChanceToShow: 2,

            $Loop: 2,
            $SpacingX: 3,
            $SpacingY: 3,
            $DisplayPieces: 6,
            $ParkingPosition: 204,

            $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$,
                $ChanceToShow: 2,
                $AutoCenter: 2,
                $Steps: 6
            }
        }
    };

    var jssor_slider1 = new $JssorSlider$("slider1_container", options);

    function ScaleSlider() {
        var parentWidth = jssor_slider1.$Elmt.parentNode.clientWidth;
        if (parentWidth)
            jssor_slider1.$SetScaleWidth(Math.min(parentWidth, 720));
        else
            window.setTimeout(ScaleSlider, 30);
    }

    ScaleSlider();

    if (!navigator.userAgent.match(/(iPhone|iPod|iPad|BlackBerry|IEMobile)/)) {
        $(window).bind('resize', ScaleSlider);
    }

});

//Untuk JavaScript Galeri Foto
var map;
var isPlaced = false;
var marker = new google.maps.Marker();
var selectedPosition = new google.maps.LatLng();
$(document).ready(function () {
    initialize();
    function initialize() {
        var mapOptions =
        {
            zoom: 5,
            center: new google.maps.LatLng(-1, +118.75083),
            panControl: true,
            zoomControl: true,
            zoomControlOptions: {
                style: google.maps.ZoomControlStyle.SMALL
            },
            scaleControl: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        google.maps.event.addListener(map, 'click', function (event) {
            if (markerCount == 0) {
                placeMarker(event.latLng, map);
            }
        });
    }
});

function placeMarker(position, map) {
    var marker = new google.maps.Marker({
        position: position,
        map: map
    });
    markerCount++;
    var latLabel = document.getElementById('latitudel');
    var lngLabel = document.getElementById('longitudel');
    var latInp = document.getElementById('latitude');
    var lngInp = document.getElementById('longitude');
    latLabel.innerHTML = "Latitude Coordinate : " + position.lat();
    lngLabel.innerHTML = "Longitude Coordinate : " + position.lng();
    latInp.value = position.lat();
    lngInp.value = position.lng();
    map.panTo(position);
}