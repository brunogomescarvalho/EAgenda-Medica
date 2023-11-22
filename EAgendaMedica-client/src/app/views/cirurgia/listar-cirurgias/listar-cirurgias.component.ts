import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { ListarAtividades } from 'src/app/models/Atividades';
import { DialogService } from 'src/app/views/cirurgia/services/dialog-cirurgia.service';

import { CirurgiaService } from '../services/cirurgia.service';

@Component({
  selector: 'app-listar-cirurgias',
  templateUrl: './listar-cirurgias.component.html',
  styleUrls: ['./listar-cirurgias.component.scss']
})
export class ListarCirurgiasComponent implements OnInit {

  cirurgias$!: Observable<ListarAtividades[]>

  constructor(
    private cirurgiaService: CirurgiaService,
    private route: ActivatedRoute,
    private router: Router,
    private serviceDialog: DialogService) {

  }
  ngOnInit(): void {
    this.cirurgias$ = this.route.data.pipe(map(x => x["cirurgias"]))
  }

  editar(cirurgia: ListarAtividades) {
    this.router.navigate(["editar", cirurgia.id], { relativeTo: this.route.parent })
  }

  detalhes(cirurgia: ListarAtividades) {
    this.cirurgiaService.obterDetalhes(cirurgia.id!)
      .subscribe(x => this.serviceDialog.visualizarDetalhesCirurgia(x))

  }

  public alterarLista(event: string) {

    switch (event) {
      case "Todas": this.cirurgias$ = this.cirurgiaService.listarTodas(); break;
      case "Próximas": this.cirurgias$ = this.cirurgiaService.listarFuturas(); break;
      case "Passadas": this.cirurgias$ = this.cirurgiaService.listarPassadas(); break;
      case "Hoje": this.cirurgias$ = this.cirurgiaService.listarParaHoje(); break;

    }
  }
}
