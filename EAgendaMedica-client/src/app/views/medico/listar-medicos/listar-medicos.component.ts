import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, Observable } from 'rxjs';
import { ListarMedicos } from 'src/app/models/Medicos';

import { MedicoService } from '../medico.service';

@Component({
  selector: 'app-listar-medicos',
  templateUrl: './listar-medicos.component.html',
  styleUrls: ['./listar-medicos.component.scss']
})
export class ListarMedicosComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  links = ['Todos', 'Ativos', 'Inativos'];
  activeLink = this.links[0];

  constructor(private route: ActivatedRoute, private service: MedicoService) {}


  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']))
  }

  alterarLista() {
    switch (this.activeLink) {
      case "Todos": this.medicos$ = this.service.listarTodos(); break;
      case "Ativos": this.medicos$ = this.service.listarTodosPorStatus(true); break;
      case "Inativos": this.medicos$ = this.service.listarTodosPorStatus(false); break;
    }
  }

}
