import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Top10Medicos } from 'src/app/models/Medicos';

import { MedicoDialogService } from '../../services/medico-dialog.service';


@Component({
  selector: 'app-dialog-top-10',
  templateUrl: './dialog-top-10.component.html',
  styleUrls: ['./dialog-top-10.component.scss']
})
export class DialogTop10Component implements OnInit {

  medicos: Top10Medicos[] | null = []

  form!: FormGroup

  constructor(public dialogRef: MatDialogRef<DialogTop10Component>, private service: MedicoDialogService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      start: new FormControl<Date | null>(null),
      end: new FormControl<Date | null>(null),
    });

    this.service.top10MedicosEvent.asObservable()
    .subscribe(x => this.medicos = x)

  }

  enviarData() {
    if (this.form?.valid) {
      let datas = {
        dt1: new Date(this.form.value.start).toISOString(),
        dt2: new Date(this.form.value.end).toISOString()
      }
      this.service.datasTop10?.next(datas)
    }
  }
}
