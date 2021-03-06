import { NgModule } from '@angular/core';
import { UsersComponent } from './users/users.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { UserComponent } from './users/user/user.component';
import { SharedModule } from 'src/app/modules/shared.module';
import { SharedComponentsModule } from '../shared/shared-components.module';
import { UserFormComponent } from './users/user/user-form/user-form.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { UserRolesComponent } from './users/user/user-roles/user-roles.component';
import { FieldsOfStudiesComponent } from './fields-of-studies/fields-of-studies.component';
import { FosListComponent } from './fields-of-studies/fos-list/fos-list.component';
import { FosComponent } from './fields-of-studies/fos/fos.component';
import { FosFormComponent } from './fields-of-studies/fos/fos-form/fos-form.component';
import { FosSpecializationsComponent } from './fields-of-studies/fos/fos-specializations/fos-specializations.component';
import { UserTagsComponent } from './users/user/user-tags/user-tags.component';
import { FosTagsComponent } from './fields-of-studies/fos/fos-tags/fos-tags.component';

@NgModule({
  declarations: [
    UsersComponent,
    UsersListComponent,
    UserComponent,
    UserFormComponent,
    AdminMenuComponent,
    UserRolesComponent,
    FieldsOfStudiesComponent,
    FosListComponent,
    FosComponent,
    FosFormComponent,
    FosSpecializationsComponent,
    UserTagsComponent,
    FosTagsComponent,
  ],
  imports: [SharedModule, SharedComponentsModule],
})
export class AdminModule {}
