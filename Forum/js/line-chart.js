//line


    var jan = $("#hidJan").val();
    var feb = $("#hidFeb").val();
    var mar = $("#hidMar").val();
    var apr = $("#hidApr").val();
    var may = $("#hidMay").val();
    var jun = $("#hidJun").val();
    var jul = $("#hidJul").val();
    var aug = $("#hidAug").val();
    var sep = $("#hidSep").val();
    var oct = $("#hidOct").val();
    var nov = $("#hidNov").val();
    var dev = $("#hidDec").val();

    var ctxL = document.getElementById("lineChart").getContext('2d');
    var myLineChart = new Chart(ctxL, {
        type: 'line',
        data: {
            labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"],
            datasets: [{
                label: "Total Post",
                data: [jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dev],
                backgroundColor: [
                    'rgba(105, 0, 132, .2)',
                ],
                borderColor: [
                    'rgba(200, 99, 132, .7)',
                ],
                borderWidth: 2
            }
            ]
        },
        options: {
            responsive: true
        }
    });
