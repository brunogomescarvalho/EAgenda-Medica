import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardAtividadesComponent } from './componentes/card-atividades/card-atividades.component';
import { AppMaterialModule } from './app-material/app-material.module';
import { CardHoverDirective } from './directives/card-hover-directve';
import { ListaAtividadesComponent } from './componentes/lista-atividades/lista-atividades.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CardAtividadesComponent,
    CardHoverDirective,
    ListaAtividadesComponent
  ],
  imports: [
    CommonModule,
    AppMaterialModule,

  ],
  exports:[
    CardAtividadesComponent,
    CardHoverDirective,
    ListaAtividadesComponent,
    FormsModule,
    ReactiveFormsModule]
})
export class SharedModule { }
