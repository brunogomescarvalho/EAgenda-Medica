import { CommonModule, DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppMaterialModule } from './app-material/app-material.module';
import { ListaAtividadesComponent } from './componentes/lista-atividades/lista-atividades.component';
import { CardHoverDirective } from './directives/card-hover-directve';
import { DateTimePipe } from './pipes/date-time.pipe';
import { DialogExcluirComponent } from './componentes/dialog-excluir/dialog-excluir.component';
import { LoadingService } from './loading/loadingService';




@NgModule({
  declarations: [
    CardHoverDirective,
    ListaAtividadesComponent,
    DateTimePipe,
    DialogExcluirComponent,
  ],
  imports: [
    CommonModule,
    AppMaterialModule,
    ReactiveFormsModule

  ],
  exports: [
    CardHoverDirective,
    ListaAtividadesComponent,
    FormsModule,
    ReactiveFormsModule,
    DateTimePipe],
  providers: [DateTimePipe]
})
export class SharedModule { }
