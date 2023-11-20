import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedicoRoutingModule } from './medico-routing.module';
import { ListarMedicosComponent } from './listar-medicos/listar-medicos.component';
import { MedicoService } from './medico.service';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';


@NgModule({
  declarations: [ListarMedicosComponent],
  imports: [
    CommonModule,
    MedicoRoutingModule,
    AppMaterialModule
  ],
  providers:[MedicoService]
})
export class MedicoModule { }
