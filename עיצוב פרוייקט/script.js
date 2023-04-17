function AddDriver() {
    //שליפת השם לשליחה
    let userName = document.querySelector("#userName").value;
    let password = document.querySelector("#password").value;
    let id = document.querySelector("#id").value;
    let firstName = document.querySelector("#firstName").value;
    let lastName = document.querySelector("#lastName").value;
    let gender = document.querySelector("#gender").value;
    let age = document.querySelector("#age").value;
    let city = document.querySelector("#city").value;
    let adress = document.querySelector("#adress").value;
    let phone = document.querySelector("#phone").value;
    let mail = document.querySelector("#mail").value;

    let company = document.querySelector("#company").value;
    let year = document.querySelector("#year").value;
    let numOfChairs = document.querySelector("#numOfChairs").value;
    let aboutCar = document.querySelector("#aboutCar").value;

    //תמונה חסר 

    let sexPass = document.querySelector("#genderPass").value;
    let agePass = document.querySelector("#agePass").value;
    let MinMaxAge = agePass.split("-");
    let area = document.querySelector("#area").value;
    let morePreferences = document.querySelector("#morePreferences").value;

    if (area == "צפון")
        area = 0;
    else if (area == "מרכז")
        area = 1;
    else if (area == "דרום")
        area = 2;

    localStorage.setItem("id", "" + id.value);
    localStorage.setItem("pass", "" + password.value);


    //יצירת קריאה חדשה
    let req = new XMLHttpRequest();
    //פתיחת קריאה חדשה - סוג וכתובת
    req.open('get', 'https://localhost:44356/api/user/GetAddNewDriver/' + userName + '/' + password + '/' + id + '/' + firstName + '/' + lastName + '/' + gender + '/' + age
        + '/' + adress + '/' + city + '/' + phone + '/' + mail + '/' + company + '/' + year + '/' + numOfChairs + '/' + aboutCar + '/' + sexPass + '/' + MinMaxAge[0] + '/' + MinMaxAge[1] + '/' + area + '/' + morePreferences, true);
    //שליחת הבקשה
    req.send();
    //req.responseText קבלת התשובה למשתנה
    req.onload = function () {
        //הדפסת התשובה על המסך
        document.getElementById("count").innerHTML = req.responseText;
    }
}

function AddPasseger() {
    //שליפת השם לשליחה
    let userName = document.querySelector("#userName").value;
    let password = document.querySelector("#password").value;
    let id = document.querySelector("#id").value;
    let firstName = document.querySelector("#firstName").value;
    let lastName = document.querySelector("#lastName").value;
    let sex = document.querySelector("#sex").value;
    let age = document.querySelector("#age").value;
    let city = document.querySelector("#city").value;
    let adress = document.querySelector("#adress").value;
    let phone = document.querySelector("#phone").value;
    let mail = document.querySelector("#mail").value;
    // let forever = document.querySelector("#forever").value;

    localStorage.setItem("id", "" + id);


    //יצירת קריאה חדשה
    let req = new XMLHttpRequest();
    //פתיחת קריאה חדשה - סוג וכתובת
    req.open('get', 'https://localhost:44356/api/user/GetAddNewPassenger/' + userName + '/' + password + '/' + id + '/' + firstName + '/' + lastName + '/' + sex + '/' + age + '/' + city + '/' + adress + '/' + phone + '/' + mail, true);
    //שליחת הבקשה
    req.send();
    //req.responseText קבלת התשובה למשתנה
    req.onload = function () {
        //הדפסת התשובה על המסך
        document.getElementById("passen").innerHTML = req.responseText;
    }
}

//כרטיס הוספת נסיעה
function TravelCard() {
    document.getElementById('formMain').style.display = 'block'
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/car/GetDetailsOfCar/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        car = JSON.parse(req.response);
        document.querySelector("#chairs").value = car.NumOfChairs - 1;
    }
}

//הוספת נסיעה
function Travel() {
    let exit = document.querySelector("#exit").value;
    let Destination = document.querySelector("#Destination").value;
    let startDay = document.querySelector("#startDay").value;
    let endDay = document.querySelector("#endDay").value;
    let time = document.querySelector("#time").value;
    let chairs = document.querySelector("#chairs").value;
    let price = document.querySelector("#price").value;

    var target = new Date("1970-01-01T" + time);
    target.getHours()
    target.getMinutes()


    let currentpass = localStorage.getItem("pass")
    let req = new XMLHttpRequest();
    let url = 'https://localhost:44356/api/travel/GetAddNewTravel/' + exit + '/' + Destination + '/' + startDay + '/' + endDay + '/' + target.getHours()
        + '/' + target.getMinutes() + '/' + '00' + '/' + chairs + '/' + price + '/' + currentpass;
    req.open('get', encodeURI(url), true);

    req.send();
    req.onload = function () {
        document.getElementById("sacsses").innerHTML = req.responseText;

    }
}



//מחיקת נסיעה
function deleteTravel() {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetDeleteTravel/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        document.getElementById("myModal").style.display = "none";
        document.getElementById("updateData").style.display = "block";

        myFunction("מעבד נתונים...");
        let t = setInterval(() => {
            myFunction("הנסיעה נמחקה בהצלחה ונשלחה הודעה לנוסעים..");



            document.getElementById("AllTravels1").innerHTML = "";

            ShowAllMyTravels();
            document.getElementById("updateData").style.display = "none";

            clearInterval(t)
        }, 3200)
    }
}

function detailsOfTravel() {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetdetailsOfTravel/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        let travel = JSON.parse(req.response);
        document.querySelector("#exit").value = travel.Exit;
        document.querySelector("#Destination").value = travel.Destination;
        let d = travel.startDayAndHour.substring(0, 10);
        document.querySelector("#startDayAndHour").value = d;
        let t = travel.Time.substring(0, 5);
        document.querySelector("#time").value = t;
        //    document.querySelector("#endDay").value = travel.endDay;
        document.querySelector("#numOfChirs").value = travel.numOfChirs;
        document.querySelector("#Price").value = travel.Price;
    }
}

//עדכון פרטי נסיעה
function updateTravel() {
    let exit = document.querySelector("#exit").value;
    let Destination = document.querySelector("#Destination").value;
    let startDay = document.querySelector("#startDayAndHour").value;
    //let endDay = document.querySelector("#endDay").value;
    let time = document.querySelector("#time").value;
    let chairs = document.querySelector("#numOfChirs").value;
    let price = document.querySelector("#Price").value;
    var target = new Date("1970-01-01T" + time);
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetUpdateDetailsOfTravel/' + exit + '/' + Destination + '/' + startDay + '/' + startDay + '/' + target.getHours() + '/' + target.getMinutes() + '/00/' + chairs + '/' + price + '/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        closeNav1();
        // location.reload();

        document.getElementById("updateData").style.display = "block";

        myFunction("מעבד נתונים...");
        let t = setInterval(() => {
            myFunction("פרטי הנסיעה עודכנו בהצלחה..");
            document.getElementById("AllTravels1").innerHTML = "";

            ShowAllMyTravels();
            document.getElementById("updateData").style.display = "none";
            clearInterval(t)

        }, 3200)
    }
}

//שליפת מצטרפי נסיעה מסוימת
function Joiners(idTravel) {


    localStorage.setItem("idTravel", "" + idTravel);
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetJoinersToTravel/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        TravelsJoiners = JSON.parse(req.response);
        let join = document.getElementById("allJoiners");
        for (let i = 0; i < TravelsJoiners.length; i++) {
            let p = document.createElement('p')
            p.setAttribute('class', 'joiner');
            let bold = document.createElement('label');
            bold.setAttribute('class', 'bold');
            bold.innerHTML = "שם:"
            p.appendChild(bold);
            p.innerHTML += `${TravelsJoiners[i].UserName}<br>`;
            bold.innerHTML = "גיל:"
            p.appendChild(bold);
            let year = new Date().getFullYear();
            //  - TravelsJoiners[i].Age;
            // p.innerHTML += `${TravelsJoiners[i].Age}<br>`;
            p.innerHTML += year - TravelsJoiners[i].Age + "<br>";
            bold.innerHTML = "טלפון:"
            p.appendChild(bold);
            p.innerHTML += `${TravelsJoiners[i].Phone}<br>`;
            // p.innerHTML = `${TravelsJoiners[i].UserName} בן ${TravelsJoiners[i].Age} <br> טלפון: ${TravelsJoiners[i].Phone}`;
            join.appendChild(p);
        }
    }
}

// function Preference() {
//     let sex = document.querySelector("#Sex").value;
//     let age = document.querySelector("#Age").value;
//     let area = document.querySelector("#Area").value;
//     let currentId = localStorage.getItem("id")
//     let req = new XMLHttpRequest();
//     req.open('get', 'https://localhost:44356/api/preferences/GetAddPreferences/' + sex + '/' + age + '/' + area + '/' + currentId, true);
//     req.send();
//     req.onload = function () {
//         document.getElementById("sacsses2").innerHTML = req.responseText;

//     }
// }


//התחברות


function CheckPass() {

    let userName = document.querySelector("#usrnm").value;
    let password = document.querySelector("#psw").value;
    if (password.length != 7 && password != "") {
        document.querySelector("#seven").style.display = "block";
        return;
    }
    document.querySelector("#seven").style.display = "none";
    if (userName != "" && password != "")
        document.getElementById('spin').style.display = "block";
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetCheckPassword/' + userName + '/' + password, true);
    req.send();
    req.onload = function () {
        let person = req.responseText.substring(1, req.responseText.length - 1);
        let person1 = person.split("$");
        if (person1[0] == "driver") {
            localStorage.setItem("pass", "" + password);
            localStorage.setItem("idDriver", "" + person1[1]);
            window.location.href = "driver.html";


        }

        else if (person1[0] == "passenger") {
            localStorage.setItem("pass", "" + password);
            localStorage.setItem("idPassenger", "" + person1[1]);
            window.location.href = "passengers.html";
        }

        else {
            document.getElementById('spin').style.display = "none";
            document.getElementById("error").innerHTML = req.responseText.substring(1, req.response.length - 1);
        }

    }
}

//יציאה מהחשבון
function exit() {
    // localStorage.setItem("pass", "");
    localStorage.clear();
    window.location.href = "index.html";
}


// שליפת שם המשתמש לאיזור האישי  
function GetUserName() {
    // let x=localStorage.getItem("pass")
    // if(x==null)
    // document.getElementById('id01').style.display='block';
    // else
    // {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetUserName/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        let name = req.responseText.substring(1, req.responseText.length - 1);
        let name1 = name.split("$");
        document.querySelector("#userName").innerHTML = "שלום " + name1[0];
        // localStorage.setItem("idPassenger", "" + name1[1]);
    }
    // }

}


//שליפת פרטי המשתמש לאיזור האישי
function GetDetailsOfPerson() {
    let currentpass = localStorage.getItem("pass")
    //יצירת קריאה חדשה
    let req = new XMLHttpRequest();
    //פתיחת קריאה חדשה - סוג וכתובת
    req.open('get', 'https://localhost:44356/api/user/GetDetailsOfPerson/' + currentpass, true);
    //שליחת הבקשה
    req.send();
    //req.responseText קבלת התשובה למשתנה
    req.onload = function () {
        person = JSON.parse(req.response);

        document.querySelector("#userName").innerHTML = "שלום " + person.UserName;
        document.querySelector("#UserName").value = person.UserName;
        document.querySelector("#NewPassword").value = person.Password;
        document.querySelector("#firstName").value = person.FirstName;
        document.querySelector("#lastName").value = person.LastName;
        document.querySelector("#city").value = person.City;
        document.querySelector("#adress").value = person.Adress;
        document.querySelector("#phone").value = person.Phone;
        document.querySelector("#mail").value = person.Mail;

    }
}

//עדכון פרטים אישיים
function UpdatePersonDetails() {
    let userName = document.querySelector("#UserName").value;
    let NewPassword = document.querySelector("#NewPassword").value;
    let firstName = document.querySelector("#firstName").value;
    let lastName = document.querySelector("#lastName").value;
    let city = document.querySelector("#city").value;
    let adress = document.querySelector("#adress").value;
    let phone = document.querySelector("#phone").value;
    let mail = document.querySelector("#mail").value;
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetUpdateDetails/' + userName + '/' + NewPassword + '/' + firstName + '/' + lastName + '/' + adress + '/' + city + '/' + phone + '/' + mail + '/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        localStorage.setItem("pass", "" + NewPassword);
        document.getElementById("update").innerHTML = req.responseText;

    }
}

//שליפת פרטי העדפות לאיזור האישי
function GetDetailsPreferences() {
    GetUserName();
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/preferences/GetDetailsPreferences/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        preference = JSON.parse(req.response);
        document.querySelector("#Gender").value = preference.Gender;
        document.querySelector("#AgeGender").value = preference.MinAge + '-' + preference.MaxAge;
        switch (preference.Area) {
            case 0: document.querySelector("#area").value = "צפון"
                break;
            case 1: document.querySelector("#area").value = "מרכז"
                break;
            case 2: document.querySelector("#area").value = "דרום"
                break;
        }
        document.querySelector("#MorePreferences").value = preference.MorePreference;

    }
}

//עדכון פרטי העדפות
function AddPreferences() {
    // closeNav1();
    let gender = document.querySelector("#Gender").value;
    let agePass = document.querySelector("#AgeGender").value;
    let area = document.querySelector("#area").value;
    const MinMaxAge = agePass.split("-");
    if (area == "צפון")
        area = 0;
    else if (area == "מרכז")
        area = 1;
    else if (area == "דרום")
        area = 2;
    let morePreference = document.querySelector("#MorePreferences").value;
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/preferences/GetAddPreferences/' + gender + '/' + MinMaxAge[0] + '/' + MinMaxAge[1] + '/' + '/' + area + '/' + morePreference + '/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        document.getElementById("update").innerHTML = req.responseText;

    }
}


//שליפת פרטי רכב לאיזור האישי
function GetDetailsOfCar() {
    GetUserName();
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/car/GetDetailsOfCar/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        car = JSON.parse(req.response);
        document.querySelector("#company").value = car.Company;
        document.querySelector("#yearOfCreate").value = car.DateOfCreature;
        document.querySelector("#numOfChairs").value = car.NumOfChairs;
        document.querySelector("#discribe").value = car.StateTheCar;

    }
}


//עדכון פרטי רכב
function UpdateCar() {
    let company = document.querySelector("#company").value;
    let yearOfCreate = document.querySelector("#yearOfCreate").value;
    let numOfChairs = document.querySelector("#numOfChairs").value;
    let discribe = document.querySelector("#discribe").value;
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/car/GetUpdateCar/' + company + '/' + yearOfCreate + '/' + numOfChairs + '/' + discribe + '/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {

        document.getElementById("update").innerHTML = req.responseText;

    }
}

// נהג - שליפת כל הנסיעות שלי

async function ShowAllMyTravels() {
    GetUserName();
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetAllTravelsDriver/' + localStorage.getItem("pass"), true);
    req.send();
    req.onload = function () {
        Travels = JSON.parse(req.response);
        console.log(Travels);
        let AllTravels = document.createElement('div');
        AllTravels.setAttribute('class', 'travels');
        for (let i = 0; i < Travels.length; i++) {
            let travel = document.createElement('div');
            travel.setAttribute('class', 'travel');
            travel.setAttribute('id', `${Travels[i].Id}`);

            let bold = document.createElement('label');
            bold.setAttribute('class', 'bold');

            let p = document.createElement('p');
            let h5 = document.createElement('h5');
            // h5.innerHTML = `קוד נסיעה:  ${Travels[i].Id}`;
            // p.appendChild(h5);
            bold.innerHTML = '<br>מסלול:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Exit} - ${Travels[i].Destination} <br>
            `;
            bold.innerHTML = ' תאריך:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].startDayAndHour.substring(0, 10)}<br>`;
            bold.innerHTML = ' שעה:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Time}<br>`;
            bold.innerHTML = ' מס מקומות פנויים:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].numOfChirs} <br>`;
            bold.innerHTML = ' עלות לנוסע:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Price} שקלים<br>`;

            let btns = document.createElement('div');
            btns.setAttribute('class', 'btns');

            let img1 = document.createElement('img')
            img1.setAttribute('class', 'delete');
            img1.setAttribute('id', 'delete1');
            img1.setAttribute('src', 'assets/Trash-02-WF.svg')
            img1.setAttribute('title', 'מחיקת נסיעה')
            img1.onclick = function () { del(Travels[i].Id) };
            //  img1.addEventListener('click', del);
            btns.appendChild(img1)

            let img = document.createElement('img')
            img.setAttribute('class', 'join');
            img.setAttribute('src', 'assets/Business-Man-Search.svg')
            img.setAttribute('title', 'צפיה בפרטי המצטרפים')
            img.addEventListener('click', openNav);
            img.onclick = function () { Joiners(Travels[i].Id) };
            btns.appendChild(img)


            let img2 = document.createElement('img')
            img2.setAttribute('class', 'update');
            img2.setAttribute('src', 'assets/File\ Edit-WF.svg')
            img2.setAttribute('title', 'עדכון פרטי נסיעה')
            //  img2.addEventListener('click', openNav1);
            img2.onclick = function () { openNav1(Travels[i].Id) };
            btns.appendChild(img2)
            p.appendChild(btns);


            // let img3 = document.createElement('div')
            // img3.setAttribute('class', 'message');
            // img3.innerHTML="שליחת הודעה"
            // p.appendChild(img3);

            travel.appendChild(p);
            AllTravels.appendChild(travel);
        }
        document.querySelector("#AllTravels1").appendChild(AllTravels);
    }
}


//נוסע שולף את כל הנסיעות שלו
async function ShowAllPassengerTravels() {
    GetUserName();
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetAllTravelsPassenger/' + localStorage.getItem("idPassenger"), true);
    req.send();
    req.onload = function () {
        // document.getElementsByClassName("details").style.display = "none";
        // document.getElementById("update").style.display = "none";
        Travels = JSON.parse(req.response);
        console.log(Travels);
        let AllTravels = document.createElement('div');
        AllTravels.setAttribute('class', 'travels');
        for (let i = 0; i < Travels.length; i++) {
            let travel = document.createElement('div');
            travel.setAttribute('class', 'travel');
            travel.setAttribute('id', `${Travels[i].Id}`);

            let bold = document.createElement('label');
            bold.setAttribute('class', 'bold');

            let p = document.createElement('p');
            let h5 = document.createElement('h5');
            // h5.innerHTML = `קוד נסיעה:  ${Travels[i].Id}`;
            // p.appendChild(h5);
            bold.innerHTML = '<br>מסלול:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Exit} - ${Travels[i].Destination} <br>
            `;
            bold.innerHTML = ' תאריך:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].startDayAndHour.substring(0, 10)}<br>`;
            bold.innerHTML = ' שעה:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Time}<br>`;
            // bold.innerHTML = ' מס מקומות פנויים:';
            // p.appendChild(bold);
            // p.innerHTML += `  ${Travels[i].numOfChirs} <br>`;
            bold.innerHTML = ' עלות:';
            p.appendChild(bold);
            p.innerHTML += `  ${Travels[i].Price} שקלים<br>`;

            // bold.innerHTML = 'שם הנהג: '
            // p.appendChild(bold);
            // let name = GetDriverNameAndPhone(Travels[i].Id);
            // p.innerHTML += name;

            let btns = document.createElement('div');
            btns.setAttribute('class', 'btns');

            let img1 = document.createElement('img')
            img1.setAttribute('class', 'delete');
            img1.setAttribute('id', 'delete1');
            img1.setAttribute('src', 'assets/Delete-WF.svg')
            img1.setAttribute('title', 'ביטול הצטרפות לנסיעה')
            img1.onclick = function () { del(Travels[i].Id) };
            //  img1.addEventListener('click', del);
            btns.appendChild(img1)

            // let img = document.createElement('img')
            // img.setAttribute('class', 'join');
            // img.setAttribute('src', 'assets/Business-Man-Search.svg')
            // img.setAttribute('title', 'צפיה בפרטי המצטרפים')
            // img.addEventListener('click', openNav);
            // img.onclick = function () { Joiners(Travels[i].Id) };
            // btns.appendChild(img)


            // let img2 = document.createElement('img')
            // img2.setAttribute('class', 'update');
            // img2.setAttribute('src', 'assets/File\ Edit-WF.svg')
            // img2.setAttribute('title', 'עדכון פרטי נסיעה')
            // //  img2.addEventListener('click', openNav1);
            // img2.onclick = function () { openNav1(Travels[i].Id) };
            // btns.appendChild(img2)
            p.appendChild(btns);
            travel.appendChild(p);
            AllTravels.appendChild(travel);
        }
        document.querySelector("#AllTravels1").appendChild(AllTravels);
    }
}

function del(idTravel) {
    localStorage.setItem("idTravel", "" + idTravel);
    document.getElementById("myModal").style.display = "block";
}


//שליפת שם הנהג
function GetDriverName(idTravel, i) {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetDriverName/' + idTravel, true);
    req.send();
    req.onload = function () {
        let name = req.responseText.substring(1, req.responseText.length - 1);
        document.querySelector(`#name${i}`).innerHTML = name;
    }
}




// מחפש נסיעות
function GetSearchTravels() {
    let date = document.querySelector("#date").value;
    let exit = document.querySelector("#city").value;
    let Destination = document.querySelector("#city1").value;
    // let childs = document.getElementsByClassName("travels");
    document.querySelector("#travelsAll").innerHTML = ""
    // document.querySelector("#travelsAll").removeChild(childs);

    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetSearchTravels/' + exit + ',' + Destination + ',' + date + '/' + localStorage.getItem('pass'), true);
    req.send();
    req.onload = function () {

        let travels = JSON.parse(req.response)
        let AllTravels = document.createElement('div');
        AllTravels.setAttribute('class', 'travels');
        for (let i = 0; i < travels.length; i++) {
            let travel = document.createElement('div');
            travel.setAttribute('class', 'travel');
            travel.setAttribute('id', `${travels[i].Id}`);

            let car = document.createElement('div');
            car.setAttribute('class', 'imgCar');
            let img1 = document.createElement('img');
            img1.setAttribute('class', 'carImg');
            img1.src = "assets/rav4-r45-970px.jpg";
            car.appendChild(img1);
            let details = document.createElement('div');
            details.setAttribute('class', 'detail');

            let p = document.createElement('p');
            let h5 = document.createElement('h5');
            h5.setAttribute('id', `name${i}`);
            // h5.innerHTML = "" + GetDriverName(travels[i].Id);
            GetDriverName(travels[i].Id, i)
            p.appendChild(h5);
            let img = document.createElement('img');
            img.setAttribute('class', 'icon');
            img.src = "assets/Road.svg";
            p.appendChild(img);
            p.innerHTML += `${travels[i].Exit} - ${travels[i].Destination} <br>
            `;
            img.src = "assets/Calendar01-WF.png";
            // img.src = "assets/Date.svg";
            p.appendChild(img);
            p.innerHTML += `${travels[i].startDayAndHour.substring(0, 10)} <br>`;
            img.src = "assets/Minute1-WF.svg";
            p.appendChild(img);
            p.innerHTML += `${travels[i].Time}<br>`;
            img.src = "assets/Israeli-New Shekel.svg";
            p.appendChild(img);
            p.innerHTML += ` ${travels[i].Price} שקלים`
            // p.innerHTML += `נסיעה מ${travels[i].Exit} ל${travels[i].Destination} <br> בתאריך ${travels[i].startDayAndHour.substring(0, 10)} בשעה ${travels[i].Time}<br> בעלות ${travels[i].Price} שקלים`
            details.appendChild(p);

            let btn = document.createElement('button');
            btn.setAttribute('class', 'joining');
            btn.innerHTML = "🧡 הצטרפות "
            btn.onclick = function () { BeforWontJoin(travels[i].Id) };
            details.appendChild(btn);
            travel.appendChild(car);
            travel.appendChild(details);
            AllTravels.appendChild(travel);

        }
        // document.getElementById("update").innerHTML = req.responseText;
        document.querySelector("#travelsAll").appendChild(AllTravels);
    }
}

function cancelTextRequest() {
    document.querySelector("#text1").value = "";
    document.getElementById('request').style.display = 'none';
    document.querySelector("#loader").style.display = "none";
    document.querySelector("#check").style.display = "none";
}


//בדיקה אם הנהג כבר הצטרף לנסיעה זו
function BeforWontJoin(idTravel) {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetIfJoin/' + idTravel + '/' + localStorage.getItem("idPassenger"), true);
    req.send();
    req.onload = function () {

        if (req.response == 0)
            wontJoin(idTravel);
        else
            alert("אין אפשרות לבצע הצטרפות פעם נוספת")
    }
}

//נוסע רוצה להצטרף
function wontJoin(idTravel) {
    localStorage.setItem("idTravel", "" + idTravel);
    document.querySelector("#okey").style.display = "block";
    document.getElementById("myModal").style.display = "block";
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetPreference/' + idTravel, true);
    req.send();
    req.onload = function () {
        // driver = JSON.parse(req.response)
        // console.log(req.response);
        document.querySelector("#Preferences").innerHTML = "הנהג מעדיף:     " + req.response.substring(1, req.response.length - 1);
    }
}


//נוסע רוצה לשלוח בקשה לנהג מסוי
//שליפת id של הנהג לאחסון המקומי
function GetIdDriver() {
    document.getElementById('request').style.display = 'block';
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetIdDriver/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        id = req.response.substring(1, req.response.length - 1)
        localStorage.setItem("WhoDriverOfTravel", id)
    }
}


//שליחת בקשה לנהג
function sendRequest() {
    let text1 = document.querySelector("#text1").value;
    document.getElementById("request").style.display = 'none'
    document.querySelector("#text1").value = "";
    document.querySelector("#loader").style.display = "block";

    let t = setInterval(() => {
        let req = new XMLHttpRequest();
        req.open('get', 'https://localhost:44356/api/travel/GetAddMassage/' + localStorage.getItem("WhoDriverOfTravel") + "/" + localStorage.getItem("idPassenger") + "/" + text1 + "/" + false, true);
        req.send();
        req.onload = function () {
            document.querySelector("#loader").style.display = "none";
            document.querySelector("#check").style.display = "block";
            // document.getElementById("myModal").style.display = 'none'
        }
        clearInterval(t)
        // cancel();
    }, 4000)

}

// כאן אולי אני אוציא מהאחסון המקומי

//הצטרפות לנסיעה 
function JoinToTravel() {
    document.querySelector("#loader").style.display = "block";

    let t = setInterval(() => {
        let req = new XMLHttpRequest();
        req.open('get', 'https://localhost:44356/api/user/GetJoinToTravel/' + localStorage.getItem('pass') + '/' + localStorage.getItem("idTravel"), true);
        req.send();
        req.onload = function () {
            document.querySelector("#loader").style.display = "none";
            document.querySelector("#check").style.display = "block";
            document.querySelector("#okey").style.display = "none";
        }
        clearInterval(t)
        // cancel();
    }, 3200)


}

//נוסע מבטל הצטרפות לנסיעה
function GetCancelGoiner() {
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/user/GetCancelGoiner/' + localStorage.getItem('idPassenger') + '/' + localStorage.getItem("idTravel"), true);
    req.send();
    req.onload = function () {
        document.getElementById("myModal").style.display = "none";
        document.getElementById("updateData").style.display = "block";
        myFunction("מעבד נתונים...");
        let t = setInterval(() => {
            myFunction("ביטלת בהצלחה את הצטרפותך לנסיעה");
            document.getElementById("AllTravels1").innerHTML = "";

            ShowAllPassengerTravels();
            document.getElementById("updateData").style.display = "none";

            clearInterval(t)
        }, 3200)
    }
}
//localStorage.clear();

// function openForm() {
//     document.getElementById("myForm").innerHTML = "block";
// }

// function closeForm() {
//     document.getElementById("myForm").style.display = "none";
// }



//נהגים ונוסעים שולפים הודעות שלהם   
function GetAllMyMessage(id, status) {
    GetUserName();
    let req = new XMLHttpRequest();
    req.open('get', 'https://localhost:44356/api/travel/GetAllMyMessage/' + id + '/' + status, true);
    req.send();
    req.onload = function () {
        messages = JSON.parse(req.response);
        let AllMessages = document.createElement('div');

        // for (let i = 0; i < messages.length; i++) {
        //     let currentMessage = messages[i].split("^");
        //     let message = document.createElement('div');
        //     message.setAttribute('class', 'message');
        //     let p = document.createElement('p');
        //     // p.innerHTML = `${messages[i].MessageText} <br> <br> ${messages[i].Time}`;
        //     p.innerHTML = currentMessage[0];
        //     message.appendChild(p);
        //     let p1 = document.createElement('p');
        //     p1.innerHTML = currentMessage[1];
        //     message.appendChild(p1);
        //     let p2 = document.createElement('p');
        //     p2.innerHTML = currentMessage[2];
        //     message.appendChild(p2);
        //     AllMessages.appendChild(message);
        // }

        for (let i = 0; i < messages.length; i++) {
            let currentMessage = messages[i].split("^");
            let message = document.createElement('div');
            message.setAttribute('class', 'chip');
            let img = document.createElement('img');
            img.setAttribute('class', 'prophil')
            img.src = "assets/השכרת-רכב-נתבג-4.3.jpg";
            img.width = "96";
            img.height = "96";
            img.alt = "person"
            let bold = document.createElement('label');
            bold.setAttribute('class', 'bold');
            let p = document.createElement('p');
            bold.innerHTML = currentMessage[0];
            p.appendChild(bold);
            p.innerHTML += "      " + currentMessage[1] + "  -------------- " + currentMessage[2];
            p.appendChild(img);
            message.appendChild(p);
            AllMessages.appendChild(message);
        }
        document.querySelector("#AllMyGetMessages").appendChild(AllMessages);
    }
}


//פונקציה חיצונית שנהג רוצה הודעות יוצאות שלו
function GetAllMyGiveMessage() {
    GetAllMyMessage(localStorage.getItem('idDriver'), true);
}

//פונקציה חיצונית שנהג רוצה הודעות נכנסות שלו
function GetAllMyGetMessage() {
    GetAllMyMessage(localStorage.getItem('idDriver'), false);
}


//פונקציה חיצונית שנוסע רוצה הודעות יוצאות שלו
function GetAllPassGiveMessage() {
    GetAllMyMessage(localStorage.getItem('idPassenger'), false);
}

//פונקציה חיצונית שנוסע רוצה הודעות נכנסות שלו
function GetAllPassGetMessage() {
    GetAllMyMessage(localStorage.getItem('idPassenger'), true);
}






// var myNodelist = document.getElementsByClassName("LI");
// var i;
// for (i = 0; i < myNodelist.length; i++) {
//     var span = document.createElement("SPAN");
//     var txt = document.createTextNode("\u00D7");
//     span.className = "close";
//     span.appendChild(txt);
//     myNodelist[i].appendChild(span);
// }

// Click on a close button to hide the current list item
// var close = document.getElementsByClassName("close");
// var i;
// for (i = 0; i < close.length; i++) {
//     close[i].onclick = function () {
//         var div = this.parentElement;
//         div.style.display = "none";
//     }
// }

// Add a "checked" symbol when clicking on a list item
// var list = document.querySelector('ul');
// list.addEventListener('click', function (ev) {
//     if (ev.target.tagName === 'LI') {
//         ev.target.classList.toggle('checked');
//     }
// }, false);

// Create a new list item when clicking on the "Add" button
// function newElement() {
//     var li = document.createElement("li");
//     var inputValue = document.getElementById("myInput").value;
//     var t = document.createTextNode(inputValue);
//     li.appendChild(t);
//     if (inputValue === '') {
//         alert("You must write something!");
//     } else {
//         document.getElementById("myUL").appendChild(li);
//     }
//     document.getElementById("myInput").value = "";

//     var span = document.createElement("SPAN");
//     var txt = document.createTextNode("\u00D7");
//     span.className = "close";
//     span.appendChild(txt);
//     li.appendChild(span);

//     for (i = 0; i < close.length; i++) {
//         close[i].onclick = function () {
//             var div = this.parentElement;
//             div.style.display = "none";
//         }
//     }
// }
