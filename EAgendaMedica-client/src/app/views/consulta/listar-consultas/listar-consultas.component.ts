import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable, map } from "rxjs";
import { ListarAtividades } from "src/app/models/Atividades";
import { ConsultaService } from "../services/consulta.service";
import { ConsultaDialogService } from "../services/consulta-dialog.service";


@Component({
  selector: 'app-listar-consultas',
  templateUrl: './listar-consultas.component.html',
  styleUrls: ['./listar-consultas.component.scss']
})
export class ListarConsultasComponent implements OnInit {

  consultas$!: Observable<ListarAtividades[]>

  constructor(
    private consultaService: ConsultaService,
    private route: ActivatedRoute,
    private router: Router,
    private serviceDialog: ConsultaDialogService) {

  }
  ngOnInit(): void {
    this.consultas$ = this.route.data.pipe(map(x => x["consultas"]))
  }

  editar(consulta: ListarAtividades) {
    this.router.navigate(["editar", consulta.id], { relativeTo: this.route.parent })
  }

  detalhes(consulta: ListarAtividades) {
    this.consultaService.obterDetalhes(consulta.id!)
      .subscribe(x => this.serviceDialog.visualizarDetalhesConsulta(x))
  }
  excluir(event:any){
    let result = this.serviceDialog.excluirConsulta(event.obj);

    result.afterClosed().subscribe(x => {
      if (x == true) {
        this.consultaService.excluirAtividade(event.obj.id!)
          .subscribe(() => this.alterarLista(event.lista))
      }
    })
  }

  public alterarLista(event: string) {

    switch (event) {
      case "Todas": this.consultas$ = this.consultaService.listarTodas(); break;
      case "Próximas": this.consultas$ = this.consultaService.listarFuturas(); break;
      case "Passadas": this.consultas$ = this.consultaService.listarPassadas(); break;
      case "Hoje": this.consultas$ = this.consultaService.listarParaHoje(); break;

    }
  }
}
