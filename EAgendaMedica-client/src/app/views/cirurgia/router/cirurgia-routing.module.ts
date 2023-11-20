import { inject, NgModule } from "@angular/core";
import { ResolveFn, Routes, RouterModule } from "@angular/router";
import { ListarAtividades } from "src/app/models/ListarAtividades";
import { CirurgiaService } from "../cirurgia.service";
import { ListarCirurgiasComponent } from "../listar-cirurgias/listar-cirurgias.component";



export const selecionarTodasCirurgiasResolve: ResolveFn<ListarAtividades[]> = () => {
  return inject(CirurgiaService).listarTodas()
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
export class CirurgiasRouterModule { }
