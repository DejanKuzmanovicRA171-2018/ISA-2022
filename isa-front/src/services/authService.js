import http from "./httpService";
import apiUrl from '../config.json'
import jwtDecode from "jwt-decode";

http.setJwt(getJwt()); 

export function registerRegularUser(user){
    return http.post("https://localhost:7293/api/Auth/register/regular", {
        email: user.email,
        password: user.password,
        role: "RegUser",
        repeatedPassword: user.repeatedPassword,
        name: user.name,
        lastName: user.lastName,
        gender: user.gender,
        residenceAddress: user.residenceAddress,
        city: user.city,
        country: user.country,
        phoneNumber: user.phoneNumber,
        jmbg: user.jmbg,
        profession: user.profession,
        workLocation: user.workLocation,
    });
}

export async function login(email, password){
    const {data: jwt} = await http.post("https://localhost:7293/api/Auth/login",{ email, password});
    localStorage.setItem("token", jwt);
}

export function loginWithJwt(jwt){
    localStorage.setItem("token", jwt);
}

export function logout(){
    localStorage.removeItem("token");
}

export function getCurrentUser(){
    try{
        const jwt = localStorage.getItem("token");
        return jwtDecode(jwt);
      }
        catch(ex){
            return null;
        }
}

export function getJwt(){
    return localStorage.getItem("token");
}

export default{
    login,
    logout,
    getCurrentUser,
    loginWithJwt,
    getJwt
};