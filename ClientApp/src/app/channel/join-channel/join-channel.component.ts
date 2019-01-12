import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import {ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-join-channel',
  templateUrl: './join-channel.component.html',
  styleUrls: ['./join-channel.component.css']
})
export class JoinChannelComponent implements OnInit {

  constructor(private _httpService: HttpService, private route: ActivatedRoute, private routing: Router) { }
  ChannelExists:boolean;
  ngOnInit() {
  }
  checkChannelOnKeyup(event: any){
    if (event.target.value.length==0){
      return;
    }
    var x = event.target.value;
    let observable = this._httpService.getChannel(x);
    observable.subscribe(data => {
      if(data['Message']=="Error"){
        this.ChannelExists=false;
      }
      else{
        this.ChannelExists=true;
      }
    })
  }
}
