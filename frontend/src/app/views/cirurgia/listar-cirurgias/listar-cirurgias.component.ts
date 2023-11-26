import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable, of } from 'rxjs';
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
    private serviceDialog: DialogService,
    private snack: MatSnackBar) {

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

  excluir(event: any) {
    let result = this.serviceDialog.excluirCirurgia(event.obj);

    result.afterClosed().subscribe(x => {
      if (x == true) {
        this.cirurgiaService.excluirAtividade(event.obj.id!)
          .subscribe({
            error: (e: Error) => this.snack.open(e.message, "Erro"),
            next: () => {
              this.alterarLista(event.lista)
              this.snack.open('Cirurgia excluída com sucesso.', 'Sucesso')
            }
          })
      }
    })
  }

  public buscarPorPeriodo(event: any) {
    this.cirurgiaService.selecionarPorPeriodo(event.dt1, event.dt2)
      .subscribe((x: ListarAtividades[]) => {
        if (x.length == 0)
          this.snack.open("Nenhuma cirurgia no período informado")
        this.cirurgias$ = of(x)
      })
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
