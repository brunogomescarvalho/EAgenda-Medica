import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { FormCirurgia } from 'src/app/models/Atividades';
import { ListarMedicos } from 'src/app/models/Medicos';

import { CirurgiaService } from '../services/cirurgia.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar-cirurgia',
  templateUrl: './editar-cirurgia.component.html',
  styleUrls: ['./editar-cirurgia.component.scss']
})
export class EditarCirurgiaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  cirurgia$: Observable<FormCirurgia> | null = null

  constructor(
    private serviceCirurgia: CirurgiaService,
    private router: Router,
    private route: ActivatedRoute,
    private snack: MatSnackBar) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
    this.cirurgia$ = this.route.data.pipe(map(x => x['cirurgia']));
  }

  public editar(cirurgia: FormCirurgia) {
    let idselecionado = this.route.snapshot.params['id'];

    this.serviceCirurgia.editarAtividade(cirurgia, idselecionado)
      .subscribe({
        error: (e: Error) => this.snack.open(e.message, 'Erro'),
        next: () => {
          this.router.navigate(["/cirurgias/listar"])
          this.snack.open(`Cirurgia editada com sucesso.`, 'Sucesso')
        }
      })
  }
}
