export class ApiService {
    constructor(urlBase) {
        this.urlBase = urlBase;
    };

    //apiEmployeesSignUp = async (data) => {
    //    let url = this.urlBase + 'api/employees/signup';

    //    const response = await fetch(url, {
    //        method: 'POST',
    //        body: data,
    //    });
    //    const userData = await response.json();

    //    localStorage.setItem('token', userData.token);
    //    return userData;
    //};

    //apiEmployeesLogin = async (data) => {
    //    let url = this.urlBase + 'api/employees/login';

    //    const response = await fetch(url, {
    //        method: 'POST',
    //        body: JSON.stringify(data),
    //        headers: {
    //            'Content-type': 'application/json; charset=UTF-8',
    //        },
    //    });
    //    if (response.status === 401) {
    //        return response;
    //    } else {
    //        const userData = await response.json();
    //        return userData;
    //    }
    //};

    //apiUpdateEmployees = async (token, data) => {
    //    let url = this.urlBase + `api/employees/${data?.get('id')}`;

    //    const response = await fetch(url, {
    //        method: 'PUT',
    //        body: data,
    //        headers: {
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });
    //    const updateEmployeeData = response.json();

    //    return updateEmployeeData;
    //};

    //apiDeleteEmployees = async (token, data) => {
    //    let url = this.urlBase + `api/employees/${data}`;

    //    const response = await fetch(url, {
    //        method: 'DELETE',
    //        headers: {
    //            Authorization: `Bearer ${token}`,
    //        },
    //        body: JSON.stringify(data),
    //    });
    //    const deleteEmployeeData = response.json();
    //    return deleteEmployeeData;
    //};

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

    //apiGetEmployeeByToken = async (token) => {
    //    let url = this.urlBase + `api/employees/auth`;

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

    //apiUpdatePost = async (token, data) => {
    //    let url = this.urlBase + `api/posts/${data.get('id')}`;

    //    const response = await fetch(url, {
    //        method: 'PUT',
    //        headers: {
    //            Authorization: `Bearer ${token}`,
    //        },
    //        body: data,
    //    });
    //    const updatePostData = response.json();
    //    return updatePostData;
    //};

    //apiDeletePost = async (token, id) => {
    //    let url = this.urlBase + `api/posts/${id}`;

    //    const response = await fetch(url, {
    //        method: 'DELETE',
    //        headers: {
    //            Authorization: `Bearer ${token}`,
    //        },
    //        body: JSON.stringify(id),
    //    });
    //    const deletePostData = response.json();
    //    return deletePostData;
    //};

    //apiGetPostById = async (token, data) => {
    //    let url = this.urlBase + `api/posts/${data}`;

    //    const response = await fetch(url, {
    //        method: 'GET',
    //        headers: {
    //            'Content-Type': 'application/json',
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });

    //    const postByIdData = response.json();
    //    return postByIdData;
    //};

    //apiGetAllPosts = async (token) => {
    //    let url = this.urlBase + `api/posts/`;

    //    const response = await fetch(url, {
    //        method: 'GET',
    //        headers: {
    //            'Content-Type': 'application/json',
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });

    //    const postData = response.json();

    //    return postData;
    //};

    //apiManageLike = async (token, data) => {
    //    let url = this.urlBase + `api/posts/${data.PostId}/like`;

    //    const response = await fetch(url, {
    //        method: 'POST',
    //        body: JSON.stringify(data),
    //        headers: {
    //            'Content-type': 'application/json; charset=UTF-8',
    //            Authorization: `Bearer ${token}`,
    //        },
    //    });
    //    const likeData = response.json();
    //    return likeData;
    //};
};