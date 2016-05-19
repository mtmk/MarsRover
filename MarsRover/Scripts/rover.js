$(function () {

    var positionRover = function(p) {
        $("#rover").css("left", (300 + (p.X * 10)) + "px");
        $("#rover").css("top", (210 - (p.Y * 10)) + "px");

        $("#coor").html("[" + p.X + "," + p.Y + "]");

        if (p.R === 0) {
            $("#rover").html("^");
        }
        if (p.R === 90) {
            $("#rover").html(">");
        }
        if (p.R === 180) {
            $("#rover").html("v");
        }
        if (p.R === 270) {
            $("#rover").html("<");
        }
    };

    $('.rover-command').click(function () {
        var msg = $(this).attr('value');
        console.log(msg);
        $.post("api/state", { message: msg }, function (data) {
            console.log(data);
            positionRover(data);
        });
    });

    $.get("api/state", function (data) {
        console.log(data);
        positionRover(data);
    });

});