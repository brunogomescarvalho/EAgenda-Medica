import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable, map } from 'rxjs';
import { FormCirurgia, ListarMedicos } from 'src/app/models/ListarAtividades';

@Component({
  selector: 'app-form-cirurgia',
  templateUrl: './form-cirurgia.component.html',
  styleUrls: ['./form-cirurgia.component.scss']
})
export class FormCirurgiaComponent implements OnInit {

  @Input({ required: true }) medicos$!: Observable<ListarMedicos[]>

  form!: FormGroup

  @Input() cirurgia?: FormCirurgia

  @Output() onEnviarCirurgia = new EventEmitter();

  constructor(private fb: FormBuilder) { }


  ngOnInit(): void {


    this.form = this.fb.group({
      data: new FormControl(),
      horaInicio: new FormControl(),
      duracaoEmMinutos: new FormControl(),
      medicos: new FormControl()
    });

    if (this.cirurgia)
      this.form.patchValue(this.cirurgia)
  }

  salvar() {

    let cirurgia: FormCirurgia = this.form.value;

    this.onEnviarCirurgia.emit(cirurgia)

  }
}


