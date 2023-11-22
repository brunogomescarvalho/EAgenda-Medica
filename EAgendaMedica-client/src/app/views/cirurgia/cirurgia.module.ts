import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarCirurgiasComponent } from './listar-cirurgias/listar-cirurgias.component';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CirurgiaService } from './services/cirurgia.service';
import { CirurgiasRouterModule } from './router/cirurgia-routing.module';
import { FormCirurgiaComponent } from './componentes/form-cirurgia/form-cirurgia.component';
import { InserirCirurgiaComponent } from './inserir-cirurgia/inserir-cirurgia.component';
import { MedicoService } from '../medico/services/medico.service';
import { EditarCirurgiaComponent } from './editar-cirurgia/editar-cirurgia.component';

import { DialogService } from 'src/app/views/cirurgia/services/dialog-cirurgia.service';
import { DialogComponentCirurgia } from './componentes/dialogs/visualizar-detalhes/dialog.component';



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
