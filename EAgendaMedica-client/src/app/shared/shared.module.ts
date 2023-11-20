import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardAtividadesComponent } from './componentes/card-atividades/card-atividades.component';
import { AppMaterialModule } from './app-material/app-material.module';
import { CardHoverDirective } from './directives/card-hover-directve';
import { ListaAtividadesComponent } from './componentes/lista-atividades/lista-atividades.component';



@NgModule({
  declarations: [
    CardAtividadesComponent,
    CardHoverDirective,
    ListaAtividadesComponent
  ],
  imports: [
    CommonModule,
    AppMaterialModule
  ],
  exports:[
    CardAtividadesComponent,
    CardHoverDirective,
    ListaAtividadesComponent]
})
export class SharedModule { }
