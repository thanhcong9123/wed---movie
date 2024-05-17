
$(document).ready(function () {
    $('#selectdirector').select2();
});
$(document).ready(function () {
    $('#selectperformer').select2();
});
$(document).ready(function () {
    var output = document.getElementById('ProfilePicturePreview');
    output.src = $("#Image").val();
})
$("#Image").on("change", function () {
    var output = document.getElementById('ProfilePicturePreview');
    output.src = $(this).val();
})
$(document).ready(function () {
    var output = document.getElementById('IdBackground');
    output.style.backgroundImage = "url('" + $("#Background").val() + "')";
})
$("#Background").on("change", function () {
    var output = document.getElementById('IdBackground');
    output.style.backgroundImage = "url('" + $(this).val() + "')";

    output.height = 600;
})
var listItemCreateAll = new Object();
listItemCreateAll.PeoplePerformer = [];
listItemCreateAll.PeopleDirector = [];
listItemCreateAll.Trailers = [];
listItemCreateAll.Genres = [];
listItemCreateAll.Nation = [];
//trailer
var modaltrailer = document.getElementById("modal-trailer");
var modalbrtrailer = document.getElementById("modal-br-trailer");
modalbrtrailer.onclick = function () {
    modaltrailer.classList.remove('active');
    document.getElementById('link-yt').innerHTML = "";
};
var buttonaddtrailer = document.getElementById("button-add_trailer");
buttonaddtrailer.onclick = function () {
    var Trailers = new Object();
    Trailers.Img = $('#input-trailer_img').val();
    Trailers.Link = $('#input-trailer_link').val();
    listItemCreateAll.Trailers.push(Trailers);
    var listItemCreate = new Object();
    listItemCreate.Trailers = listItemCreateAll.Trailers;
    console.log(JSON.stringify(listItemCreate));
    $.ajax({
        type: 'POST',
        url: '/Movies/FunctionCreate',
        ContentType: 'application/json; charset=utf-8',
        data: listItemCreate,
        success: function (res) {
            $('#GridviewTrailer').html('').html(res);
            $('.trailer').slick({
                infinite: true,
                slidesToShow: 4,
                slidesToScroll: 4,
                nextArrow: `<div class=" slick-arrow click-previous">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941
                          0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484
                          101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941
                          0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z">
                          </path>
                          </svg>
                          </div> `,
                prevArrow: `<div class="slick-arrow click-next  pull-right type='button'">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04
                          33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57
                          9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z">
                          </path>
                          </svg>
                          </div> `

            });

        },
        error: function () { alert('A error'); }
    });
}
//Performer
var buttonaddperformer = document.getElementById("add-performer");
var modalperformer = document.getElementById("modal-performer");
var modalbrperformer = document.getElementById("modal-br-performer");
buttonaddperformer.onclick = function () {
    modalperformer.classList.add('active');
}
modalbrperformer.onclick = function () {
    modalperformer.classList.remove('active');
};
var butttonaddperformer = document.getElementById("btn-addperformer");
butttonaddperformer.onclick = function () {
    var listItemCreate = new Object();
    listItemCreateAll.PeoplePerformer.push($('#selectperformer').val());
    listItemCreate.PeoplePerformer = listItemCreateAll.PeoplePerformer;
    $.ajax({
        type: 'POST',
        url: '/Movies/FunctionCreate',
        ContentType: 'application/json; charset=utf-8',
        data: listItemCreate,
        success: function (res) {
            modalperformer.classList.remove('active');
            $('#GridViewPerformer').html('').html(res);
            $('.performer').slick({
                infinite: true,
                slidesToShow: 4,
                slidesToScroll: 4,
                nextArrow: `<div class=" slick-arrow click-previous">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941
                          0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484
                          101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941
                          0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z">
                          </path>
                          </svg>
                          </div> `,
                prevArrow: `<div class="slick-arrow click-next  pull-right type='button'">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04
                          33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57
                          9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z">
                          </path>
                          </svg>
                          </div> `
            });
        },
        error: function () { alert('A error'); }
    });
}
//Sự kiện director
var buttonadddirector = document.getElementById("add-director");
var modaldirector = document.getElementById("modal-director");
var modalbrdirector = document.getElementById("modal-br-director");
buttonadddirector.onclick = function () {
    modaldirector.classList.add('active');
}
modalbrdirector.onclick = function () {
    modaldirector.classList.remove('active');
};
var butttonadddirector = document.getElementById("btn-adddirector");
var selectdirector = document.getElementsByName("selectdirector");
butttonadddirector.onclick = function () {
    var listItemCreate = new Object();
    listItemCreateAll.PeopleDirector.push($('#selectdirector').val());
    listItemCreate.PeopleDirector = listItemCreateAll.PeopleDirector;
    $.ajax({
        type: 'POST',
        url: '/Movies/FunctionCreate',
        ContentType: 'application/json; charset=utf-8',
        data: listItemCreate,
        success: function (res) {
            modaldirector.classList.remove('active');
            $('#GridViewDirector').html('').html(res);
            $('.director').slick({
                infinite: true,
                slidesToShow: 4,
                slidesToScroll: 4,
                nextArrow: `<div class=" slick-arrow click-previous">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941
                          0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484
                          101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941
                          0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z">
                          </path>
                          </svg>
                          </div> `,
                prevArrow: `<div class="slick-arrow click-next  pull-right type='button'">
                          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
                          <path
                          d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04
                          33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57
                          9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z">
                          </path>
                          </svg>
                          </div> `
            });

        },
        error: function () { alert('A error'); }
    });

}
//Sự kiện nations
var buttonaddnations = document.getElementById("add-nations");
var modal = document.getElementById("modal");
var modalbr = document.getElementById("modal-br");
buttonaddnations.onclick = function () {
    modal.classList.add('active');
}
modalbr.onclick = function () {
    modal.classList.remove('active');
};
var btnaddnations = document.getElementById("btn-addnation");
var checkboxnation = document.getElementsByName("list-cb-nation");
btnaddnations.onclick = function () {
    var listItemCreate = new Object();
    listItemCreate.Nations = new Array();
    listItemCreateAll.Nation = listItemCreate.Nations;
    for (var i = 0; i < checkboxnation.length; i++) {
        if (checkboxnation[i].checked) {
            var Nations = {};
            Nations.Id = checkboxnation[i].value;
            Nations.NameNation = checkboxnation[i].id;
            listItemCreate.Nations.push(Nations);
        }
    }
    $.ajax({
        type: 'POST',
        url: '/Movies/FunctionCreate',
        ContentType: 'application/json; charset=utf-8',
        data: listItemCreate,
        success: function (res) {
            modal.classList.remove('active');
            $('#GridViewNation').html('').html(res);

        },
        error: function () { alert('A error'); }
    });
}
//Sự kiện Genre
var buttonaddgenre = document.getElementById("add-genre");
var modalgenre = document.getElementById("modal-genre");
var modalbrgenre = document.getElementById("modal-br-genre");
buttonaddgenre.onclick = function () {
    modalgenre.classList.add('active')
}
modalbrgenre.onclick = function () {
    modalgenre.classList.remove('active');
};
var btnaddgenres = document.getElementById("btn-addgenre");
var checkboxgenre = document.getElementsByName("list-gr-nation");
btnaddgenres.onclick = function () {
    var listItemCreate = new Object();
    listItemCreate.Genres = new Array();
    for (var i = 0; i < checkboxgenre.length; i++) {
        if (checkboxgenre[i].checked) {
            var Genres = {};
            Genres.Id = checkboxgenre[i].value;
            Genres.Namegenre = checkboxgenre[i].id;
            listItemCreate.Genres.push(Genres);
        }
    }
    listItemCreateAll.Genres = listItemCreate.Genres;
    $.ajax({
        type: 'POST',
        url: '/Movies/FunctionCreate',
        ContentType: 'application/json; charset=utf-8',
        data: listItemCreate,
        success: function (res) {
            modalgenre.classList.remove('active');
            $('#GridViewGenre').html('').html(res);
        },
        error: function () { alert('A error'); }
    });
}
//moroot people performer
function clickpeople() {
    var id = new Object();
    id.id = $('#selectperformer').val();
    $.ajax({
        method: 'GET',
        url: '/Peoples/MovieCreateItemPeople',
        data: id,
        // ContentType: 'application/json; charset=utf-8',
        // dataType: "text",
        success: function (res) {
            if (res.length != 0) {
                document.getElementById("NamePeoplePerformer").value = res.namePeople;
                $('#YearofBirthPerformer').val(res.yearofBirth);
                $('#GenderPeoplePerformer').val(res.gender);
                $('#PlaceofBirthPerformer').val(res.placeofBirth);
                document.getElementById("ImgPeoplePerformer").src = res.image;
            }
        },
        error: function () { alert('loi'); }
    });
}
function clickDerector() {
    var id = new Object();
    id.id = $('#selectdirector').val();
    console.log(JSON.stringify(id));
    $.ajax({
        method: 'GET',
        url: '/Peoples/MovieCreateItemPeople',
        data: id,
        // ContentType: 'application/json; charset=utf-8',
        // dataType: "text",
        success: function (res) {
            if (res.length != 0) {
                
                document.getElementById("NamePeople").value = res.namePeople;
                $('#YearofBirth').val(res.yearofBirth);
                $('#GenderPeople').val(res.gender);
                $('#PlaceofBirth').val(res.placeofBirth);
                document.getElementById("ImgPeopleDiretor").src = res.image;
            }
        },
        error: function () { alert('a loi'); }
    });
}
var buttonCreateMovie = document.getElementById("createMovie");
buttonCreateMovie.onclick = function () {
    listItemCreateAll.NameEL = $('#NameEL').val();
    listItemCreateAll.NameVN = $('#NameVN').val();
    listItemCreateAll.Point = $('#Point').val();
    listItemCreateAll.ReleaseDate = $('#ReleaseDate').val();
    listItemCreateAll.Image = $('#Image').val();
    listItemCreateAll.Background = $('#Background').val();
    listItemCreateAll.Content = $('#Content').val();
    listItemCreateAll.IdMovieType = $('#selectmovietype').val();
    if ($('#Episodes').val() != "") {
        listItemCreateAll.Episodes = $('#Episodes').val();
    }
    var fileSelector = document.getElementById('file1');
    var formData  = new FormData();
    formData.append('formFile', $('#file1')[0].files[0]);
    console.log($('#file1')[0].files[0]);
    $.ajax({
        url: "/Movies/UpLoadVideo",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function(data){

            listItemCreateAll.FileName = data;
            console.log(listItemCreateAll);
            $.ajax({
                method: 'POST',
                url: '/Movies/Create',
                data: listItemCreateAll,
                ContentType: 'application/json; charset=utf-8',
                // dataType: "text",
                // processData: false,
                success: function (res) {
                },
                error: function () { alert('Ban can nhap day du thong tin'); }
            });
        },
        error: function () {
            $.ajax({
                method: 'POST',
                url: '/Movies/Create',
                data: listItemCreateAll,
                ContentType: 'application/json; charset=utf-8',
                // dataType: "text",
                // processData: false,
                success: function (res) {
                    alert('Khong nhan duoc file phim'); 
                },
                error: function () { alert('Ban can nhap day du thong tin'); }
            });

        }
     })
}
function clicktype() {
    let html = '<input style="  font-size: 16px;color: #fff;background: transparent;border: none;border-bottom: 1px solid #fff;margin-bottom: 10px;outline: none;" type="text" autocomplete="episodes" placeholder="Episodes" id="Episodes">'
    document.getElementById('episodis').innerHTML =html;
    if ($('#selectmovietype').val() == 2) {
        document.getElementById('episodis').innerHTML = "";
    }
}


function _(el) {
    return document.getElementById(el);
  }
  
  function uploadFile() {
    var file = _("file1").files[0];
    // alert(file.name+" | "+file.size+" | "+file.type);
    var formdata = new FormData();
    formdata.append("file1", file);
    var ajax = new XMLHttpRequest();
    ajax.upload.addEventListener("progress", progressHandler, false);
    ajax.addEventListener("load", completeHandler, false);
    ajax.addEventListener("error", errorHandler, false);
    ajax.addEventListener("abort", abortHandler, false);
    ajax.open("POST", "file_upload_parser.php"); // http://www.developphp.com/video/JavaScript/File-Upload-Progress-Bar-Meter-Tutorial-Ajax-PHP
    //use file_upload_parser.php from above url
    ajax.send(formdata);
  }
  
  function progressHandler(event) {
    _("loaded_n_total").innerHTML = "Uploaded " + event.loaded + " bytes of " + event.total;
    var percent = (event.loaded / event.total) * 100;
    _("progressBar").value = Math.round(percent);
    _("status").innerHTML = Math.round(percent) + "% uploaded... please wait";
  }
  
  function completeHandler(event) {
    _("status").innerHTML = event.target.responseText;
    _("progressBar").value = 0; //wil clear progress bar after successful upload
  }
  
  function errorHandler(event) {
    _("status").innerHTML = "Upload Failed";
  }
  
  function abortHandler(event) {
    _("status").innerHTML = "Upload Aborted";
  }