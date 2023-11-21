import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { ListarAtividades } from 'src/app/models/ListarAtividades';
import { CirurgiaService } from '../cirurgia.service';

@Component({
  selector: 'app-listar-cirurgias',
  templateUrl: './listar-cirurgias.component.html',
  styleUrls: ['./listar-cirurgias.component.scss']
})
export class ListarCirurgiasComponent implements OnInit {

  cirurgias$!: Observable<ListarAtividades[]>

  constructor(private cirurgiaService: CirurgiaService, private route: ActivatedRoute, private router: Router) {

  }
  ngOnInit(): void {
    this.cirurgias$ = this.route.data.pipe(map(x => x["cirurgias"]))
  }

  editar(cirurgia: ListarAtividades) {
    this.router.navigate(["/cirurgias/editar", cirurgia.id])
  }

  public alterarLista(event: string) {

    switch (event) {
      case "Todas": this.cirurgias$ = this.cirurgiaService.listarTodas(); break;
      case "Próximas": this.cirurgias$ = this.cirurgiaService.listarFuturas(); break;
      case "Passadas": this.cirurgias$ = this.cirurgiaService.listarPassadas(); break;
      case "Hoje": this.cirurgias$ = this.cirurgiaService.listarParaHoje(); break;

    }
  }
}
