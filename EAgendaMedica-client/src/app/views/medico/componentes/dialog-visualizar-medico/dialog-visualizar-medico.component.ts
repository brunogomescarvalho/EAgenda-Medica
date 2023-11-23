import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { VisualizarMedico } from 'src/app/models/Medicos';

@Component({
  selector: 'app-dialog-visualizar-medico',
  templateUrl: './dialog-visualizar-medico.component.html',
  styleUrls: ['./dialog-visualizar-medico.component.scss']
})
export class DialogVisualizarMedicoComponent implements OnInit {

  medico: VisualizarMedico

  constructor(

    public dialogRef: MatDialogRef<DialogVisualizarMedicoComponent>,

    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.medico = new VisualizarMedico()
  }

  ngOnInit(): void {
    this.medico = this.data.registro;
  }
}
