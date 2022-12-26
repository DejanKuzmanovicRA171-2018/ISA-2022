import http from "./httpService";
import {apiUrl} from '../config.json'

export function getAllUsers(){
    return http.get(apiUrl + "/User/GetAllUsers");
}
export function getSingleUser(){
    return http.get(apiUrl + "/User/GetSingleUser");
}
