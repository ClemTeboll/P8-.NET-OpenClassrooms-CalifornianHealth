class ApiService {

    constructor(urlBase) {
        this.urlBase = urlBase;
    }

    getAllConsultantCalendars = async () => {
        let url = this.urlBase + 'api/ConsultantCalendar';

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            },
        });

        return response.json();
    };

    //getAllConsultantCalendarsByConsultantId = async (id) => {
    //    let url = this.urlBase + `api/ConsultantCalendar/${id}`;

    //    const response = await fetch(url, {
    //        method: 'GET',
    //        headers: {
    //            'Content-Type': 'application/json',
    //            'Access-Control-Allow-Origin': '*'
    //        },
    //    });

    //    return response.json()
    //};

    getAllConsultantCalendarsByConsultantId = async (id) => {
        let url = this.urlBase + `api/ConsultantCalendar/${id}`;

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            },
        });

        return response.json()
    };

    bookAppointment = async (info) => {
        let url = this.urlBase + 'api/ConsultantCalendar';

        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            },
            body: JSON.stringify(info)
        });

        return response.json();
    }
}