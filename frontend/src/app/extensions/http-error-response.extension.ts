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

  let erroOcorrido = this.error.erros as string;

  switch (this.status) {
    case 500:
      {
        if (erroOcorrido.includes('Result is in status failed'))
          messagemErro = erroOcorrido.split("'")[1]
        else
          messagemErro = erroOcorrido
      }
      break;

      default:
        messagemErro = erroOcorrido
        break
  }

  return throwError(() => new Error(messagemErro));
}
