import { Component, Input } from '@angular/core';
import { ListarAtividades } from 'src/app/models/ListarAtividades';

@Component({
  selector: 'app-card-atividades',
  templateUrl: './card-atividades.component.html',
  styleUrls: ['./card-atividades.component.scss']
})
export class CardAtividadesComponent {

  @Input({ required: true }) atividade!: ListarAtividades
}
