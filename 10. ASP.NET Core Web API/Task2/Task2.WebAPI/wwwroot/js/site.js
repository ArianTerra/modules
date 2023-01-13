const pageSizeDefault = 30;
const search = $('#search');

function makeRequest() {
    let page = new URLSearchParams(window.location.search).get('page');
    if(page <= 0) {
        page = 1;
    }

    let pageSize = new URLSearchParams(window.location.search).get('pageSize');
    if(pageSize <= 0) {
        pageSize = pageSizeDefault;
    }

    $.ajax({
        url: "/api/articles?page=" + page + "&pageSize=" + pageSize + "&nameStartsWith=" + search.val(),
        type: "GET",
        dataType: "json",
        success: function (data, status, request) {
            drawTable(data);

            let itemCount = request.getResponseHeader('X-Total-Count');
            let pageSize = new URLSearchParams(window.location.search).get('pageSize');
            if(pageSize <= 0) {
                pageSize = pageSizeDefault;
            }

            drawPagination(itemCount, pageSize);
        }
    })
}

function drawTable(data) {
    let tbody = $('#table_data');
    tbody.html("");

    let page = new URLSearchParams(window.location.search).get('page');
    let pageSize = new URLSearchParams(window.location.search).get('pageSize');

    for(let item in data) {
        //console.log(item);
        let id = Number(item) + 1 + (page - 1) * pageSize;
        let tr = $('<tr>').append(
            $('<td>').text(id),
            $('<td>').text(data[item].id),
            $('<td>').text(data[item].name),
            $('<td>').text(data[item].publishDate),
            $('<td>').text(data[item].source)
        );

        tbody.append(tr);
    }
}

function drawPagination(itemCount, pageSize) {
    let nav = $('.pagination');
    let pageCount = Math.ceil(itemCount / pageSize);

    nav.html("");

    for(let i = 1; i <= pageCount; i++) {
        let link = "?page=" + i + "&pageSize=" + pageSize;
        let li =  $('<li class="page-item">');
        let a = $('<a class="page-link" href=' + link + '>').text(i);
        let page = new URLSearchParams(window.location.search).get('page');
        if(page == null || page <= 0) {
            page = 1;
        }

        if(page == i) {
            a.addClass("active");
        }

        nav.append(li.append(a))
    }
}

search.on('input', makeRequest);

$(document).ready(makeRequest)