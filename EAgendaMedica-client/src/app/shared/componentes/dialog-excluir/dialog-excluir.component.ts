import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-excluir',
  templateUrl: './dialog-excluir.component.html',
  styleUrls: ['./dialog-excluir.component.scss']
})
export class DialogExcluirComponent {

  constructor(public dialogRef: MatDialogRef<DialogExcluirComponent>,

    @Inject(MAT_DIALOG_DATA) public data: any) {

    { }
  }
}
