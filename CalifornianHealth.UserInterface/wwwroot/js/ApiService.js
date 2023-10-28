export class ApiService {
    constructor(urlBase) {
        this.urlBase = urlBase;
    };

    // 2 GETS : consultant and doctors
    // 1 POST : patient calendar

    // -->
    // GetAllConsultants
    // GetAllDoctors
    // PostCalendar

    //apiGetAllEmployees = async (token) => {
    //    let url = this.urlBase + 'api/employees/';

    //    const response = await fetch(url, {
    //        method: 'GET',
    //        headers: {
    //            'Content-Type': 'application/json',
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });

    //    const employeesData = response.json();
    //    return employeesData;
    //};

    //apiGetEmployeeById = async (token, data) => {
    //    let url = this.urlBase + `api/employees/${data}`;

    //    const response = await fetch(url, {
    //        method: 'GET',
    //        headers: {
    //            'Content-Type': 'application/json',
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });

    //    const employeeByIdData = response.json();
    //    return employeeByIdData;
    //};

    //apiCreatePost = async (token, data) => {
    //    let url = this.urlBase + 'api/posts/';

    //    const response = await fetch(url, {
    //        method: 'POST',
    //        body: data,
    //        headers: {
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });
    //    const postData = await response.json();
    //    return postData;
    //};
};