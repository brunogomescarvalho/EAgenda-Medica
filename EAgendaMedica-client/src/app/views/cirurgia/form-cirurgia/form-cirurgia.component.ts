import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormBuilder, FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { FormCirurgia } from "src/app/models/Atividades";
import { ListarMedicos } from "src/app/models/Medicos";
import { DateTimePipe } from "src/app/shared/pipes/date-time.pipe";

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
      dataInicio: new FormControl(),
      horaInicio: new FormControl(),
      duracaoEmMinutos: new FormControl(),
      medicosIds: new FormControl()
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
    let cirurgia: FormCirurgia = this.form.value;
    this.onEnviarCirurgia.emit(cirurgia)
  }
}


