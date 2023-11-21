import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { FormAtividadeBase } from 'src/app/models/ListarAtividades';

@Injectable()
export abstract class AtividadeBaseService {

  constructor() { }

  abstract httpClient: HttpClient

  private url: string = " https://localhost:7281/api/"

  abstract endpoint: string

  public inserirAtividade(model: FormAtividadeBase) {
    return this.httpClient.post(this.url + this.endpoint, model)
      .pipe(catchError(this.processarErro));
  }

  public editarAtividade(model: FormAtividadeBase, id: string) {
    return this.httpClient.put(this.url + this.endpoint + `/${id}`, model)
      .pipe(catchError(this.processarErro));
  }

  public excluirAtividade(id: string) {
    return this.httpClient.delete(this.url + this.endpoint + `/${id}`)
      .pipe(catchError(this.processarErro));
  }

  public selecionarPorId(id: string) {
    return this.httpClient.get(this.url + this.endpoint + `/${id}`)
      .pipe(map((x: any) => x.dados), catchError(this.processarErro));
  }

  public listarTodas() {
    return this.httpClient.get<any[]>(this.url + this.endpoint)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }


  private processarErro(error: HttpErrorResponse): Observable<any> {
    const errorMessage = error.error.erro[0];
    return throwError(() => new Error(errorMessage));
  }

}


