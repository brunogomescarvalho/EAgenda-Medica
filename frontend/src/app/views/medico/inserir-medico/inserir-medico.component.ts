import { Component } from '@angular/core';
import { MedicoService } from '../services/medico.service';
import { FormMedico } from 'src/app/models/Medicos';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-inserir-medico',
  templateUrl: './inserir-medico.component.html',
  styleUrls: ['./inserir-medico.component.scss']
})
export class InserirMedicoComponent {

  constructor(private service: MedicoService, private router: Router, private snack: MatSnackBar) { }

  inserir(medico: FormMedico) {
    this.service.inserir(medico)
      .subscribe({
        error: (e: Error) => this.snack.open(e.message, 'Erro'),
        next: () => {
          this.router.navigate(["/medicos/listar"])
          this.snack.open('Médico cadastrado com sucesso.', 'Sucesso')
        }
      })
  }
}
