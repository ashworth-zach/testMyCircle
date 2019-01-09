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
  error_user:any;
  error_pass:any;
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
      console.log(data);
      if(data['Message'] != "Success"){
        if(data['email']){
          if(data['Message'] === "Error"){
            this.error_user = [{"errorMessage": data['email']}];
          }
          else{
          this.error_user = data['email']['errors'];
          }
        }
        if(data['password']){
          this.error_pass = data['password']['errors'];
        }
      }else{
      this.logUser = {email: "", password: ""};
      this.routing.navigate(['/homepage']);
    }
    })
  }
}
