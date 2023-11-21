import { Observable, map } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormCirurgia, ListarMedicos } from 'src/app/models/ListarAtividades';
import { Router, ActivatedRoute } from '@angular/router';
import { CirurgiaService } from '../cirurgia.service';

@Component({
  selector: 'app-editar-cirurgia',
  templateUrl: './editar-cirurgia.component.html',
  styleUrls: ['./editar-cirurgia.component.scss']
})
export class EditarCirurgiaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  cirurgia$: Observable<FormCirurgia> | null = null

  constructor(private serviceCirurgia: CirurgiaService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
    this.cirurgia$ = this.route.data.pipe(map(x => x['cirurgia']));
  }

  public editar(cirurgia: FormCirurgia) {

    let idselecionado = this.route.snapshot.params['id'];

    this.serviceCirurgia.editarAtividade(cirurgia, idselecionado)
      .subscribe({
        error: (e) => console.log(e),
        next: () => {
          this.router.navigate(["/cirurgia/listar"])
        }
      })
  }
}
