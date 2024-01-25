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
                'Access-Control-Allow-Origin': '*',
                //'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
                //'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token',
                //'Access-Control-Allow-Credentials': 'true',
                //'Access-Control-Max-Age': '86400',
                //'Access-Control-Expose-Headers': 'X-Auth-Token',
                //'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
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