import { Injectable } from '@angular/core';
import { DetalhesConsultaComponent } from '../componentes/dialogs/visualizar-detalhes-consulta/visualizar-detalhes-consulta.component';
import { MatDialog } from '@angular/material/dialog';
import { ListarAtividades } from 'src/app/models/Atividades';

@Injectable()
export class ConsultaDialogService {

  constructor(private dialog: MatDialog,) { }

  visualizarDetalhesConsulta(atividade: ListarAtividades) {
    return this.dialog.open(DetalhesConsultaComponent, {
      width: '400px',
      data: atividade
    })
  }
}
