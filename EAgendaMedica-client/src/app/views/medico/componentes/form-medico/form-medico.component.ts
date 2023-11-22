import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { FormMedico } from 'src/app/models/Medicos';

@Component({
  selector: 'app-form-medico',
  templateUrl: './form-medico.component.html',
  styleUrls: ['./form-medico.component.scss']
})
export class FormMedicoComponent implements OnInit {

  @Input() medico: FormMedico | null = null

  @Output() onEnviarMedico = new EventEmitter()

  form!: FormGroup

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      nome: new FormControl(),
      crm: new FormControl()
    })

    if (this.medico)
      this.form.patchValue(this.medico)
  }

  salvar() {
    if (this.form.valid) {
      let medico = this.form.value
      this.onEnviarMedico.emit(medico)
    }
  }



}
