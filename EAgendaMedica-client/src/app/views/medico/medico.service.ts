import { FormMedico } from './../../models/ListarAtividades';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable()
export class MedicoService {

  constructor(private httpClient: HttpClient) { }

  private url: string = " https://localhost:7281/api/medicos"

  public listarTodos() {
    return this.httpClient.get<any[]>(this.url)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public listarTodosPorStatus(ativo: boolean) {
    return this.httpClient.get<any[]>(this.url + `/status?ativo=${ativo}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public buscarPorCRM(crm: string) {
    return this.httpClient.get<any[]>(this.url + `/crm=${crm}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public buscarPorId(id: string) {
    return this.httpClient.get<any[]>(this.url + `/${id}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public buscarTop10(dataInicio: Date, dataFinal: Date) {
    return this.httpClient.get<any[]>(this.url + `/top10?dataInicial=${dataInicio}&dataFinal=${dataFinal}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public alterarStatus(id: string) {
    return this.httpClient.put<any[]>(this.url + `/${id}`, null)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public obterDetalhes(id: string) {
    return this.httpClient.get<any[]>(this.url + `/detalhes/${id}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public editar(id: string, medico: FormMedico) {
    return this.httpClient.put<any[]>(this.url + `/${id}`, medico)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }

  public excluir(id: string) {
    return this.httpClient.delete<any[]>(this.url + `/${id}`)
      .pipe(map((x: any) => x.dados),
        catchError(this.processarErro));
  }


  private processarErro(error: HttpErrorResponse): Observable<any> {
    const errorMessage = error.error.erro[0];
    return throwError(() => new Error(errorMessage));
  }
}
