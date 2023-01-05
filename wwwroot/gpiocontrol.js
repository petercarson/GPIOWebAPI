$(function () {
  $.ajax({
    url: "/api/gpio",
    method: "GET",
    crossDomain: true,
    headers: {
      "accept": "application/json;odata=verbose"
    },
    success: function (data) {
      data.forEach((element) => {
        if (element.value == 0) {
          $("#" + element.id).css("background-color", "green");
        }
        else {
          $("#" + element.id).css("background-color", "");
        }
      });
    },
    error: function (err) {
      alert("Error");
    }
  });

  $.ajax({
    url: "/enable",
    method: "GET",
    crossDomain: true,
    headers: {
      "accept": "application/json;odata=verbose"
    },
    success: function (data) {
        if (data) {
          $("#0").css("background-color", "green");
        }
        else {
          $("#0").css("background-color", "");
        }
    },
    error: function (err) {
      alert("Error");
    }
  });

   $(".btn-gpio").click(function () {
    var id = $(this).attr('id').replace(/ /g, "%20");
    var url = "/api/gpio/" + id

    var test = $(this).css("background-color");
    if (test == "rgb(0, 128, 0)") {
      url += "/on"
      $(this).css("background-color", "");
      $(this).css("color", "");
    }
    else {
      url += "/off"
      $(this).css("background-color", "green");
      $(this).css("color", "white");
    }

    $.ajax({
      url: url,
      method: "GET",
      crossDomain: true,
      headers: {
        "accept": "application/json;odata=verbose"
      },
      success: function (data) {
      },
      error: function (err) {
        alert("Error");
      }
    });
  });

  $(".btn-heating-enabled").click(function () {
    var url = "/enable"
    var test = $(this).css("background-color");
    if (test == "rgb(0, 128, 0)") {
      url += "/off"
      $(this).css("background-color", "");
      $(this).css("color", "");
    }
    else {
      url += "/on"
      $(this).css("background-color", "green");
      $(this).css("color", "white");
    }

    $.ajax({
      url: url,
      method: "GET",
      crossDomain: true,
      headers: {
        "accept": "application/json;odata=verbose"
      },
      success: function (data) {
      },
      error: function (err) {
        alert("Error");
      }
    });
  });
});