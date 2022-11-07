let drivers = [];
const baseUrl = "https://localhost:7255/api/drivers";
const body = document.getElementById("root");
let table = document.createElement("table");
table.className = 'table';
let thead = document.createElement("thead");
table.appendChild(thead);

function handleOnLoad() {
  createDriverTable();
}

async function createDriverTable() {
    const dirs = await fetch(baseUrl).then(r => r.json());
    drivers = dirs;
    createHeader();
    createBody();
//   fetch(baseUrl)
//     .then(function (response) {
//       console.log(response);
//       return response.json();
//     })
//     .then(function (json) {
//       console.log(json);
//       drivers = json;
//       createHeader();
//       createBody();
//     });
}

function createHeader() {
  let tr = document.createElement("tr");
  let array = ["Name", "Rating"];

  array.forEach((heading) => {
    let th = document.createElement("th");
    th.appendChild(document.createTextNode(heading));
    tr.appendChild(th);
  });
  thead.appendChild(tr);
  body.appendChild(table);
}

function createBody() {
    table.innerHTML = ""
  drivers.forEach((drivers) => {
    if(drivers.deleted != true)
    {
    let tr = document.createElement("tr");
    table.border="7";

    //name
    let nameTd = document.createElement("td");
    nameTd.appendChild(document.createTextNode(drivers.name));
    tr.appendChild(nameTd);

    //rating
    let ratingTd = document.createElement("td");
    ratingTd.appendChild(document.createTextNode(drivers.rating));
    tr.appendChild(ratingTd);
    table.appendChild(tr);
    
    }

  })
}

function postDriver(){
    const postDriverApiUrl = "https://localhost:7255/api/drivers";
    const driverName = document.getElementById("name").value;
    const driverRating = document.getElementById("rating").value;

    fetch(postDriverApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            name: driverName,
            dateHired: new Date().toISOString(),
            rating: driverRating,
            deleted: false
        })
    })
    .then((response)=>{
        console.log(response);
        createDriverTable();
        document.getElementById("name").value = '';
        document.getElementById("rating").value = '';
    })
}



async function deleteDriver(drivers)
{
    const id = document.getElementById("delete").value;
    const deleteUrl = "https://localhost:7255/api/drivers";
    const driver = await fetch(deleteUrl + '/'+id).then(res => res.json());
    const deleteDriver= {
        id: id,
        name:driver.name,
        rating: driver.rating,
        dateHired: driver.dateHired,
        deleted: true
    }


    fetch(deleteUrl, {
        method: "PUT",
        headers:
        {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(deleteDriver)
    })
    .then((response)=>{
        setTimeout(() => {

            createDriverTable();
            document.getElementById("delete").value='';
        }, 2000);
    });

}

function handleCreateRating()
{
    let newRating = document.getElementById('newRating').value;
    console.log(newRating)
    PostRating({'Rating': newRating})

}



async function updateTheDriver(drivers){
    const id = document.getElementById("id").value;
    const updateUrl = "https://localhost:7255/api/drivers";
    let driverRating = document.getElementById("Rating").value;
    console.log(driverRating);
    const driver = await fetch(updateUrl + '/'+id).then(res => res.json());
    const updateDriver= {
        id: driver.id,
        name:driver.name,
        rating: driverRating,
        dateHired: driver.dateHired,
        deleted: driver.deleted
    }


    fetch(updateUrl, {
        method: "PUT",
        headers:
        {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(updateDriver)
    })
    .then((response)=>{
        setTimeout(() => {

            createDriverTable();
            document.getElementById("id").value='';
            document.getElementById("Rating").value='';
        }, 2000);
    });






    // const updateUrl = "https://localhost:7255/api/drivers";
    // const driverId = document.getElementById("id").value;
    // const driver = await fetch(updateUrl + '/'+id).then(res => res.json());
    // let driverRating = document.getElementById("Rating").value;
    // const updateDriver= {
    //     // name:"",
    //     // id: driverId,
    //     // rating:driverRating,
    //     // dateHired: "",
    //     // deleted: false
    //     id: driver.id,
    //     name:driver.name,
    //     deleted: driver.deleted,
    //     rating: driverRating,
    //     dateHired: driver.dateHired
    // }
    // fetch(updateUrl, {
    //     method: "PUT",
    //     headers:
    //     {
    //         "Accept": 'application/json',
    //         "Content-Type": 'application/json'
    //     },
    //     body: JSON.stringify(updateDriver)
    // })
    // .then((response)=>{
    //     setTimeout(() => {
    //         createDriverTable();

    //     },1000);
    //     document.getElementById("id").value='';
    //     document.getElementById("Rating").value='';
    // });

}