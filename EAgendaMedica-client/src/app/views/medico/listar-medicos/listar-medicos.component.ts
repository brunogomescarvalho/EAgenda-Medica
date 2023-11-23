import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { ListarMedicos, Top10Medicos } from 'src/app/models/Medicos';

import { MedicoService } from '../services/medico.service';
import { MedicoDialogService } from '../services/medico-dialog.service';
import { DateTimePipe } from 'src/app/shared/pipes/date-time.pipe';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-listar-medicos',
  templateUrl: './listar-medicos.component.html',
  styleUrls: ['./listar-medicos.component.scss']
})
export class ListarMedicosComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>
  links = ['Todos', 'Ativos', 'Inativos'];
  activeLink = this.links[0];

  constructor(
    private route: ActivatedRoute,
    private service: MedicoService,
    private modalService: MedicoDialogService,
    private router: Router,
    private datePipe: DateTimePipe) { }


  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']))
  }

  detalhes(medico: ListarMedicos) {
    this.service.obterDetalhes(medico.id!).subscribe(x => {
      this.modalService.detalharMedicoDialog(x)
    })
  }

  editar(medico: ListarMedicos) {
    this.router.navigate(["editar", medico.id], { relativeTo: this.route.parent })
  }

  excluir(event: ListarMedicos) {

    let result = this.modalService.excluirMedicoDialog(event)

    result.afterClosed().subscribe((x) => {
      if (x == true)
        this.service.excluir(event.id!).subscribe(() => this.alterarLista())
    })
  }

  alterarLista() {
    switch (this.activeLink) {
      case "Todos": this.medicos$ = this.service.listarTodos(); break;
      case "Ativos": this.medicos$ = this.service.listarTodosPorStatus(true); break;
      case "Inativos": this.medicos$ = this.service.listarTodosPorStatus(false); break;
    }
  }

  mostrarTop10() {

    var result = this.modalService.mostrarTop10Dialog()
    this.modalService.datasTop10?.asObservable().subscribe(x => {

      this.service.buscarTop10(x?.dt1, x?.dt2)
        .subscribe(x => {
          this.modalService.top10MedicosEvent.next(x)
        })
    })

  }

}
