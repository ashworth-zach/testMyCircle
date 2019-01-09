import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import {ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-create-channel',
  templateUrl: './create-channel.component.html',
  styleUrls: ['./create-channel.component.css']
})
export class CreateChannelComponent implements OnInit {

  constructor(private _httpService: HttpService, private route: ActivatedRoute, private routing: Router) { }
  ChannelExists:boolean;

  ngOnInit() {
  }
  checkChannelOnKeyup(event: any){
    var x = event.target.value;
    let observable = this._httpService.getChannel(x);
    observable.subscribe(data => {
      if(data['message']=="error"){
        this.ChannelExists=false;
      }
      else{
        this.ChannelExists=true;
      }
    })
  }
}
