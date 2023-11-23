import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedicoRoutingModule } from './medico-routing.module';
import { ListarMedicosComponent } from './listar-medicos/listar-medicos.component';
import { MedicoService } from './services/medico.service';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DialogVisualizarMedicoComponent } from './componentes/dialog-visualizar-medico/dialog-visualizar-medico.component';
import { MedicoDialogService } from './services/medico-dialog.service';
import { FormMedicoComponent } from './componentes/form-medico/form-medico.component';
import { InserirMedicoComponent } from './inserir-medico/inserir-medico.component';
import { EditarMedicoComponent } from './editar-medico/editar-medico.component';
import { DialogTop10Component } from './componentes/dialog-top-10/dialog-top-10.component';


@NgModule({
  declarations:
    [
      ListarMedicosComponent,
      DialogVisualizarMedicoComponent,
      FormMedicoComponent,
      InserirMedicoComponent,
      EditarMedicoComponent,
      DialogTop10Component],
  imports: [
    CommonModule,
    MedicoRoutingModule,
    AppMaterialModule,
    SharedModule

  ],
  providers: [
    MedicoService,
    MedicoDialogService]
})
export class MedicoModule { }
