import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FormAtividadeBase } from 'src/app/models/ListarAtividades';
import { AtividadeBaseService } from 'src/app/shared/services/atividade-base.service';

@Injectable({
  providedIn: 'root'
})
export class CirurgiaService extends AtividadeBaseService {

  override httpClient: HttpClient;

  override endpoint!: string;

  constructor(public http: HttpClient) {
    super();

    this.httpClient = http;
  }

  public override inserirAtividade(model: FormAtividadeBase): Observable<any> {
    this.endpoint = "cirurgias"
    return super.inserirAtividade(model)
  }

  public override listarTodas(): Observable<any> {
    this.endpoint = "cirurgias"
    return super.listarTodas()
  }

  public override editarAtividade(model: FormAtividadeBase, id: string): Observable<any> {
    this.endpoint = "cirurgias"
    return super.editarAtividade(model, id);
  }

  public override excluirAtividade(id: string): Observable<any> {
    this.endpoint = "cirurgias"
    return super.excluirAtividade(id);
  }

  public override selecionarPorId(id: string): Observable<any> {
    this.endpoint = "cirurgias"
    return super.selecionarPorId(id);
  }

  public listarParaHoje(): Observable<any> {
    this.endpoint = "cirurgias/hoje"
    return super.listarTodas()
  }

  public listarFuturas(): Observable<any> {
    this.endpoint = "cirurgias/futuras"
    return super.listarTodas()
  }

  public listarPassadas(): Observable<any> {
    this.endpoint = "cirurgias/passadas"
    return super.listarTodas()
  }
}

