import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListarMedicos, VisualizarMedico } from 'src/app/models/Medicos';
import { DialogVisualizarMedicoComponent } from '../componentes/dialog-visualizar-medico/dialog-visualizar-medico.component';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';

@Injectable()
export class MedicoDialogService {

  constructor(private dialog: MatDialog,) { }

  visualizarDetalhesMedico(medico: VisualizarMedico) {
    return this.dialog.open(DialogVisualizarMedicoComponent, {
      width: '400px',
      data: medico
    })
  }

  excluirMedicoDialog(data: any) {
    return this.dialog.open(DialogExcluirComponent, {
      width: '500px',
      data: {
        registro: "Médico(a)",
        msg: `Confirma excluir o Médico: ${data.nome} - ${data.crm} ? Todos os dados relacionado a esse registro também serão excluídos.`
      }
    })
  }
}
