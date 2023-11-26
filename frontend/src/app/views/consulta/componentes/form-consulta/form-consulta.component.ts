import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { FormConsulta } from 'src/app/models/Atividades';
import { ListarMedicos } from 'src/app/models/Medicos';
import { DateTimePipe } from 'src/app/shared/pipes/date-time.pipe';


@Component({
  selector: 'app-form-consulta',
  templateUrl: './form-consulta.component.html',
  styleUrls: ['./form-consulta.component.scss']
})
export class FormConsultaComponent implements OnInit {

  @Input({ required: true }) medicos$!: Observable<ListarMedicos[]>

  form!: FormGroup

  @Input() consulta: FormConsulta | null = null

  @Output() onEnviarConsulta = new EventEmitter();

  constructor(private fb: FormBuilder, private datePipe: DateTimePipe) { }


  ngOnInit(): void {

    this.form = this.fb.group({
      dataInicio: new FormControl(null, Validators.required),
      horaInicio: new FormControl(null, Validators.required),
      duracaoEmMinutos: new FormControl(null, [Validators.required, Validators.min(30), Validators.max(120)]),
      medicoId: new FormControl(null, Validators.required)
    });

    if (this.consulta) {
      let consulta = {
        ...this.consulta,
        dataInicio: this.datePipe.transform(this.consulta.dataInicio!)
      }

      this.form.patchValue(consulta)
    }

  }

  salvar() {
    let consulta: FormConsulta = this.form.value;

    this.onEnviarConsulta.emit(consulta)
  }
}

