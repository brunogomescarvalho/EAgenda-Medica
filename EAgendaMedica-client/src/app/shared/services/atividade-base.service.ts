import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs';
import { FormAtividadeBase } from 'src/app/models/Atividades';

@Injectable()
export abstract class AtividadeBaseService {

  constructor() { }

  abstract httpClient: HttpClient

  private url: string = " https://localhost:7281/api/"

  abstract endpoint: string

  public inserirAtividade(model: FormAtividadeBase) {
    return this.httpClient.post(this.url + this.endpoint, model)
      .pipe(catchError((erro: HttpErrorResponse) => erro.processarErro()))
  }

  public editarAtividade(model: FormAtividadeBase, id: string) {
    let caminho = this.url + this.endpoint + `/${id}`;
    return this.httpClient.put(caminho, model)
      .pipe(catchError((erro: HttpErrorResponse) => erro.processarErro()))
  }

  public excluirAtividade(id: string) {
    return this.httpClient.delete(this.url + this.endpoint + `/${id}`)
      .pipe(catchError((erro: HttpErrorResponse) => erro.processarErro()));
  }

  public selecionarPorId(id: string) {
    return this.httpClient.get(this.url + this.endpoint + `/${id}`)
      .pipe(map((x: any) => x.dados),
        catchError((erro: HttpErrorResponse) => erro.processarErro()));
  }

  public listarTodas() {
    return this.httpClient.get<any[]>(this.url + this.endpoint)
      .pipe(map((x: any) => x.dados),
        catchError((erro: HttpErrorResponse) => erro.processarErro()));
  }

}


