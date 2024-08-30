/*------------------------Checks-----------------------------*/
var hasError = false;
var cntDrones = 0;
function LoginClearFields() {
    document.getElementById("errorUserName").innerHTML = " ";
    document.getElementById("errorPass1").innerHTML = " ";
    document.getElementById("txtUserName").value = "";
    document.getElementById("Pass1").value = "";
}
function sendData() {
    CheckUserName();
    CheckLastName();
    CheckPass1();
    CheckPhoneNumber();
    CheckEmail();
    CheckGender();
    CheckBirthDay();
    chkTotDrones('');
    PersonalFlightTraining();
    CheckPayment();
    if (cntDrones == 0) {
        document.getElementById("errorDrone").innerHTML = "<b>חייב לבחור לפחות רחפן אחד</b>";
        hasError = true;
    }
    if (hasError) {
        alert("ישנם כמה בעיות בנתונים, תתקן אותם לפני השליחה!");
        hasError = false;
    }
    else {
        document.formname.submit();
    }
}
function clearFields() {
    document.getElementById("errorUserName").innerHTML = " ";
    document.getElementById("errorLastName").innerHTML = " ";
    document.getElementById("errorPass1").innerHTML = " ";
    document.getElementById("errorPass2").innerHTML = " ";
    document.getElementById("errorPhoneNumber").innerHTML = " ";
    document.getElementById("errorEmail").innerHTML = " ";
    document.getElementById("errorGender").innerHTML = " ";
    document.getElementById("errorBirthDay").innerHTML = " ";
    document.getElementById("errorDrone").innerHTML = " ";
    document.getElementById("errorPersonalFlightTraining").innerHTML = " ";
    document.getElementById("errorPayment").innerHTML = " ";
    
    document.getElementById("Sign_Login").reset();

}
function CheckUserName() {
    var str, len1, countN = 0, countL = 0;
    str = document.getElementById("txtUserName").value;
    len1 = str.length;
    if (str == "") {
        document.getElementById("errorUserName").innerHTML = "<b>חייב להכניס שם משתמש באנגלית</b>";
        hasError = true;
    }
    else {
        if (!(str[0] >= 'A' && str[0] <= 'Z')) {
            document.getElementById("errorUserName").innerHTML = "<b>חייב להיות אות גדולה בהתחלה</b>";
            hasError = true;
        }
        else {
            for (var i = 1; i < len1; i++) {
                if (str[i] >= '0' && str[i] <= '9')
                    countN++;
                else if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                    countL++;
            }
            if (countL + countN + 1 != len1) {
                document.getElementById("errorUserName").innerHTML = "<b>חייב להיות רק מספרים ואותיות באנגלית</b>";
                hasError = true;
            }
            else {
                if (len1 < 6) {
                    document.getElementById("errorUserName").innerHTML = "<b>חייב להיות לפחות 6 תווים</b>";
                    hasError = true;
                }
                else {
                    document.getElementById("errorUserName").innerHTML = "";
                    hasError = false;
                }
            }
        }
    }
}
function CheckLastName() {
    var str, len1, countN = 0, countL = 0;
    str = document.getElementById("txtLastName").value;
    len1 = str.length;
    if (str == "") {
        document.getElementById("errorLastName").innerHTML = "<b>חייב להכניס שם משפחה באנגלית</b>";
        hasError = true;
    }
    else {
        if (!(str[0] >= 'A' && str[0] <= 'Z')) {
            document.getElementById("errorLastName").innerHTML = "<b>חייב להיות עם אות גדולה בהתחלה</b>";
            hasError = true;
        }
        else {
            for (var i = 1; i < len1; i++) {
                if (str[i] >= '0' && str[i] <= '9')
                    countN++;
                else if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                    countL++;
            }
            if (countL + countN + 1 != len1) {
                document.getElementById("errorLastName").innerHTML = "<b>חייב להיות רק מספרים ואותיות באנגלית</b>";
                hasError = true;
            }
            else {
                document.getElementById("errorLastName").innerHTML = "";
                hasError = false;
            }
        }
    }
}
function CheckPass1() {
    var str, len1, countN = 0, countL = 0, countS = 0, countC = 0;
    str = document.getElementById("Pass1").value;
    len1 = str.length;
    if (str == "") {
        document.getElementById("errorPass1").innerHTML = "<b>חייב להכניס סיסמה</b>";
        hasError = true;
    }
    else {
        for (var i = 0; i < len1; i++) {
            if (str[i] >= '0' && str[i] <= '9') {
                countN++;
            } else if (str[i] >= 'a' && str[i] <= 'z') {
                countL++;
            } else if (str[i] >= 'A' && str[i] <= 'Z') {
                countC++;
            } else if (str[i].match(/[!@#$%^&*(),.?":{}|<>]/)) {
                countS++;
            }
        }
        if (countN < 1 || countL < 1 || countC < 1 || countS < 1) {
            document.getElementById("errorPass1").innerHTML = "<b>חייב לכלול לפחות אות אחת גדולה, אות קטנה, מספר ותו מיוחד</b>";
            hasError = true;
        } else {
            if (len1 < 6) {
                document.getElementById("errorPass1").innerHTML = "<b>חייב להיות לפחות 6 תווים</b>";
                hasError = true;
            } else {
                document.getElementById("errorPass1").innerHTML = "";
            }
        }
    }
    var pass2 = document.getElementById("Pass2").value;

    if (!(str == pass2)) {
        document.getElementById("errorPass2").innerHTML = "<b>הסיסמאות אינן תואמות</b>";
        hasError = true;
    } else {
        document.getElementById("errorPass2").innerHTML = "";
        hasError = false;
    }
}
function CheckPhoneNumber() {
    var str, len, reg;
    str = document.getElementById("PhoneNumber").value;
    len = str.length;
    var hasError = false;
    
    if (str == "") {
        document.getElementById("errorPhoneNumber").innerHTML = "<b>חייב להכניס מספר טלפון</b>";
        hasError = true;
    } else {
        if (!str.startsWith('+972')) {
            document.getElementById("errorPhoneNumber").innerHTML = "<b>+חייב להתחיל עם קידומת ישראלית (972)</b>";
            hasError = true;
        } else {
            var digitsOnly = str.replace(/\D/g, '');
            if (digitsOnly.length !== 12) {
                document.getElementById("errorPhoneNumber").innerHTML = "<b>חייב להזין 9 ספרות לאחר הקידומת</b>";
                hasError = true;
            } else {
                reg = /^\+972-\d{3}-\d{3}-\d{3}$/;
                if (!reg.test(str)) {
                    document.getElementById("errorPhoneNumber").innerHTML = "<b>חייב לשים מקף (-) בין כל שלוש ספרות</b>";
                    hasError = true;
                } else {
                    document.getElementById("errorPhoneNumber").innerHTML = "";
                    hasError = false;
                }
            }
        }
    }
}
function CheckEmail() {
    var str, len, reg, username;
    str = document.getElementById("Email").value;
    len = str.length;
    if (str == "") {
        document.getElementById("errorEmail").innerHTML = "<b>חייב להכניס אימייל</b>";
        hasError = true;
    }
    else {
        if (str.indexOf("@") == -1) {
            document.getElementById("errorEmail").innerHTML = "<b>חייב להכיל סימן שטרודל (@)</b>";
            hasError = true;
        } else {
            reg = /(gmail\.com|walla\.com)$/;
            if (!reg.test(str)) {
                document.getElementById("errorEmail").innerHTML = "<b>חייב להכיל סיומת gmail.com או walla.com</b>";
                hasError = true;
            } else {
                username = str.split("@");
                if (username[0] === "") {
                    document.getElementById("errorEmail").innerHTML = "<b>חייב להזין שם לפני הסימן שטרודל (@)</b>";
                    hasError = true;
                } else {
                    document.getElementById("errorEmail").innerHTML = "";
                    hasError = false;
                }
            }
        }
    }
}
function CheckGender() {
    if (!document.getElementById("male").checked && !document.getElementById("female").checked && !document.getElementById("other").checked) {
        document.getElementById("errorGender").innerHTML = "<b>חייב לבחור מגדר</b>";
        hasError = true;
    } else {
        document.getElementById("errorGender").innerHTML = "";
        hasError = false;
    }
}
function CheckBirthDay() {
    var strDate, strBirth, yearBirth, monthBirth, dayBirth, yearToday, monthToday, dayToday;
    strDate = new Date();
    strBirth = document.getElementById("BirthDay").value;
    yearBirth = parseInt(strBirth.substring(0, 4));
    monthBirth = parseInt(strBirth.substring(5, 7)) - 1;
    dayBirth = parseInt(strBirth.substring(8, 10));

    yearToday = strDate.getFullYear();
    monthToday = strDate.getMonth();
    dayToday = strDate.getDate();

    var age = yearToday - yearBirth;
    if (monthToday < monthBirth || (monthToday === monthBirth && dayToday < dayBirth)) {
        age--;
    }

    if (yearBirth > yearToday || (yearBirth === yearToday && (monthBirth > monthToday || (monthBirth === monthToday && dayBirth > dayToday)))) {
        document.getElementById("errorBirthDay").innerHTML = "<b>תאריך לידה אינו תקין</b>";
        hasError = true;
    } else if (!document.getElementById("BirthDay").value) {
        document.getElementById("errorBirthDay").innerHTML = "<b>חייב לבחור תאריך לידה</b>";
        hasError = true;
    } else if (age < 16) {
        document.getElementById("errorBirthDay").innerHTML = "<b>חייב להיות לפחות בן 16</b>";
        hasError = true;
    } else {
        document.getElementById("errorBirthDay").innerHTML = "";
        hasError = false;
    }
}
function chkTotDrones(tmpId) {
    if (tmpId != '') {
        if (document.getElementById(tmpId).checked == true)
            cntDrones += 1;
        else
            cntDrones -= 1;
    }

    if (cntDrones == 0) {
        document.getElementById("errorDrone").innerHTML = "<b>חייב לבחור לפחות רחפן אחד</b>";
        hasError = true;
    } else {
        document.getElementById("errorDrone").innerHTML = "";
        hasError = false;
    }
}
function PersonalFlightTraining() {
    var str;
    str = document.getElementById("personalFlightTraining").value;
    if (str == "") {
        document.getElementById("errorPersonalFlightTraining").innerHTML = "<b>חייב לבחור אימון טיסה</b>";
        hasError = true;
    } else {
        document.getElementById("errorPersonalFlightTraining").innerHTML = "";
        hasError = false;
    }
}
function CheckPayment() {
    var str;
    str = document.getElementById("Payment").value;
    if (str == "") {
        document.getElementById("errorPayment").innerHTML = "<b>חייב לבחור אופן תשלום</b>";
        hasError = true;
    } else {
        document.getElementById("errorPayment").innerHTML = "";
        hasError = false;
    }
}