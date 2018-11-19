import { Routes, RouterModule } from '@angular/router';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';
import { LoginComponent } from './login/login.component';
import {ChatoverviewComponent} from './chatoverview/chatoverview.component';

const appRoutes: Routes = [
    
    //Site routes goes here 
    { 
        path: '', 
        component: SiteLayoutComponent,
        children: [
          { path: '', component: LoginComponent, pathMatch: 'full'},
          {path: 'chatoverview', component: ChatoverviewComponent}
        ]
    },
    
    // App routes goes here here
    { 
        path: '',
        component: AppLayoutComponent, 
        children: [
            { path: '', component: LoginComponent, pathMatch: 'full'}
        ]
    },

    //no layout routes
    { path: 'login', component: LoginComponent},
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);


