import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { FormAtividadeBase, ListarAtividades } from 'src/app/models/ListarAtividades';

@Component({
  selector: 'app-lista-atividades',
  templateUrl: './lista-atividades.component.html',
  styleUrls: ['./lista-atividades.component.scss']
})
export class ListaAtividadesComponent {
  links = ['Todas', 'Hoje', 'Próximas', 'Passadas'];
  activeLink = this.links[0];

  @Input({ required: true }) atividades$?: Observable<ListarAtividades[]>

  @Output() onAlterarLista = new EventEmitter<string>();

  @Output() onEditar = new EventEmitter();

  @Input({ required: true }) tipo?: string

  get tipoCadastro() {
    return this.tipo?.toLowerCase()
  }

  editar(event: ListarAtividades) {
    this.onEditar.emit(event);
  }

  alterarLista() {
    this.onAlterarLista.emit(this.activeLink)
  }
}
