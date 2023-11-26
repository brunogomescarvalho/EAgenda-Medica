
import { NgModule, inject } from "@angular/core";
import { Routes, RouterModule, ResolveFn, ActivatedRouteSnapshot } from "@angular/router";
import { ListarConsultasComponent } from "../listar-consultas/listar-consultas.component";
import { ConsultaService } from "../services/consulta.service";
import { ListarAtividades } from "src/app/models/Atividades";
import { InserirConsultaComponent } from "../inserir-consulta/inserir-consulta.component";
import { selecionarMedicosResolve } from "../../cirurgia/router/cirurgia-routing.module";
import { EditarConsultaComponent } from "../editar-consulta/editar-consulta.component";


export const selecionarTodasConsultasResolve: ResolveFn<ListarAtividades[]> = () => {
  return inject(ConsultaService).listarTodas()
}

export const selecionarConsultaPorIdResolve = (route: ActivatedRouteSnapshot) => {
  return inject(ConsultaService).selecionarPorId(route.params["id"]);
}

const routes: Routes = [
  {
    path: "",
    redirectTo: 'listar',
    pathMatch: 'full'
  },
  {
    path: 'listar',
    component: ListarConsultasComponent,
    resolve: { consultas: selecionarTodasConsultasResolve }
  },
  {
    path: 'inserir',
    component: InserirConsultaComponent,
    resolve: { medicos: selecionarMedicosResolve }
  },
  {
    path: 'editar/:id',
    component: EditarConsultaComponent,
    resolve: { consulta: selecionarConsultaPorIdResolve, medicos: selecionarMedicosResolve }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultasRouterModule { }
