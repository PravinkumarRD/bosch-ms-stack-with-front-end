import { Routes } from '@angular/router';

import { BoschHomeComponent } from './home/bosch-home/bosch-home.component';
import { EventsListComponent } from './events/components/events-list/events-list.component';
import { EmployeesListComponent } from './employees/components/employees-list/employees-list.component';
import { EventDetailsComponent } from './events/components/event-details/event-details.component';
import { LoginComponent } from './security/components/login/login.component';
import { RegisterEventComponent } from './events/components/register-event/register-event.component';

export const routes: Routes = [
    {
        path: '',
        component: BoschHomeComponent
    },
    {
        path: 'home',
        component: BoschHomeComponent
    },
    {
        path: 'events',
        loadComponent: () => import('./events/components/events-list/events-list.component').then(c => c.EventsListComponent)
    },
    {
        path: 'events/new',
        component: RegisterEventComponent
    },
    {
        path: 'events/:id',
        component: EventDetailsComponent
    },
    {
        path: 'employees',
        component: EmployeesListComponent
    },
    {
        path: 'login',
        component: LoginComponent
    }
];
