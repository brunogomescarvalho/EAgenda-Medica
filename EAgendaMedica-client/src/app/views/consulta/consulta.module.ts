import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarConsultasComponent } from './listar-consultas/listar-consultas.component';
import { ConsultasRouterModule } from './router/consultas-routing.module';
import { ConsultaService } from './consulta.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';



@NgModule({
  declarations: [
    ListarConsultasComponent
  ],
  imports: [
    CommonModule,
    ConsultasRouterModule,
    AppMaterialModule,
    SharedModule
  ],
  providers:[ConsultaService]
})
export class ConsultaModule { }
