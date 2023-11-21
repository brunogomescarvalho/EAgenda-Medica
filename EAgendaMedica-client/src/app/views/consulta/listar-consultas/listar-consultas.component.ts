import { Component, OnInit, Output } from "@angular/core"
import { ActivatedRoute } from "@angular/router"
import { ConsultaService } from "../consulta.service"

import { Observable, map } from "rxjs"
import { ListarAtividades } from "src/app/models/Atividades"


@Component({
  selector: 'app-listar-consultas',
  templateUrl: './listar-consultas.component.html',
  styleUrls: ['./listar-consultas.component.scss']
})
export class ListarConsultasComponent implements OnInit {

  consultas$!: Observable<ListarAtividades[]>

  constructor(private consultaService: ConsultaService, private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.consultas$ = this.route.data.pipe(map(x => x["consultas"]))
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
