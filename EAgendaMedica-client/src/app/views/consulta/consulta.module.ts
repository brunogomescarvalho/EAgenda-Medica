import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { MedicoService } from '../medico/services/medico.service';
import { ConsultaService } from './services/consulta.service';
import { EditarConsultaComponent } from './editar-consulta/editar-consulta.component';
import { FormConsultaComponent } from './componentes/form-consulta/form-consulta.component';
import { InserirConsultaComponent } from './inserir-consulta/inserir-consulta.component';
import { ListarConsultasComponent } from './listar-consultas/listar-consultas.component';
import { ConsultasRouterModule } from './router/consultas-routing.module';
import { DialogService } from '../cirurgia/services/dialog-cirurgia.service';
import { DetalhesConsultaComponent } from './componentes/dialogs/visualizar-detalhes-consulta/visualizar-detalhes-consulta.component';
import { ConsultaDialogService } from './services/consulta-dialog.service';



@NgModule({
  declarations: [
    ListarConsultasComponent,
    FormConsultaComponent,
    InserirConsultaComponent,
    EditarConsultaComponent,
    DetalhesConsultaComponent
  ],
  imports: [
    CommonModule,
    ConsultasRouterModule,
    AppMaterialModule,
    SharedModule
  ],
  providers: [
    ConsultaService,
    MedicoService,
    ConsultaDialogService]
})
export class ConsultaModule { }
