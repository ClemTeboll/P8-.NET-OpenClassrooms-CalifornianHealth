document.addEventListener('DOMContentLoaded', async function () {
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
                events: await fetchEvents(),
                eventClick: await bookAppointment(),
            });

            calendar.render();

            async function fetchEvents() {
                const apiService = new ApiService(`https://localhost:32770/`);
                
                try {
                    const events = await apiService.getAllConsultantCalendars();
                    console.log('Events from API:', events);

                    return events.map(event => ({
                        //title: event.title,
                        start: event.date,
                        //end: event.end
                    }));
                } catch (error) {
                    console.error('Error trying to log events from API', error);
                    return [];
                }
            }

            async function bookAppointment() {

            }
        });