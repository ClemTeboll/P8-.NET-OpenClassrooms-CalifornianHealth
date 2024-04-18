document.addEventListener('DOMContentLoaded', async function () {
    let consultantId;

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
        eventClick: async function bookAppointment(info) {

            const payload = {
                Id: Number.parseInt(info.event.id),
                StartDateTime: new Date(info.event.start),
                EndDateTime: new Date(new Date(info.event.start).getTime() + 60 * 60 * 1000),
                ConsultantId: consultantId,
                PatientId: currentUserId
            };
            const bookedAppointments = await bookAppointmentApi(payload);

            if (!bookedAppointments) {
                alert("Appointment was not booked, please try again.")
            }
            else {
                alert("Appointment was booked successfully.")
            }            
        }
    });
     
    calendar.render();

    // Event listener for dropdown change
    document.getElementById('consultant').addEventListener('change', async function () {
        const selectedConsultantIndex = parseInt(this.value);

        if (selectedConsultantIndex !== '-') {
            consultantId = selectedConsultantIndex;
            const consultantCalendar = await fetchEvents(consultantId);
            calendar.removeAllEvents();
            calendar.addEventSource(consultantCalendar);
        }
    });
    async function fetchEvents(consultantId) {
        const apiService = new ApiService(`https://localhost:7207/`);

        try {
            const events = await apiService.getOneConsultantCalendar(consultantId);

            return events.map(event => ({
                title: "Appointment",
                start: event.date,
                id: event.id
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

            if (response != null && response != undefined) {
                return true;
            } else {
                return false;
            }
        } catch (error) {
            console.error('Error trying to book appointment', error);
        }
    }
});