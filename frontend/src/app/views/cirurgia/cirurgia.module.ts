import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DialogService } from 'src/app/views/cirurgia/services/dialog-cirurgia.service';

import { MedicoService } from '../medico/services/medico.service';
import { DialogComponentCirurgia } from './componentes/dialogs/visualizar-detalhes/dialog.component';
import { FormCirurgiaComponent } from './componentes/form-cirurgia/form-cirurgia.component';
import { EditarCirurgiaComponent } from './editar-cirurgia/editar-cirurgia.component';
import { InserirCirurgiaComponent } from './inserir-cirurgia/inserir-cirurgia.component';
import { ListarCirurgiasComponent } from './listar-cirurgias/listar-cirurgias.component';
import { CirurgiasRouterModule } from './router/cirurgia-routing.module';
import { CirurgiaService } from './services/cirurgia.service';



@NgModule({
  declarations: [
    ListarCirurgiasComponent,
    FormCirurgiaComponent,
    InserirCirurgiaComponent,
    EditarCirurgiaComponent,
    DialogComponentCirurgia
  ],
  imports: [
    CommonModule,
    AppMaterialModule,
    CirurgiasRouterModule,
    SharedModule
  ],
  providers: [
    CirurgiaService,
    MedicoService,
    DialogService]
})
export class CirurgiaModule { }
