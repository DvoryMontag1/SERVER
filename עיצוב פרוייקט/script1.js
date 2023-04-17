// var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
// window.onclick = function (event) {
//     if (event.target == modal) {
//         modal.style.display = "none";
//     }
// }

function cancle() {
    document.getElementById('id01').style.display = "none";
    document.getElementById('sacsses3').innerHTML = "";
}

function Active() {

    document.querySelector('.active').setAttribute('class', 'notActive');

    this.setAttribute('class', 'active');
}

var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    }


    else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "שליחה";
        document.getElementById("nextBtn").addEventListener('click', AddDriver1);
    } else {
        document.getElementById("nextBtn").innerHTML = "הבא";
    }
    // ... and run a function that displays the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) return false;
    // if (n == 1 && currentTab == 2) {
    //     let i = checkIfPassConsist();
    //     if (i == 1)
    //         return;

    // }
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
    // if (currentTab >= x.length) {
    //...the form gets submitted:
    //     document.getElementById("regForm").submit();
    //     return false;
    // }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByClassName("notNULL");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false:
            valid = false;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class to the current step:
    x[n].className += " active";
}


function showImage(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.readAsDataURL(input.files[0]);
        reader.onload = function (e) {
            document.getElementById("imagePlace").innerHTML = ''

            let img = document.createElement('img')
            img.setAttribute('src', e.target.result)
            img.setAttribute('width', '200px')

            document.getElementById("imagePlace").appendChild(img)
            // $('#blah').attr('src', e.target.result).width(150).height(200);
        };
    }
}
// alert(document.getElementById('img').innerHTML)



//הוספת נסיעה
// Get the modal
// var modal = document.getElementById("myModal");

// Get the button that opens the modal
// var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
// var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal
// btn.onclick = function () {
//     modal.style.display = "block";
// }

// When the user clicks on <span> (x), close the modal
// span.onclick = function () {
//     modal.style.display = "none";
// }

// When the user clicks anywhere outside of the modal, close it
// window.onclick = function (event) {
//     if (event.target == modal) {
//         modal.style.display = "none";
//     }
// }


//בדיקה אם הסיסמה שהמצטרף רוצה להכניס כבר קיימת
function checkIfPassConsist() {
    let pass = document.querySelector("#password").value;
    if (pass.length != 7) {
        document.querySelector("#seven").style.display = "block";
        return
    }

    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetCheckIfPassConsist/' + pass, true);
    req.send();
    req.onload = function () {
        if (req.responseText == 1) {
            document.querySelector("#seven").style.display = "none";
            document.querySelector("#passConsist").style.display = "block";

        }
        else {
            document.querySelector("#seven").style.display = "none";
            document.querySelector("#passConsist").style.display = "none";
            return 0;
        }

    }
}


function AddDriver1() {

    document.getElementById("nextBtn").style.display = "none";
    document.getElementById("prevBtn").style.display = "none";
    AddDriver();
    document.getElementById("alert1").style.display = "block";
    setInterval(() => {
        setTimeout(() => {
            document.getElementById("alert1").style.display = "none";
            document.getElementById("alert2").style.display = "block";

        }, 600);
    }, 2500)

}


// function myFunction() {
//     var popup = document.getElementById("myPopup");
//     popup.classList.toggle("show");
//   }


function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementsByClassName("join").style = "border: 4px solid darkred";
}

function openNav1(idTravel) {
    localStorage.setItem("idTravel", "" + idTravel);
    document.getElementById("mySidenav1").style.width = "270px";
    detailsOfTravel();
    // document.getElementsByClassName("join").style = "border: 4px solid darkred";
}

function closeNav1() {
    document.getElementById("mySidenav1").style.width = "0";

}

/* Set the width of the side navigation to 0 */
function closeNav() {
    // let p = document.querySelectorAll("joiner");
    // for (let i = 0; i < p.length; i++) {
    //     document.getElementById("mySidenav").remove(p[i]);
    // }
    // document.getElementById("mySidenav").removeChild(document.getElementById("mySidenav").childNodes[2]);
    document.querySelector("#allJoiners").innerHTML=""
    document.getElementById("mySidenav").style.width = "0";

}


//סרגל ריצה
var i = 0;

function move() {
    if (i == 0) {
        i = 1;
        var elem = document.getElementById("myBar");
        var width = 1;
        var id = setInterval(frame, 10);
        function frame() {
            if (width >= 100) {
                clearInterval(id);
                i = 0;
            } else {
                width++;
                elem.style.width = width + "%";
            }
        }
    }
}

//הודעה לכמה שניות בתחתית העמוד

function myFunction(massege) {
    // Get the snackbar DIV
    document.getElementById("snackbar").innerHTML = massege;
    var x = document.getElementById("snackbar");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}


//הפוך כיוונים
function changDirections() {
    let temp = document.querySelector("#city").value;
    document.querySelector("#city").value = document.querySelector("#city1").value;
    document.querySelector("#city1").value = temp;
}


//נקוי הערכים
function clearDetails() {
    document.querySelector("#date").value = "";
    document.querySelector("#city").value = "";
    document.querySelector("#city1").value = "";
}


//בדיקה אם משהו קיים במערכת
function ifconsist() {
    if (localStorage.getItem("idDriver") != null) {
        document.querySelector("#toConnect").style.display = "none";
        document.querySelector("#toDriver").style.display = "block";
        document.querySelector("#exitfrom").style.display = "block";
    }
    else if (localStorage.getItem("idPassenger") != null) {
        document.querySelector("#toConnect").style.display = "none";
        document.querySelector("#toPassenger").style.display = "block";
        document.querySelector("#exitfrom").style.display = "block";
    }

}


function ifAlreadyConnect() {
    if (localStorage.getItem("idDriver") != null) {
        window.location.href = "personal.html"
    }
    else if (localStorage.getItem("idPassenger") != null) {
        window.location.href = "personalPass.html"
    }
    else
        // window.location.href = "id01";
        document.getElementById('id01').style.display = 'block'
}

