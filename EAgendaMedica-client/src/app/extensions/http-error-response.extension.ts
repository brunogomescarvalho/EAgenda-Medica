import { HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";

declare module '@angular/common/http' {
  interface HttpErrorResponse {
    processarErro(): Observable<any>
  }
}

HttpErrorResponse.prototype.processarErro = function () {
  let messagemErro!: string;

  if (!this) {
    return throwError(() => new Error('Erro inesperado.'));
  }

  switch (this.status) {
    case 500:
      {
          messagemErro = this.error.erros.split("'")[1]
      }
      break;

    default:
      messagemErro = 'Ocorreu um erro ao efetuar a requisição.';
  }

  return throwError(() => new Error(messagemErro));
}
