// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//SIGNUP BUTTON VALIDATION

//User/Index
//Disable the login button on page load.
$("#login-button").ready(function () {

    $("#login-button").attr("disabled", true);

})

//User/Index
//Keep the login button disabled as long as username and password field is empty
$(".login-input :input").keyup(function () {

    var emptyFieldCount = 0;

    $(".login-input :input").each(function () {

        if ($(this).val().length <= 0)
            emptyFieldCount++;

    })

    if (emptyFieldCount > 0)
        $("#login-button").attr("disabled", true);

    else
        $("#login-button").attr("disabled", false);

    emptyFieldCount = 0;

})

//User/Signup
//Disable the signup button on page load.
$("#signup-button").ready(function () {

    $("#signup-button").attr("disabled", true);

});

//User/Signup
//Keep the signup button disabled as long as any of the fields on the page are empty
$(".signup-input :input").keyup(function () {

    var emptyFieldCount = 0;

    $(".signup-input :input").each(function () {

        if ($(this).val().length <= 0)
            emptyFieldCount++;
    })

    if (emptyFieldCount > 0)
        $("#signup-button").attr("disabled", true);

    else
        $("#signup-button").attr("disabled", false);

    emptyFieldCount = 0;
});

//User/Signup
//Prevent the user from inputting letters in the zip code field.
$(".zipcode :input").on('keypress', function (e) {

    //Setup the regular expression
    var regex = new RegExp("^[0-9]*$");
    var key = String.fromCharCode(e.which);
    if (!regex.test(key)) {
        e.preventDefault();
        return false;
    }

});

//User/Signup
//Prevent the user from inputting whitespace and special characters in the first and last name fields
$("#users_FirstName, #users_LastName").on('keypress', function (e) {

    var regex = new RegExp("[^A-Za-z0-9]");
    var key = String.fromCharCode(e.which);
    if (regex.test(key)) {
        e.preventDefault();
        return false;
    }

})

//Checks validation on a field whenever it loses focus
$(".signup-input :input").focusout(function () {

    $(this).valid();

})

