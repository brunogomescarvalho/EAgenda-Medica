import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell/shell.component';
import { AppMaterialModule } from 'src/app/shared/app-material/app-material.module';




@NgModule({
  declarations: [ShellComponent],
  imports: [
    CommonModule,
    AppMaterialModule

  ],
  exports:[ShellComponent]
})
export class CoreModule { }
