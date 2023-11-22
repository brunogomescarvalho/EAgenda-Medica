import { Component, Inject, OnInit } from '@angular/core';
import { VisualizarCirurgia } from 'src/app/models/Atividades';
import { CirurgiaService } from '../../../services/cirurgia.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponentCirurgia implements OnInit {

  cirurgia!: VisualizarCirurgia

  constructor(

    public dialogRef: MatDialogRef<DialogComponentCirurgia>,

    private service: CirurgiaService,

    @Inject(MAT_DIALOG_DATA) public data: any) { }


  ngOnInit(): void {
    this.service.obterDetalhes(this.data.id)
      .subscribe(x => this.cirurgia = x);
  }

}




