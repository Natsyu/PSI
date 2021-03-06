import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './modules/shared.module';
import { HomeModule } from './components/home/home.module';
import { AuthenticationModule } from './components/authentication/authentication.module';
import { AdminModule } from './components/admin/admin.module';
import { LearningOutcomesModule } from './components/learning-outcomes/learning-outcomes.module';
import { SubjectsModule } from './components/subjects/subjects.module';
import { SyllabusesModule } from './components/syllabuses/syllabuses.module';
import { DocumentsModule } from './components/documents/documents.module';
import { SharedComponentsModule } from './components/shared/shared-components.module';
import { UserModule } from './components/user/user.module';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';

@NgModule({
  declarations: [AppComponent, LeftMenuComponent],
  imports: [
    BrowserModule,
    SharedModule,
    HomeModule,
    SharedComponentsModule,
    AuthenticationModule,
    AdminModule,
    LearningOutcomesModule,
    SubjectsModule,
    SyllabusesModule,
    DocumentsModule,
    UserModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
