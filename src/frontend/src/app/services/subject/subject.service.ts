import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Subject } from 'src/app/core/models/subject/subject';
import { User } from 'src/app/core/models/user/user';
import { environment } from 'src/environments/environment.prod';
import { AlertService } from '../alerts/alert.service';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  baseUrl = environment.baseUrl + '/api/subject';

  constructor(
    private readonly http: HttpClient,
    private readonly alerts: AlertService
  ) {}

  getAll(fosCode: string, specCode: string, year: string): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.baseUrl + `/all?fos=${fosCode}&spec=${specCode}&year=${encodeURIComponent(year)}`).pipe(
      map((subjects) => {
        return subjects.map((s) => Object.assign(new Subject(), s));
      }),
      catchError(() => {
        this.alerts.showDefaultLoadingDataErrorMessage();
        return of([]);
      })
    );
  }

  getPossibleTeachers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + '/possibleteachers').pipe(
      map((users) => {
        return users.map((u) => Object.assign(new User(), u));
      }),
      catchError(() => {
        this.alerts.showDefaultLoadingDataErrorMessage();
        return of([]);
      })
    );
  }

  getLatest(fosCode: string, specCode: string, code: string, year: string): Observable<Subject | null> {
    return this.http.get<Subject>(this.baseUrl + `/latest?fos=${fosCode}&spec=${specCode}&code=${code}&year=${encodeURIComponent(year)}`).pipe(
      catchError(err => {
        if (err.status === 403) {
          this.alerts.showCustomErrorMessage('Nie posiadasz uprawnień do tego dokumentu');
        }
        else if (err.status === 404) {
          this.alerts.showCustomErrorMessage('Dokument nie istnieje!');
        }
        else {
          this.alerts.showDefaultLoadingDataErrorMessage();
        }
        return of(null);
      })
    );
  }

  save(sub: Subject): Observable<boolean> {
    return this.http.post<any>(this.baseUrl + '/save', sub).pipe(
      map(() => {
        return true;
      }),
      catchError(err => {
        if (err.status === 403) {
          this.alerts.showCustomErrorMessage('Nie posiadasz uprawnień do tego dokumentu');
        }
        else if (err.status === 409) {
          this.alerts.showCustomErrorMessage('Przedmiot o podanym kodzie już istnieje!');
        }
        else if (err.status === 404) {
          this.alerts.showCustomErrorMessage('Podany kierunek studiów lub specjalizacja nie istnieje');
        }
        else if (err.status === 0 || err.status === 500) {
          this.alerts.showDefaultErrorMessage();
        }
        else {
          this.alerts.showDefaultWrongDataErrorMessage();
        }
        return of(false);
      })
    );
  }

  importFrom(id: string, fosCode: string, specCode: string, code: string, year: string): Observable<boolean> {
    return this.http.get<any>(this.baseUrl + `/importFrom/${id}?fos=${fosCode}&spec=${specCode}&code=${code}&year=${encodeURIComponent(year)}`).pipe(
      map(() => {
        return true;
      }),
      catchError(err => {
        if (err.status === 403) {
          this.alerts.showCustomErrorMessage('Nie posiadasz uprawnień do tego dokumentu');
        }
        else if (err.status === 404) {
          this.alerts.showCustomErrorMessage('Wybrany dokument do zaimportowania nie istnieje!');
        }
        else if (err.status === 0 || err.status === 500) {
          this.alerts.showDefaultErrorMessage();
        }
        else {
          this.alerts.showDefaultWrongDataErrorMessage();
        }

        return of(false);
      })
    );
  }

  delete(id: string): Observable<boolean> {
    return this.http.delete<any>(this.baseUrl + `/delete/${id}`).pipe(
      map(() => {
        return true;
      }),
      catchError(err => {
        if (err.status === 403) {
          this.alerts.showCustomErrorMessage('Nie posiadasz uprawnień do tego dokumentu');
        }
        else if (err.status === 404) {
          this.alerts.showCustomErrorMessage('Dokument nie istnieje');
        }
        else {
          this.alerts.showDefaultErrorMessage();
        }
        return of(false);
      })
    );
  }

  pdf(id: string): Observable<any> {
    return this.http.get(this.baseUrl + `/pdf/${id}`, { observe: 'response', responseType: 'blob' }).pipe(
      catchError(err => {
        if (err.status === 404) {
          this.alerts.showCustomErrorMessage('Dokument nie istnieje!');
        }
        else {
          this.alerts.showDefaultDocumentDownloadFailMessage();
        }
        return of(false);
      })
    );
  }

  history(id: string): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + `/history/${id}`).pipe(
      catchError(() => {
        this.alerts.showDefaultLoadingDataErrorMessage();
        return of([]);
      })
    );
  }
}
