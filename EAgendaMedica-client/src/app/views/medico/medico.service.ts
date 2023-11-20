import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable()
export class MedicoService {

  constructor(private httpClient : HttpClient) { }

  private url: string = " https://localhost:7281/api/medicos"

  private endpoint!: string

  public listarTodos() {
    return this.httpClient.get<any[]>(this.url)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  private processarErro(error: HttpErrorResponse): Observable<any> {
    const errorMessage = error.error.erro[0];
    return throwError(() => new Error(errorMessage));
  }
}
