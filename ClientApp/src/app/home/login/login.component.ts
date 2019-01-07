import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import {ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-task',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class loginComponent implements OnInit {
  userMargin:any;
  passMargin:any;
  logUser:any;
  error_user:String;
  error_pass:String;
  constructor(private _httpService: HttpService, private route: ActivatedRoute, private routing: Router) { }

  ngOnInit() {
    this.userMargin = "10px"
    this.passMargin = "10px"
    this.logUser = {email: "", password: ""};
  }
  userKeyed(){
    this.userMargin = "-15px"
  }
  passKeyed(){
    this.passMargin = "-15px"
  }

  onSubmit2(){
    let observable = this._httpService.LogginUser(this.logUser);
    observable.subscribe(data => {
      if(data['Message'] == "FirstError"){
        for(let x=0; x<data['data'].length; x++){
          if(data['data'][x].username){
            this.error_user = data['data'][x].username;
          }
          if(data['data'][x].password){
            this.error_pass = data['data'][x].password;
          }
        }
    }else{
      this.logUser = {email: "", password: ""};
      this.routing.navigate(['/homepage']);
    }
    })
  }
}
