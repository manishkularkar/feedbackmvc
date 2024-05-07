
$(document).ready(function () {
    getallfeedbackEntities();
    redirectdetails();
});
var savefeedbackfrom = function () {

    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var contact = $("#txtContact").val();
    var city = $("#txtCity").val();
    var email = $("#txtEmail").val();
    var feedback1 = $("#txtFeedback1").val();
   
    model = {
        Id: id,
        Name: name,
        Contact: contact,
        City: city,
        Email: email,
        Feedback1: feedback1
    }

    debugger;

    $.ajax({
        url: "/feedbackfrom/savefeedbackfrom",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            getallfeedbackEntities();
        },
        Error: function (response) {
            alert(response.Message);
        }
    });
}

var getallfeedbackEntities = function () {
    $.ajax({
        url: "/feedbackfrom/Getlist",
        method: "post",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            var html = "";
            $("#feedback tbody").empty();
            $.each(response.model, function (index, elementvalue) {
                html += "<tr><td>" + elementvalue.Id +
                    "</td><td>" + elementvalue.Name +
                    "</td><td>" + elementvalue.Contact +
                    "</td><td>" + elementvalue.City +
                    "</td><td>" + elementvalue.Email +
                    "</td><td>" + elementvalue.Feedback1 +
                    "</td><td> <button type='button'class='btn btn-danger' onclick='deletefeedback(" + elementvalue.Id + ")'>Delete</button></td><td> <button type='button'class='btn btn-primary' onclick='geteditbyId(" + elementvalue.Id + ")'>Edit</button></td><td> <button type='button'class='btn btn-info' onclick='Details(" + elementvalue.Id + ")'>Details</button></td></tr>";
            });
            $("#feedback tbody").append(html);
        }
    })
}


var deletefeedback = function (Id) {
    var model = { Id: Id };
    debugger;
    $.ajax({
        url: "/feedbackfrom/deletefeedback",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert(responce.Message);
            getallfeedbackEntities();
        }
    });
}
geteditbyId = function (Id) {
    var model = { Id: Id };
    debugger;
    $.ajax({
        url: "/feedbackfrom/geteditbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response)
        {
            $("#hdnId").val(response.Message.Id);
            $("#txtName").val(response.Message.Name);
            $("#txtContact").val(response.Message.Contact);
            $("#txtCity").val(response.Message.City);
            $("#txtEmail").val(response.Message.Email);
            $("#txtFeedback1").val(response.Message.Feedback1);

        }
    });
} 
Details = function (Id) {
    window.location.href = "/feedbackfrom/DetailsIndex?Id=" + Id;
}
redirectdetails = function () {
    var Id = $("#hdnId").val();
    var model = { Id: Id };
    debugger;
    $.ajax({
        url: "/feedbackfrom/geteditbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            $("#hdnId").text(responce.Message.Id);
            $("#txtName").text(responce.Message.Name);
            $("#txtContact").text(responce.Message.Contact);
            $("#txtCity").text(responce.Message.City);
            $("#txtEmail").text(responce.Message.Email);
            $("#txtFeedback1").text(responce.Message.Feedback1);

        }
    });
}

