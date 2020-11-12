import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FooterComponent } from './footer/footer.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutUsComponent } from './about-us/about-us.component';
import { GroupsComponent } from './groups/groups.component';
import { DocumentsComponent } from './documents/documents.component';
import { ActivityComponent } from './activity/activity.component';
import { AboutParentComponent } from './about-parent/about-parent.component';
import { AccountModule } from './account/account.module';
import { UploadComponent } from './upload/upload.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'groups', component: GroupsComponent },
  { path: 'documents', component: DocumentsComponent },
  { path: 'activity', component: ActivityComponent },
  { path: 'about-parent', component: AboutParentComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FetchDataComponent,
    FooterComponent,
    NavMenuComponent,
    AboutUsComponent,
    GroupsComponent,
    DocumentsComponent,
    ActivityComponent,
    AboutParentComponent,
    UploadComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AccountModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
  ],
  exports: [RouterModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
