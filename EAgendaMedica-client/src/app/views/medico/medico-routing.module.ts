import { NgModule, inject } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarMedicosComponent } from './listar-medicos/listar-medicos.component';
import { MedicoService } from './medico.service';

export const selecionarTodosMedicosFN = () => {
  return inject(MedicoService).listarTodos()
}


const routes: Routes = [
  {
    path: "",
    redirectTo: "listar",
    pathMatch: "full"
  },

  {
    path: "listar",
    component: ListarMedicosComponent,
    resolve: { medicos: selecionarTodosMedicosFN }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedicoRoutingModule { }
