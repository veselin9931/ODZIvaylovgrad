import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MDBBootstrapModule  } from 'angular-bootstrap-md';
import { DataService } from './shared/data.service';
import { IdentityService } from './shared/identity.service';
import { StorageService } from './shared/storage.service';
import { LoggerService } from './shared/logger.service';
import { RouterService } from './shared/router.service';
import { WindowRefService } from './shared/window-ref.service';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FooterComponent } from './footer/footer.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutUsComponent } from './about-us/about-us.component';
import { GroupsComponent } from './groups/groups.component';
import { DocumentsComponent } from './documents/documents.component';
import { ActivityComponent } from './activity/activity.component';
import { AboutParentComponent } from './about-parent/about-parent.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    NavMenuComponent,
    AboutUsComponent,
    GroupsComponent,
    DocumentsComponent,
    ActivityComponent,
    AboutParentComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'groups', component: GroupsComponent },
      { path: 'documents', component: DocumentsComponent },
      { path: 'activity', component: ActivityComponent },
      { path: 'about-parent', component: AboutParentComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [DataService, 
    IdentityService, 
    StorageService, 
    LoggerService, 
    RouterService,
    WindowRefService],
  bootstrap: [AppComponent]
})
export class AppModule { }
