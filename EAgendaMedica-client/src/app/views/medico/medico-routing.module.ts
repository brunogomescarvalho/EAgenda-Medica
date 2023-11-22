import { NgModule, inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterModule, Routes } from '@angular/router';
import { ListarMedicosComponent } from './listar-medicos/listar-medicos.component';
import { MedicoService } from './services/medico.service';
import { InserirMedicoComponent } from './inserir-medico/inserir-medico.component';
import { EditarMedicoComponent } from './editar-medico/editar-medico.component';


export const selecionarTodosMedicosFN = () => {
  return inject(MedicoService).listarTodos()
}

export const selecionarMedicoPorIdResolve = (route: ActivatedRouteSnapshot) => {
  return inject(MedicoService).buscarPorId(route.params["id"])
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
  },
  {
    path: "inserir",
    component: InserirMedicoComponent,
  },
  {
    path: "editar/:id",
    component: EditarMedicoComponent,
    resolve: { medico: selecionarMedicoPorIdResolve }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedicoRoutingModule { }
