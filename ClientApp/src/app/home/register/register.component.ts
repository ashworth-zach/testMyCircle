import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import {ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-task',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class registerComponent implements OnInit {

  constructor(private _httpService: HttpService, private route: ActivatedRoute, private routing: Router) { }
  userMargin:any;
  passMargin:any;
  emailMargin:any;
  pass2Margin:any;
  newUser:any;
  error_user:String;
  error_email:String;
  error_pass:String;

  ngOnInit() {
    this.userMargin = "10px"
    this.passMargin = "10px"
    this.emailMargin = "10px"
    this.pass2Margin = "10px"

    this.newUser = {username: "", email: "", password: "", confirm: ""};
  }
//=====================================================
  userKeyed(){
    this.userMargin = "-15px"
  }
  passKeyed(){
    this.passMargin = "-15px"
  }
  emailKeyed(){
    this.emailMargin = "-15px"
  }
  pass2Keyed(){
    this.pass2Margin = "-15px"
  }
//=====================================================
  onSubmit(){
    let observable = this._httpService.CreateUser(this.newUser);
    observable.subscribe(data => {
      if(data['Message'] != "Success"){
        if(data['Message'] == "FirstError"){
          for(let x=0; x<data['data'].length; x++){
            if(data['data'][x].username){
              this.error_user = data['data'][x].username;
            }
            if(data['data'][x].email){
              this.error_email = data['data'][x].email;
            }
            if(data['data'][x].password){
              this.error_pass = data['data'][x].password;
            }
          }
        }
        if(data['Message'] == "Error"){
          if(data['data']['errors']['username']){
            this.error_user = data['data']['errors']['username']['message'];
          }
          if(data['data']['errors']['email']){
            this.error_email = data['data']['errors']['email']['message'];
          }
          if(data['data']['errors']['password']){
            this.error_pass = data['data']['errors']['password']['message'];
          }
        }
      }else{
        this.newUser = {username: "", email: "", password: "", confirm: ""};
        this.routing.navigate(['/homepage']);
      }
    })
  }
}
