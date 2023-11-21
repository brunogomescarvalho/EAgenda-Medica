import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable, map } from "rxjs";
import { ListarMedicos } from "src/app/models/Medicos";

@Component({
  selector: 'app-listar-medicos',
  templateUrl: './listar-medicos.component.html',
  styleUrls: ['./listar-medicos.component.scss']
})
export class ListarMedicosComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  links = ['Todos', 'Ativos', 'Inativos'];
  activeLink = this.links[0];

  constructor(private route: ActivatedRoute) {

  }


  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']))
  }

  alterarLista() {

  }

}
