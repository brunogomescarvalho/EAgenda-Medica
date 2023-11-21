import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormBuilder, FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { ListarMedicos, FormCirurgia } from "src/app/models/ListarAtividades";


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

  constructor(private fb: FormBuilder) { }


  ngOnInit(): void {

    this.form = this.fb.group({
      dataInicio: new FormControl(),
      horaInicio: new FormControl(),
      duracaoEmMinutos: new FormControl(),
      medicosIds: new FormControl()
    });

    if (this.cirurgia)
      this.form.patchValue(this.cirurgia)

      console.log(this.cirurgia)

  }

  salvar() {

    let cirurgia: FormCirurgia = this.form.value;

    this.onEnviarCirurgia.emit(cirurgia)

  }
}


