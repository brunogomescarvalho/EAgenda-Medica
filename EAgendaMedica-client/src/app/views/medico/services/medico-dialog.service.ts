import { EventEmitter, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Top10Medicos, VisualizarMedico } from 'src/app/models/Medicos';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';

import { DialogTop10Component } from '../componentes/dialog-top-10/dialog-top-10.component';
import { DialogVisualizarMedicoComponent } from '../componentes/dialog-visualizar-medico/dialog-visualizar-medico.component';

@Injectable()
export class MedicoDialogService {

  constructor(private dialog: MatDialog,) { }

  datasTop10 = new EventEmitter<any>()

  top10MedicosEvent = new EventEmitter<Top10Medicos[]>()

  detalharMedicoDialog(medico: VisualizarMedico, atividadesDeHoje?: boolean) {
    return this.dialog.open(DialogVisualizarMedicoComponent, {
      width: '400px',
      data: {
        registro: medico,
        atividadesDeHoje: atividadesDeHoje
      }
    })
  }

  excluirMedicoDialog(data: any) {
    return this.dialog.open(DialogExcluirComponent, {
      width: '500px',
      data: {
        titulo:"Excluír",
        registro: "Médico(a)",
        msg: `Confirma excluir o registro: ${data.nome} - ${data.crm} ? Todos os dados relacionado a esse registro também serão excluídos.`
      }
    })
  }

  desativarMedicoDialog(data: any) {
    return this.dialog.open(DialogExcluirComponent, {
      width: '500px',
      data: {
        titulo:`${(data.situacao == "Ativo" ? 'Desativar' : 'Ativar')}`,
        registro: "Médico(a)",
        msg: `Confirma ${(data.situacao == "Ativo" ? 'desativar' : 'ativar')} o Médico: ${data.nome} - ${data.crm} ?`
      }
    })
  }

  mostrarTop10Dialog() {
    return this.dialog.open(DialogTop10Component, {
      width: '400px',
    });
  }


}
