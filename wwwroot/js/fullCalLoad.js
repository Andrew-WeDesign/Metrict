$(document).ready(function () {
    $('#bootstrapModalFullCalendar').fullCalendar({
        header: {
            left: '',
            center: 'prev title next',
            right: '',
        },
        eventClick: function (event, jsEvent, view) {
            $('#modalTitle').html(event.title);
            $('#modalBody').html(event.description);
            $('#eventUrl').attr('href', event.Url);
            $('#fullCalModal').modal();
            return false;
        },
        events: 'https://localhost:44322/employeetasks/getallforcalendar'
    });
});

