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
                //Authorization: `Bearer ${token}`,
                'Access-Control-Allow-Origin': '*'
            },
        });

        return response.json();
    };

    getOneConsultantCalendar = async (id) => {
        let url = this.urlBase + `api/ConsultantCalendar/${id}`;

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                //Authorization: `Bearer ${token}`,
                'Access-Control-Allow-Origin': '*'
            },
        });

        return response.json()
    };
}