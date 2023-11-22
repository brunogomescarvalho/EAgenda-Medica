import { CirurgiaService } from '../services/cirurgia.service';
import { inject, NgModule } from "@angular/core";
import { Routes, RouterModule, ActivatedRouteSnapshot } from "@angular/router";

import { ListarCirurgiasComponent } from "../listar-cirurgias/listar-cirurgias.component";
import { InserirCirurgiaComponent } from "../inserir-cirurgia/inserir-cirurgia.component";
import { EditarCirurgiaComponent } from "../editar-cirurgia/editar-cirurgia.component";
import { MedicoService } from "../../medico/medico.service";



export const selecionarTodasCirurgiasResolve = () => {
  return inject(CirurgiaService).listarTodas()
}

export const selecionarMedicosResolve = () => {
  return inject(MedicoService).listarTodosPorStatus(true);
}

export const selecionarPorIdResolve = (route: ActivatedRouteSnapshot) => {
  return inject(CirurgiaService).selecionarPorId(route.params["id"])
}

const routes: Routes = [
  {
    path: "",
    redirectTo: 'listar',
    pathMatch: 'full'
  },
  {
    path: 'listar',
    component: ListarCirurgiasComponent,
    resolve: { cirurgias: selecionarTodasCirurgiasResolve }
  },
  {
    path: 'inserir',
    component: InserirCirurgiaComponent,
    resolve: { medicos: selecionarMedicosResolve }
  },
  {
    path: 'editar/:id',
    component: EditarCirurgiaComponent,
    resolve: {
      medicos: selecionarMedicosResolve,
      cirurgia: selecionarPorIdResolve
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CirurgiasRouterModule { }
