import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { VisualizarConsulta } from 'src/app/models/Atividades';

@Component({
  selector: 'app-visualizar-detalhes-consulta',
  templateUrl: './visualizar-detalhes-consulta.component.html',
  styleUrls: ['./visualizar-detalhes-consulta.component.scss']
})
export class DetalhesConsultaComponent implements OnInit {

  consulta: VisualizarConsulta

  constructor(

    public dialogRef: MatDialogRef<DetalhesConsultaComponent>,

    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.consulta = new VisualizarConsulta()
  }


  ngOnInit(): void {
    this.consulta = this.data
  }
}
