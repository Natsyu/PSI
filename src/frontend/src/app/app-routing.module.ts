import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { AdminMenuComponent } from './components/admin/admin-menu/admin-menu.component';
import { FieldsOfStudiesComponent } from './components/admin/fields-of-studies/fields-of-studies.component';
import { UsersComponent } from './components/admin/users/users.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { LogoutComponent } from './components/authentication/logout/logout.component';
import { HomeComponent } from './components/home/home/home.component';
import { NoAccessComponent } from './components/home/no-access/no-access.component';
import { NotFoundComponent } from './components/home/not-found/not-found.component';
import { AuthGuard } from './interceptors/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'admin',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'menu',
        component: AdminMenuComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: 'Admin',
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'manage-users',
        component: UsersComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: 'Admin',
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'manage-fields-of-studies',
        component: FieldsOfStudiesComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: 'Admin',
            redirectTo: '/noaccess'
          }
        }
      }
    ]
  },
  {
    path: 'noaccess',
    component: NoAccessComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
