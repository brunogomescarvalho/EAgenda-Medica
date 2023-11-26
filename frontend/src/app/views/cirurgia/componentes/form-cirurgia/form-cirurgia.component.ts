import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { FormCirurgia } from 'src/app/models/Atividades';
import { ListarMedicos } from 'src/app/models/Medicos';
import { DateTimePipe } from 'src/app/shared/pipes/date-time.pipe';


@Component({
  selector: 'app-form-cirurgia',
  templateUrl: './form-cirurgia.component.html',
  styleUrls: ['./form-cirurgia.component.scss']
})

export class FormCirurgiaComponent implements OnInit {

  @Input({ required: true }) medicos$!: Observable<ListarMedicos[]>

  form!: FormGroup

  @Input() cirurgia: FormCirurgia | null = null

  @Output() onEnviarCirurgia = new EventEmitter();

  constructor(private fb: FormBuilder, private datePipe: DateTimePipe) { }


  ngOnInit(): void {

    this.form = this.fb.group({
      dataInicio: new FormControl(null, [Validators.required]),
      horaInicio: new FormControl(null, [Validators.required]),
      duracaoEmMinutos: new FormControl(null, [Validators.required, Validators.min(120), Validators.max(1440)]),
      medicosIds: new FormControl(null, [Validators.required])
    });

    if (this.cirurgia) {
      let cirurgia = {
        ...this.cirurgia,
        dataInicio: this.datePipe.transform(this.cirurgia.dataInicio!)
      }

      this.form.patchValue(cirurgia)
    }

  }

  salvar() {
    if (this.form.valid) {
      let cirurgia: FormCirurgia = this.form.value;
      this.onEnviarCirurgia.emit(cirurgia)
    }
  }
}


