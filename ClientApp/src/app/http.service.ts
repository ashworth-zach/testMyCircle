import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  data={};
  constructor(private _http: HttpClient) {
  }
  CreateUser(newUser){
    return this._http.post('/registeration', newUser);   
  }
  LogginUser(user){
    return this._http.post('/loggingIn', user);   
  }
  createTask(newImage){
    return this._http.post('/createTask', newImage);   
  }
  getChannel(channel){
    return this._http.post('/getChannel', channel)
  }
}