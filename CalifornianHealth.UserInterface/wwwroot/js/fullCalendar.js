document.addEventListener('DOMContentLoaded', async function () {
    const consultantCalendar = await fetchEvents();
   // const bookedAppointments = await bookAppointment(consultantCalendar.info.event.id);

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
        eventClick: async function bookAppointment(info) {
            const payload = {
                Id: Number.parseInt(info.event.id),
                StartDateTime: new Date(info.event.start),
                EndDateTime: new Date(new Date(info.event.start).getTime() + 60 * 60 * 1000),
                ConsultantId: 3,
                PatientId: 1, //TODO: Get from logged in user
            };
            const bookedAppointments = await bookAppointmentApi(payload);
            console.log("Booked appointments" + JSON.stringify(bookedAppointments));
        }
    });

    if (consultantCalendar.length > 0)
        calendar.render();

    async function fetchEvents() {
        const apiService = new ApiService(`https://localhost:7207/`);

        try {
            const events = await apiService.getAllConsultantCalendars();

            return events.map(event => ({
                title: "Appointment",
                start: event.date,
                id:event.id
            }));
        } catch (error) {
            console.error('Error trying to log events from API', error);
            return [];
        }
    }

    async function bookAppointmentApi(info) {
        const apiService = new ApiService(`https://localhost:7207/`);



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