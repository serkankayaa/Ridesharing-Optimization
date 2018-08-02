<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="ManhattanMap.WebForm1" %>

<!doctype html>
<html>
<head>
        <title>Manhattan Traffic Simulation</title>
        <link rel="icon" type="image/png" href="https://image.ibb.co/m0K4Cn/5873.png">
        <link href="mapStyle.css" rel="stylesheet"/>
        <script type="text/javascript"
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDeAFvqD3fG4TprSdoamMnqRhy-1ug4AP0"&"libraries=visualization>
        </script>
        <script>
              var RRCount = <%=ListBoxRX1.Items.Count%>;
              var RVCount = <%=ListBoxVX.Items.Count%>;
              var Request1XArray = (<%=getRequest1XArray()%>);
              var Request1YArray = (<%=getRequest1YArray()%>);
              var Request2XArray = (<%=getRequest2XArray()%>);
              var Request2YArray = (<%=getRequest2YArray()%>);
              var VehicleX = (<%=getVehicleXArray()%>);
              var VehicleY = (<%=getVehicleYArray()%>);
              var RequestX = (<%=getRequestXArray()%>);
              var RequestY = (<%=getRequestYArray()%>);
        </script>
        <script type="text/javascript">
                var map;

                var SimLineCoordinates = [
                    [40.754695, -73.990372], [40.75081, -73.98285],
                    [40.811046, -73.957951], [40.799313, -73.933014],
                    [40.710814, -74.009212], [40.724236, -73.997795],
                    [40.762548, -73.974371], [40.76716, -73.98391]
                ];

                function addAnimatedPolyline() {
                    var pointCount = SimLineCoordinates.length;
                    var linePath = [];
                    for (var i = 0; i < pointCount; i++) {
                        var tempLatLng = new google.maps.LatLng(SimLineCoordinates[i][0], SimLineCoordinates[i][1]);
                        linePath.push(tempLatLng);
                    }
                    var arrowSymbol = {
                        strokeColor: '#000',
                        scale: 3,
                        path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW
                    };

                    var lineOptions = {
                        path: linePath,
                        icons: [{
                            icon: arrowSymbol
                            //offset: '100%'
                        }],
                        strokeWeight: 3,
                        strokeColor: '#FF0000',
                        strokeOpacity: 0.8
                    }
                    polyline = new google.maps.Polyline(lineOptions);
                    polyline.setMap(map);
                    animateArrow();
                }

                function animateArrow() {
                    var counter = 0;
                    var accessVar = window.setInterval(function () {
                        counter = (counter + 1) % 100;
                        var arrows = polyline.get('icons');
                        arrows[0].offset = (counter / 2) + '%';
                        polyline.set('icons', arrows);
                    }, 20);
                }

                for (var i = 0; i < RRCount; i++)
                {
                    var DrawRRCoordinates = [
                        [Request1XArray[i], Request1YArray[i]], [Request2XArray[i], Request2YArray[i]],
                    ];
                }
                for (var i = 0; i < RVCount; i++)
                {
                    var DrawRVCoordinates = [
                        [VehicleX[i], VehicleY[i], RequestX[i], RequestY[i]],
                    ];
                }
                
                function addRequestRequestLine()
                {
                      var pointCount = DrawRRCoordinates.length;
                      var linePath = [];
                      for (var i = 0; i < RRCount; i++)
                      {
                          addRequest({ lat: Number(Request1XArray[i]), lng: Number(Request1YArray[i]) });                          
                      }
                      for (var i = 0; i < 23; i++)
                      {
                          var tempLatLng = new google.maps.LatLng(Request1XArray[i], Request1YArray[i]);
                          linePath.push(tempLatLng);
                      }
                      var lineOptions = {
                          path: linePath,
                          strokeWeight: 3,
                          strokeColor: '#FF0000',
                          strokeOpacity: 0.8
                      }
                      var drawRR = new google.maps.Polyline(lineOptions);
                      drawRR.setMap(map);
                }
                function addRequestVehicleLine()
                {
                        var pointCount = DrawRVCoordinates.length;
                        var linePathRV1 = [];
                        var linePathRV2 = [];
                        for (var i = 0; i < RVCount; i++)
                        {
                                addVehicle({ lat: Number(VehicleX[i]), lng: Number(VehicleY[i]) });
                                addRequest({ lat: Number(RequestX[i]), lng: Number(RequestY[i]) });
                        }
                        for (var i = 0; i < 23; i++) {
                            var tempLatLngRV1 = new google.maps.LatLng(VehicleX[i], VehicleY[i]);
                            var tempLatLngRV2 = new google.maps.LatLng(RequestX[i], RequestY[i]);

                            linePathRV1.push(tempLatLngRV1);
                            linePathRV2.push(tempLatLngRV2);
                        }
                        var lineOptionsRV1 = {
                                path: linePathRV1,
                                strokeWeight: 3,
                                strokeColor: '#0000ff',
                                strokeOpacity: 0.8
                        }
                        var lineOptionsRV2 = {
                            path: linePathRV2,
                            strokeWeight: 3,
                            strokeColor: '#0000ff',
                            strokeOpacity: 0.8
                        }
                        var drawRV1 = new google.maps.Polyline(lineOptionsRV1);
                        var drawRV2 = new google.maps.Polyline(lineOptionsRV2);

                        drawRV1.setMap(map);
                        drawRV2.setMap(map);
                }
                
                function initMap()
                {
                        google.maps.visualRefresh = true;
                        var mapOptions = {
                              center: new google.maps.LatLng(40.823647, -73.943855),
                              zoom: 12,
                              mapTypeId: google.maps.MapTypeId.ROADMAP
                        };

                        var mapElement = document.getElementById('mapDiv');

                        map = new google.maps.Map(mapElement, mapOptions);
                        startButtonEvents();
                        
                }
                function clearMap()
                {
                    initMap();
                }
                
                function addRequest(coordinateRequest)
                {
                    
                    var requestSymbol = new google.maps.Marker(
                        {
                            position:coordinateRequest,
                            map:map,
                            icon:'https://image.ibb.co/h69w7n/request_symbol.png',
                        }
                    );
                }
                function addVehicle(coordinateVehicle)
                {
                    var vehicleSymbol = new google.maps.Marker(
                        {
                            position:coordinateVehicle,
                            map:map,
                            icon:'https://image.ibb.co/ecpk07/vehicle_symbol.png',
                        }
                    )
                }
                function startButtonEvents()
                {
                    document.getElementById('btnSim').addEventListener('click', function () {
                        addAnimatedPolyline();
                    }); 
                    document.getElementById('btnClear').addEventListener('click', function () {
                        clearMap();
                    }); 
                    document.getElementById('btnRV').addEventListener('click', function ()
                    {
                        addRequestVehicleLine();
                    });   
                    document.getElementById('btnRR').addEventListener('click', function ()
                    {
                        addRequestRequestLine();
                    });   
                    document.getElementById('btnRoad').addEventListener('click', function ()
                    {
                        map.setMapTypeId(google.maps.MapTypeId.ROADMAP);
                    });
                    document.getElementById('btnSat').addEventListener('click', function ()
                    {
                        map.setMapTypeId(google.maps.MapTypeId.SATELLITE);
                    });
                    document.getElementById('btnHyb').addEventListener('click', function ()
                    {
                        map.setMapTypeId(google.maps.MapTypeId.HYBRID);
                    });
                    document.getElementById('btnTer').addEventListener('click', function ()
                    {
                        map.setMapTypeId(google.maps.MapTypeId.TERRAIN);
                    });
                    document.getElementById('btnTra').addEventListener('click', function ()
                    {
                        var trafficLayer = new google.maps.TrafficLayer();
                        trafficLayer.setMap(map);
                    });

                }
                google.maps.event.addDomListener(window, 'load', initMap);
            </script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>Manhattan RideSharing</h1>
    <div id="mapDiv"></div>
    <div id="forms">
        <h3>Harita Katmanları</h3>
        <ul>
            <li><input id="btnRoad" type="button" value="RoadMap"></li>
            <li><input id="btnSat" type="button" value="Satellite"></li>
            <li><input id="btnHyb" type="button" value="Hybrid"></li>
            <li><input id="btnTer" type="button" value="Terrain"></li>
            <li><input id="btnTra" type="button" value="Traffic Katmanı"></li>
        </ul>
        
    </div>
        <h3>Graphlar</h3>
        
        <input id="btnRR" type="button" value="RR Çalıştır" runat="server">
        <input id="btnRV" type="button" value="RV Çalıştır">
        <input id="btnClear" type="button" value="Temizle"><h3>Simülasyon</h3>
        <input id="btnSim" type="button" value="Çalıştır"><br />
        <asp:TextBox ID="txtDataCor" runat="server"></asp:TextBox>
        <asp:ListBox ID="ListBoxVX" runat="server" Width="141px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxVY" runat="server" Width="142px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxRY2" runat="server" Width="143px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxRX2" runat="server" Width="142px" Visible="False"></asp:ListBox>

        <asp:ListBox ID="ListBoxRX1" runat="server" Width="189px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxRY1" runat="server" Width="147px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxRX" runat="server" Width="141px" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBoxRY" runat="server" Width="138px" Visible="False"></asp:ListBox>
        
    </form>
    
</body>
</html>
