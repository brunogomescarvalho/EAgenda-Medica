import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ListarAtividades } from 'src/app/models/Atividades';

@Component({
  selector: 'app-lista-atividades',
  templateUrl: './lista-atividades.component.html',
  styleUrls: ['./lista-atividades.component.scss']
})
export class ListaAtividadesComponent implements OnInit {

  links = ['Todas', 'Hoje', 'Próximas', 'Passadas'];
  activeLink = this.links[0];

  @Input({ required: true }) atividades$?: Observable<ListarAtividades[]>

  @Output() onAlterarLista = new EventEmitter<string>();

  @Output() onDetalhes = new EventEmitter();

  @Output() onEditar = new EventEmitter();

  @Output() onExcluir = new EventEmitter();

  @Output() onEnviarDatas = new EventEmitter();

  @Input({ required: true }) tipo?: string

  listaVazia: boolean = false;

  form!:FormGroup

  ngOnInit(): void {
    this.iniciarFormPesquisa();
  }

  get tipoCadastro() {
    return this.tipo?.toLowerCase()
  }

  editar(event: ListarAtividades) {
    this.onEditar.emit(event);
  }

  excluir(event: ListarAtividades) {

    let evento = {
      obj: event,
      lista: this.activeLink
    }

    this.onExcluir.emit(evento)
  }

  alterarLista() {
    this.onAlterarLista.emit(this.activeLink)
  }

  detalhes(atividade: ListarAtividades) {
    this.onDetalhes.emit(atividade)
  }

  iniciarFormPesquisa(){
    this.form = new FormGroup({
      start: new FormControl<Date | null>(null, [Validators.required]),
      end: new FormControl<Date | null>(null, Validators.required),
    });

  }

  enviarData(){
    if (this.form?.valid) {
     this.activeLink = ''
      let datas = {
        dt1: new Date(this.form.value.start).toISOString(),
        dt2: new Date(this.form.value.end).toISOString()
      }
      this.onEnviarDatas.emit(datas)
    }
  }
}
