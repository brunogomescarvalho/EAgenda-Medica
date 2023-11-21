import { Component, OnInit } from '@angular/core';
import { FormCirurgia, ListarMedicos } from 'src/app/models/ListarAtividades';
import { CirurgiaService } from '../cirurgia.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-inserir-cirurgia',
  templateUrl: './inserir-cirurgia.component.html',
  styleUrls: ['./inserir-cirurgia.component.scss']
})
export class InserirCirurgiaComponent implements OnInit {

  medicos$!: Observable<ListarMedicos[]>

  constructor(private serviceCirurgia: CirurgiaService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map(x => x['medicos']));
  }

  public cadastrar(cirurgia: FormCirurgia) {

    this.serviceCirurgia.inserirAtividade(cirurgia)
      .subscribe({
        error: (e) => console.log(e),
        next: () => {
          this.router.navigate(["/cirurgia/listar"])
        }
      })
  }
}
