import { NgModule, inject } from "@angular/core";
import { Routes, RouterModule, ResolveFn } from "@angular/router";
import { ListarConsultasComponent } from "../listar-consultas/listar-consultas.component";
import { ConsultaService } from "../consulta.service";
import { ListarAtividades } from "src/app/models/ListarAtividades";


export const selecionarTodasConsultasResolve: ResolveFn<ListarAtividades[]> = () => {
  return inject(ConsultaService).listarTodas()
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
  // {
  //   path: 'inserir',
  //   component: InserirCategoriasComponent
  // },
  // {
  //   path: 'editar/:id',
  //   component: EditarCategoriasComponent,
  //   resolve: { categoria: selecionarCategoriasPorIdResolve }
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultasRouterModule { }
