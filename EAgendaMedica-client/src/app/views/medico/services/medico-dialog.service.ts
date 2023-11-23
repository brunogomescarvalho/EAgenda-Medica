import { EventEmitter, Injectable, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListarMedicos, Top10Medicos, VisualizarMedico } from 'src/app/models/Medicos';
import { DialogVisualizarMedicoComponent } from '../componentes/dialog-visualizar-medico/dialog-visualizar-medico.component';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';
import { DialogTop10Component } from '../componentes/dialog-top-10/dialog-top-10.component';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class MedicoDialogService {

  constructor(private dialog: MatDialog,) { }

  datasTop10 = new EventEmitter<any>()

  top10MedicosEvent = new EventEmitter<Top10Medicos[] | null>()

  detalharMedicoDialog(medico: VisualizarMedico) {
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

  mostrarTop10Dialog() {

    return this.dialog.open(DialogTop10Component, {
      width: '400px',
    });
  }


}
