
function validateForm() {
    var x = document.forms["myForm"]["txt_regUser"].value;
    if (x.length > 12 || x.length < 6) {
        document.getElementById("checkuser").innerHTML = "lenght (6-12) character";
        document.getElementById("checkuser").style.color = 'red';
        return false;
    } else {
        document.getElementById("checkuser").innerHTML = "User name(*)";
        document.getElementById("checkuser").style.color = 'black';
    }
    var pw1 = document.forms["myForm"]["txt_rePassword"].value;
    var pw2 = document.forms["myForm"]["txt_rePassword2"].value;
    if (pw1.length < 8 || pw1.length > 12) {
        document.getElementById("pw").innerHTML = "lenght (8-12) character";
        document.getElementById("pw").style.color = 'red';
        return false;
    } else {
        document.getElementById("pw").innerHTML = "Password(*)";
        document.getElementById("pw").style.color = 'black';
    }
    if (pw1 != pw2) {
        document.getElementById("pw").innerHTML = "the password is'nt mask to other";
        document.getElementById("pw2").innerHTML = "the password is'nt mask to other";
        document.getElementById("pw").style.color = 'red';
        document.getElementById("pw2").style.color = 'red';
        return false;
    } else {
        document.getElementById("pw").innerHTML = "Password(*)";
        document.getElementById("pw2").innerHTML = "Nhập lại Password(*)";
        document.getElementById("pw").style.color = 'black';
        document.getElementById("pw2").style.color = 'black';
    }
    ValidateEmail(inputText(document.myForm.text1.value));
    return false;
}
