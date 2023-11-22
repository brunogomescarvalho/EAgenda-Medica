import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { VisualizarConsulta } from 'src/app/models/Atividades';

import { ConsultaService } from '../../../services/consulta.service';

@Component({
  selector: 'app-visualizar-detalhes-consulta',
  templateUrl: './visualizar-detalhes-consulta.component.html',
  styleUrls: ['./visualizar-detalhes-consulta.component.scss']
})
export class DetalhesConsultaComponent implements OnInit {

  consulta: VisualizarConsulta

  constructor(

    public dialogRef: MatDialogRef<DetalhesConsultaComponent>,

    private service: ConsultaService,

    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.consulta = new VisualizarConsulta()
  }


  ngOnInit(): void {
    this.service.obterDetalhes(this.data.id)
      .subscribe(x => this.consulta = x);
  }
}
