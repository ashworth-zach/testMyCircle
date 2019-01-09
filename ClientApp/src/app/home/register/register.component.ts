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
  error_user:any;
  error_email:any;
  error_pass:any;
  error_confirm:any;

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
    this.error_user = null;
    this.error_email = null;
    this.error_pass = null;
    this.error_confirm = null;
    let observable = this._httpService.CreateUser(this.newUser);
    observable.subscribe(data => {
      if(data['Message'] != "Success"){
        if(data['username']){
          if(data['Message'] === "Error"){
            this.error_user = [{"errorMessage": data['username']}];
          }
          else{
          this.error_user = data['username']['errors'];
          }
        }
        if(data['email']){
          if(data['Message'] === "Error"){
            this.error_email = [{"errorMessage": data['email']}];
          }
          else{
          this.error_email = data['email']['errors'];
          }
        }
        if(data['password']){
          this.error_pass = data['password']['errors'];
        }
        if(data['confirm']){
          this.error_confirm = data['confirm']['errors'];
        }
      }else{
        this.newUser = {username: "", email: "", password: "", confirm: ""};
        this.routing.navigate(['/homepage']);
      }
    })
  }
}
