import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { AdminMenuComponent } from './components/admin/admin-menu/admin-menu.component';
import { FieldsOfStudiesComponent } from './components/admin/fields-of-studies/fields-of-studies.component';
import { UsersComponent } from './components/admin/users/users.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { LogoutComponent } from './components/authentication/logout/logout.component';
import { DocumentsComponent } from './components/documents/documents.component';
import { HomeComponent } from './components/home/home/home.component';
import { NoAccessComponent } from './components/home/no-access/no-access.component';
import { NotFoundComponent } from './components/home/not-found/not-found.component';
import { LearningOutcomeDocumentComponent } from './components/learning-outcomes/learning-outcome-document/learning-outcome-document.component';
import { LearningOutcomePickerComponent } from './components/learning-outcomes/learning-outcome-picker/learning-outcome-picker.component';
import { SubjectDocumentComponent } from './components/subjects/subject-document/subject-document.component';
import { SubjectPickerComponent } from './components/subjects/subject-picker/subject-picker.component';
import { SyllabusAcceptanceComponent } from './components/syllabuses/syllabus-acceptance/syllabus-acceptance.component';
import { SyllabusDocumentComponent } from './components/syllabuses/syllabus-document/syllabus-document.component';
import { SyllabusPickerComponent } from './components/syllabuses/syllabus-picker/syllabus-picker.component';
import { AccountComponent } from './components/user/account/account.component';
import { AuthGuard } from './interceptors/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'account',
    component: AccountComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'documents',
    component: DocumentsComponent,
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
    path: 'syllabus',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'choose',
        component: SyllabusPickerComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'document/:fosId/:specId/:year',
        component: SyllabusDocumentComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'acceptance',
        component: SyllabusAcceptanceComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'StudentGovernment'],
            redirectTo: '/noaccess'
          }
        }
      },
    ]
  },
  {
    path: 'learning-outcome',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'choose',
        component: LearningOutcomePickerComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'document/:fosId/:year',
        component: LearningOutcomeDocumentComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
    ]
  },
  {
    path: 'subject',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'choose',
        component: SubjectPickerComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
      {
        path: 'document/:code/:fosId/:specId/:year',
        component: SubjectDocumentComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: {
            only: ['Admin', 'Teacher'],
            redirectTo: '/noaccess'
          }
        }
      },
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
