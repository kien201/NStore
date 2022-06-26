// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

var lineChartReport;
function RenderChartReport(inputType, inputValue) {
    $.ajax({
        url: "/Admin/ChartReport/RenderChart",
        data: { inputType, inputValue },
        method: "POST",
        success: function (result) {
            // Area Chart Example
            var ctx = document.getElementById("areaChartReport");
            if (lineChartReport != null) {
                lineChartReport.destroy();
                console.log(lineChartReport)
            }
            lineChartReport = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: result.arrLabel,
                    datasets: [
                        {
                            label: "Doanh thu",
                            lineTension: 0.3,
                            backgroundColor: "rgba(2,117,216,0.2)",
                            borderColor: "rgba(2,117,216,1)",
                            pointRadius: 5,
                            pointBackgroundColor: "rgba(2,117,216,1)",
                            pointBorderColor: "rgba(255,255,255,0.8)",
                            pointHoverRadius: 5,
                            pointHoverBackgroundColor: "rgba(2,117,216,1)",
                            pointHitRadius: 50,
                            pointBorderWidth: 2,
                            data: result.arrData
                        }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            gridLines: {
                                display: false
                            },
                            ticks: {
                                maxTicksLimit: 12
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                min: 0,
                                max: Math.max(...result.arrData) > 0 ? Math.max(...result.arrData) : 5000,
                                maxTicksLimit: 10
                            },
                            gridLines: {
                                color: "rgba(0, 0, 0, .125)",
                            }
                        }],
                    }
                }
            });
        },
        error: function (err) {
            alert("lỗi load biểu đồ", err.responseText);
        }
    })
}