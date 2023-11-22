
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListarAtividades } from 'src/app/models/Atividades';
import { DialogComponentCirurgia } from 'src/app/views/cirurgia/componentes/dialogs/visualizar-detalhes/dialog.component';

@Injectable()
export class DialogService {
  constructor(private dialog: MatDialog,) { }


  visualizarDetalhesCirurgia(atividade: ListarAtividades) {
    return this.dialog.open(DialogComponentCirurgia, {
      width: '400px',
      data: atividade
    })
  }
}

