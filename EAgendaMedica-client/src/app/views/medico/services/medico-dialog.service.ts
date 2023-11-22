import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListarMedicos, VisualizarMedico } from 'src/app/models/Medicos';
import { DialogVisualizarMedicoComponent } from '../componentes/dialog-visualizar-medico/dialog-visualizar-medico.component';

@Injectable()
export class MedicoDialogService {

  constructor(private dialog: MatDialog,) { }

  visualizarDetalhesMedico(atividade: VisualizarMedico) {
    return this.dialog.open(DialogVisualizarMedicoComponent, {
      width: '400px',
      data: atividade
    })
  }
}
