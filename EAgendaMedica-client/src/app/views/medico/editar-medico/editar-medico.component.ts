import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormMedico } from 'src/app/models/Medicos';
import { MedicoService } from '../services/medico.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar-medico',
  templateUrl: './editar-medico.component.html',
  styleUrls: ['./editar-medico.component.scss']
})
export class EditarMedicoComponent implements OnInit {

  medico$: Observable<FormMedico> | null = null

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: MedicoService,
    private snack: MatSnackBar) { }


  ngOnInit(): void {
    this.medico$ = this.route.data.pipe(map(x => x["medico"]))
  }

  editar(medico: FormMedico) {
    let id = this.route.snapshot.params["id"];

    this.service.editar(id, medico)
      .subscribe({
        error: (e: Error) => this.snack.open(e.message, "Erro"),
        next: () => {
          this.snack.open(`Médico editado com sucesso`, 'Sucesso')
          this.router.navigate(["/medicos/listar"])
        }
      })
  }

}
