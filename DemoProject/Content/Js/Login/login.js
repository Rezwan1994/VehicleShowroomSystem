var DoLogIn = function () {
    var param = {
        "Email": $("#email").val(),
        "Password": $("#password").val()
    };
    $.ajax({
        type: "POST",
        ajaxStart: $(".loader-div").show(),
        url: "/Home/LoginAjax",
        data: JSON.stringify(param),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if (data.result == true) {
                window.location.href = "/success";
            }
            else {
                window.location.href = "/error";
            }
       
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Access denied");
        }
    });
};
var validation = {
    isEmail : function (email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    },
    isEmailEmpty: function (email) {
        if (email == '' || email == 'undefined') {
            return true;
        }
        else {
            return false;
        }
    },
    isPasswordEmpty: function (password) {
        if (password == '' || password == 'undefined') {
            return true;
        }
        else {
            return false;
        }
    }
}
var isEmail = function (email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
};
$(document).ready(function () {
    
    $("#Submit").click(function () {
        console.log("hlwww");
        if (validation.isEmailEmpty($("#email").val()) == false && validation.isPasswordEmpty($("#password").val()) == false) {
            if (validation.isEmail($("#email").val())) {
                DoLogIn();
            }
            else {
                $('#emailerror').addClass('hidden');
                $('#passerror').addClass('hidden');
                $('#emailvalidationerror').removeClass('hidden');
            }
        
        }
        else {
            $('#emailvalidationerror').addClass('hidden');
            if (validation.isEmailEmpty($("#email").val()) == true && validation.isPasswordEmpty($("#password").val()) == true) {
                $('#emailerror').removeClass('hidden');
                $('#passerror').removeClass('hidden');
            }
            else if (validation.isEmailEmpty($("#email").val()) == true) {
                $('#passerror').addClass('hidden');
                $('#emailerror').removeClass('hidden');
            }
            else if (validation.isEmailEmpty($("#password").val()) == true) {
                $('#emailerror').addClass('hidden');
                $('#passerror').removeClass('hidden');
            }
        }
      
    });
});