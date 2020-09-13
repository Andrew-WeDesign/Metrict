$(document).ready(function () {
    $('#bootstrapModalFullCalendar').fullCalendar({
        header: {
            left: '',
            center: 'prev title next',
            right: '',
        },
        eventClick: function (event) {
            $('#modalTitle').html(event.title);
            $('#modalBody').html(event.description);
            $('#eventUrl').attr('href', event.url);
            $('#fullCalModal').modal();
            return false;
        },
        timezone: 'local',
        events: 'https://metrict.com/employeetasks/getallforcalendar'
    });
});

