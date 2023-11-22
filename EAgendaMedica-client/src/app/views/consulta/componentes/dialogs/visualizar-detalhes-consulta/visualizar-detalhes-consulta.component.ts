import { Component, Inject, OnInit } from '@angular/core';
import { ConsultaService } from '../../../services/consulta.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { VisualizarConsulta } from 'src/app/models/Atividades';

@Component({
  selector: 'app-visualizar-detalhes-consulta',
  templateUrl: './visualizar-detalhes-consulta.component.html',
  styleUrls: ['./visualizar-detalhes-consulta.component.scss']
})
export class DetalhesConsultaComponent implements OnInit {

  consulta!: VisualizarConsulta

  constructor(

    public dialogRef: MatDialogRef<DetalhesConsultaComponent>,

    private service: ConsultaService,

    @Inject(MAT_DIALOG_DATA) public data: any) { }


  ngOnInit(): void {
    this.service.obterDetalhes(this.data.id)
      .subscribe(x => this.consulta = x);
  }
}
