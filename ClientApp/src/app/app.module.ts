import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from './http.service';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'; // <-- import FormsModule.
import { AppRoutingModule } from './app-routing.module';
import { loginComponent } from './home/login/login.component';
import { registerComponent } from './home/register/register.component';
import { mainComponent } from './main/main.component';
import { CreateChannelComponent } from './create-channel/create-channel.component';
import { JoinChannelComponent } from './join-channel/join-channel.component';


@NgModule({
  declarations: [AppComponent, loginComponent, registerComponent, mainComponent, CreateChannelComponent, JoinChannelComponent],
  imports: [BrowserModule, AppRoutingModule,HttpClientModule,
    FormsModule],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }