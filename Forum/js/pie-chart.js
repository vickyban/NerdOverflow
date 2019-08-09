//pie

window.onload = function () {



    var Categorybio = $("#hidBio").val();
    var Categorychem = $("#hidChem").val();
    var Categorymath = $("#hidMath").val();
    var Categorygeo = $("#hidGeo").val();
    var Categoryphysic = $("#hidPhysic").val();
    var CateOther = $("#hidOther").val();

    var ctxP = document.getElementById("pieChart").getContext('2d');
    var myPieChart = new Chart(ctxP, {
        type: 'pie',
        data: {
            labels: ["Bio", "Chem", "Maths", "Geo", "Other"],
            datasets: [{
                data: [Categorybio, Categorychem, Categorymath, Categorygeo, CateOther],
                backgroundColor: ["#F7464A", "#46BFBD", "#FDB45C", "#949FB1", "#4D5360"],
                hoverBackgroundColor: ["#FF5A5E", "#5AD3D1", "#FFC870", "#A8B3C5", "#616774"]
            }]
        },
        options: {
            responsive: true
        }
    });

}