$(document).ready(function () {
    $("#addannouncement").on('click', function () {
        var title = prompt("Add title");
        var description = prompt("Add description ");
        $.ajax({
            url: '/Home/AddNewAnnouncement',
            data: {
                Title: title,
                Description: description,
            },
            type: 'POST',
            success: function () {
                alert("Announcement added successfully!")
                location.reload();
                return false;
            },
            error: function (data) {
                alert("Announcement not added,try again!")
            }
        });
    });
});

$(document).ready(function () {
    $(".remove").on('click', function () {
        var id = $(this).data("id");
        $.ajax({
            url: '/Home/RemoveAnnouncement',
            data: {
                announcementid : id
            },
            type: 'POST',
            success: function () {
                alert("Announcement removed successfully!")
                location.reload();
                return false;
            },
            error: function () {
                alert("Announcement not removed,try again!")
            }
        });
    });
});

$(document).ready(function () {
    $(".edit").on('click', function () {
        var title = prompt("Change title",$(this).data("title"));
        var description = prompt("Change description", $(this).data("description"));
        var id = $(this).data("id");
        $.ajax({
            url: '/Home/EditAnnouncementTitle',
            data: {
                Title: title,
                Description: description,
                Id: id
            },
            type: 'POST',
            success: function () {
                alert("Announcement changed successfully!")
                location.reload();
                return false;
            },
            error: function () {
                alert("Announcement not changed,try again!")
            }
        });
    });
});