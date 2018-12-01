import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { routing } from './app.routing';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MatCardModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import {MatButtonModule} from '@angular/material';
import { ChatoverviewComponent } from './chatoverview/chatoverview.component';
import {UserService} from './_services/userservice';
import {NotificationService} from './_services/notificationservice';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { AppHeaderComponent } from './_layout/app-header/app-header.component';
import { SiteHeaderComponent } from './_layout/site-header/site-header.component';
import { SiteFooterComponent } from './_layout/site-footer/site-footer.component';
import {APP_BASE_HREF} from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatoverviewComponent,
    AppLayoutComponent,
    AppHeaderComponent,
    SiteHeaderComponent,
    SiteLayoutComponent,
    SiteFooterComponent
  ],
  imports: [
    BrowserModule,
    routing,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule
  ],
  providers: [
    UserService,
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
