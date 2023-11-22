import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, map } from 'rxjs';
import { FormConsulta } from 'src/app/models/Atividades';
import { ListarMedicos } from 'src/app/models/Medicos';
import { ConsultaService } from '../consulta.service';

@Component({
  selector: 'app-editar-consulta',
  templateUrl: './editar-consulta.component.html',
  styleUrls: ['./editar-consulta.component.scss']
})
export class EditarConsultaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  consulta$: Observable<FormConsulta> | null = null

  constructor(private serviceConsulta: ConsultaService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
    this.consulta$ = this.route.data.pipe(map(x => x['consulta']));
  }

  public editar(consulta: FormConsulta) {
    let idselecionado = this.route.snapshot.params['id'];

    this.serviceConsulta.editarAtividade(consulta, idselecionado)
      .subscribe({
        error: ((e:Error) => console.log(e.message)),
        next: () => {
          this.router.navigate(["/consultas/listar"])
        }
      })
  }
}


