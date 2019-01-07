import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import {ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-task',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class mainComponent implements OnInit {

  constructor(private _httpService: HttpService, private route: ActivatedRoute, private routing: Router) { }
  user:any;
  newImage:any;
  errorImage:any;
  ngOnInit() {
    this.newImage = {image: ""};
  }

  onSubmit(){
    this.errorImage = null;

    let observable = this._httpService.createTask(this.newImage);
    observable.subscribe(data => {
      console.log(data);
      this.newImage = {image: ""};
    })
  }
}
