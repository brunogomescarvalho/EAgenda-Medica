import { Component } from '@angular/core';
import { MedicoService } from '../services/medico.service';
import { FormMedico } from 'src/app/models/Medicos';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inserir-medico',
  templateUrl: './inserir-medico.component.html',
  styleUrls: ['./inserir-medico.component.scss']
})
export class InserirMedicoComponent {

  constructor(private service: MedicoService, private router: Router) { }

  inserir(medico: FormMedico) {
    this.service.inserir(medico)
      .subscribe({
        error: (e) => console.log(e),
        next: () => {
          this.router.navigate(["/medicos/listar"])
        }
      })
  }
}
