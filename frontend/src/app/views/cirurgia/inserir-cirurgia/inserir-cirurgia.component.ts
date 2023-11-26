import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { FormCirurgia } from 'src/app/models/Atividades';
import { ListarMedicos } from 'src/app/models/Medicos';

import { CirurgiaService } from '../services/cirurgia.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-inserir-cirurgia',
  templateUrl: './inserir-cirurgia.component.html',
  styleUrls: ['./inserir-cirurgia.component.scss']
})
export class InserirCirurgiaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  constructor(
    private serviceCirurgia: CirurgiaService,
    private router: Router,
    private route: ActivatedRoute,
    private snack: MatSnackBar) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
  }

  public cadastrar(cirurgia: FormCirurgia) {

    this.serviceCirurgia.inserirAtividade(cirurgia)
      .subscribe({
        error: (e: Error) => this.snack.open(e.message, 'Erro'),
        next: () => {
          this.router.navigate(["/cirurgias/listar"])
          this.snack.open(`Cirurgia cadastrada  com sucesso.`, 'Sucesso')
        }
      })
  }
}
