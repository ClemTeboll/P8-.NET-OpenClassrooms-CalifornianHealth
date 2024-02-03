document.addEventListener('DOMContentLoaded', async function () {
    const consultantCalendar = await fetchEvents();
    //const bookedAppointments = await bookAppointment(consultantCalendar.info);

    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        themeSystem: 'bootstrap',
        initialView: 'dayGridMonth',
        timeZone: 'local',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
        },
        events: consultantCalendar,
        eventClick: await function bookAppointment(info) {
            console.log("Event clicked" + JSON.stringify(info));
        }
    });

    if (consultantCalendar.length > 0)
        calendar.render();

    async function fetchEvents() {
        const apiService = new ApiService(`https://localhost:32778/`);

        try {
            const events = await apiService.getAllConsultantCalendars();

            return events.map(event => ({
                title: "Appointment",
                start: event.date
            }));
        } catch (error) {
            console.error('Error trying to log events from API', error);
            return [];
        }
    }

    async function bookAppointment(info) {
        const apiService = new ApiService(`https://localhost:32778/`);

        try {
            const response = await apiService.bookAppointment(info);

            if (response.success) {
                console.log("Appointment booked successfully");
            } else {
                console.log("Failed to book appointment");
            }
        } catch (error) {
            console.error('Error trying to book appointment', error);
        }
    }
});