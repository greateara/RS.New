import axios, { AxiosResponse } from 'axios'
import { OrgType } from '../models/OrgType';
import { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { Router } from '../router/Routes';
import { Store } from '../stores/Store';
import { User, UserFormValues } from '../models/User';
import { AgamaAPI } from '../models/AgamaAPI';
// import { timeStamp } from 'console';
// import { error } from 'console';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'http://localhost:5006';

axios.interceptors.request.use(config => {
    const token = Store.commonStore.token;
    if (token && config.headers) config.headers.Authorization = `Bearer ${token}`;
    return config;
})

axios.interceptors.response.use(async response => {
    await sleep(1000);
    return response;
}, (error: AxiosError) => {
    // console.log(error);
    // console.log(error.response);
    const { data, status, config } = error.response as AxiosResponse;
    switch (status) {
        case 400:
            // if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
            //     Router.navigate('/not-found')
            // }
            // if (data) {
            //     const modalStateErrors = [];
            //     for (const key in data.errors) {
            //         if (data.errors[key]) {
            //             modalStateErrors.push(data.errors[key])
            //         }
            //     }
            //     throw modalStateErrors.flat();
            // } else {
            toast.error(error.code + ' ' + error.message);
            // }
            break;
        case 401:
            toast.error('unauthorized')
            break;
        case 403:
            toast.error('forbidden')
            break;
        case 404:
            // toast.error('not found')
            toast.error(error.code + ' ' + error.message);
            console.log(error)
            // Router.navigate('/not-found');
            break;
        case 500:
            toast.error('server error')
            console.log(error);
            // Store.commonStore.setServerError(error);
            // Router.navigate('/server-error');
            break;
        // default:
        //     break;
    }
    return Promise.reject(error);
})

const respondBody = <T,>(response: AxiosResponse<T>) => response.data;

const request = {
    get: <T,>(url: string) => axios.get<T>(url).then(respondBody),
    post: <T,>(url: string, body: {}) => axios.post<T>(url, body).then(respondBody),
    put: <T,>(url: string, body: {}) => axios.put<T>(url, body).then(respondBody),
    delete: <T,>(url: string) => axios.delete<T>(url).then(respondBody)
}

const Agama = {
    list: () => request.get<AgamaAPI[]>('/agama'),
    listPage: (searchText: string, count: number, skip: number) => request.get<AgamaAPI[]>
        (`/agama/${searchText}/${count}/${skip}`),
    listFilter: (searchText: string) => request.get<AgamaAPI[]>
        (`/agama/filter/${searchText}`),
    details: (id: string) => request.get<AgamaAPI>(`/agama/${id}`),
    create: (agama: AgamaAPI) => request.post<void>('/agama', agama),
    update: (agama: AgamaAPI) => request.put<void>(`/agama/${agama.id}`, agama),
    delete: (id: string, timeStamp: string) => request.delete<void>(`/agama/${id}/${timeStamp}`)

}

const OrgTypes = {
    list: () => request.get<OrgType[]>('/orgtype'),
    details: (id: string) => request.get<OrgType>(`/orgtype/${id}`),
    create: (orgType: OrgType) => request.post<void>('/orgtype', orgType),
    update: (orgType: OrgType) => request.put<void>(`/orgtype/${orgType.id}`, orgType),
    delete: (id: string) => request.delete<void>(`/orgtype/${id}`)

}
const Account = {
    current: () => request.get<User>('/Account'),
    login: (user: UserFormValues) => request.post<User>('/Account/Login', user),
    register: (user: UserFormValues) => request.post<User>('/Account/register', user)
}
const agent = {
    Agama,
    OrgTypes,
    Account
}

export default agent