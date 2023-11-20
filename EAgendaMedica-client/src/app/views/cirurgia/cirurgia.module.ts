import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarCirurgiasComponent } from './listar-cirurgias/listar-cirurgias.component';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CirurgiaService } from './cirurgia.service';
import { CirurgiasRouterModule } from './router/cirurgia-routing.module';
import { FormCirurgiaComponent } from './form-cirurgia/form-cirurgia.component';



@NgModule({
  declarations: [
    ListarCirurgiasComponent,
    FormCirurgiaComponent
  ],
  imports: [
    CommonModule,
    AppMaterialModule,
    CirurgiasRouterModule,
    SharedModule
  ], providers: [CirurgiaService]
})
export class CirurgiaModule { }
