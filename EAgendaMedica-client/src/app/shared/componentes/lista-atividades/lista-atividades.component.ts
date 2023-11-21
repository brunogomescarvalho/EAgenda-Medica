import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { ListarAtividades } from 'src/app/models/ListarAtividades';

@Component({
  selector: 'app-lista-atividades',
  templateUrl: './lista-atividades.component.html',
  styleUrls: ['./lista-atividades.component.scss']
})
export class ListaAtividadesComponent {
  links = ['Todas', 'Hoje', 'Próximas', 'Passadas'];
  activeLink = this.links[0];

  @Input({required:true}) atividades$?: Observable<ListarAtividades[]>

  @Output() onAlterarLista = new EventEmitter<string>();

  @Input({ required: true }) tipo?: string

  get tipoCadastro(){
    return this.tipo?.toLowerCase()
  }



  alterarLista() {
    this.onAlterarLista.emit(this.activeLink)
  }
}
