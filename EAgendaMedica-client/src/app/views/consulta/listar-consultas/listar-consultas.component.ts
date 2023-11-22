import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable, map } from "rxjs";
import { ListarAtividades } from "src/app/models/Atividades";
import { ConsultaService } from "../consulta.service";


@Component({
  selector: 'app-listar-consultas',
  templateUrl: './listar-consultas.component.html',
  styleUrls: ['./listar-consultas.component.scss']
})
export class ListarConsultasComponent implements OnInit {

  consultas$!: Observable<ListarAtividades[]>

  constructor(private consultaService: ConsultaService, private route: ActivatedRoute, private router:Router) {

  }
  ngOnInit(): void {
    this.consultas$ = this.route.data.pipe(map(x => x["consultas"]))
  }

  editar(consulta: ListarAtividades) {
    this.router.navigate(["/consultas/editar", consulta.id])
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
