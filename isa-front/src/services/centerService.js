import http from "./httpService";
import {apiUrl} from '../config.json'

export function getAllTransfusionCenters(){
    return http.get(apiUrl + "/TransfusionCenter/GetAllTransfusionCenters");
}

export function getSingleTransfusionCenter(){
    return http.get(apiUrl + "/TransfusionCenter/GetSingleTransfusionCenter/");
}