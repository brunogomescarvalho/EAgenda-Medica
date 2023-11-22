import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { MedicoService } from '../medico/medico.service';
import { ConsultaService } from './consulta.service';
import { EditarConsultaComponent } from './editar-consulta/editar-consulta.component';
import { FormConsultaComponent } from './form-consulta/form-consulta.component';
import { InserirConsultaComponent } from './inserir-consulta/inserir-consulta.component';
import { ListarConsultasComponent } from './listar-consultas/listar-consultas.component';
import { ConsultasRouterModule } from './router/consultas-routing.module';



@NgModule({
  declarations: [
    ListarConsultasComponent,
    FormConsultaComponent,
    InserirConsultaComponent,
    EditarConsultaComponent
  ],
  imports: [
    CommonModule,
    ConsultasRouterModule,
    AppMaterialModule,
    SharedModule
  ],
  providers:[ConsultaService,MedicoService]
})
export class ConsultaModule { }
