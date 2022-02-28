$('#imgshow').css('background-color', 'blue')
$('#imgshows button').click(function (e) {
    $(this).parent('div').remove();
})