import http from "./httpService";
import {apiUrl} from '../config.json'

export function getAllAppointments(){
    return http.get(apiUrl + "/Appointment/GetAllAppointments");
}

export function getSingleAppointment(){
    return http.get(apiUrl + "/Appointment/GetSingleAppointment/");
}