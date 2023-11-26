import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell/shell.component';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from '../views/dashboard/dashboard.component';




@NgModule({
  declarations: [ShellComponent, DashboardComponent,],
  imports: [
    CommonModule,
    AppMaterialModule,


  ],
  exports: [ShellComponent, DashboardComponent,]
})
export class CoreModule { }
