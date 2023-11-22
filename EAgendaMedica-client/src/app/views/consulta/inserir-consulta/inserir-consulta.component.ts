import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Observable, map } from "rxjs";
import { FormConsulta } from "src/app/models/Atividades";
import { ListarMedicos } from "src/app/models/Medicos";
import { ConsultaService } from "../services/consulta.service";

@Component({
  selector: 'app-inserir-consulta',
  templateUrl: './inserir-consulta.component.html',
  styleUrls: ['./inserir-consulta.component.scss']
})
export class InserirConsultaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  constructor(private serviceConsulta: ConsultaService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
  }

  public cadastrar(consulta: FormConsulta) {

    this.serviceConsulta.inserirAtividade(consulta)
      .subscribe({
        error: (e:Error) => console.log(e.message),
        next: () => {
          this.router.navigate(["/consultas/listar"])
        }
      })
  }
}
