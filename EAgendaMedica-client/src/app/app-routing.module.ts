import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './views/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "dashboard",
    pathMatch: "full"
  },
  {
    path: "dashboard",
    component: DashboardComponent
  },
  {
    path: "consultas",
    loadChildren: () => import("./views/consulta/consulta.module")
      .then(c => c.ConsultaModule)
  },
  {
    path: "cirurgias",
    loadChildren: () => import("./views/cirurgia/cirurgia.module")
      .then(c => c.CirurgiaModule)
  },
  {
    path: "medicos",
    loadChildren: () => import("./views/medico/medico.module")
      .then(c => c.MedicoModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
