import './extensions/http-error-response.extension';

import { registerLocaleData } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { APP_INITIALIZER, LOCALE_ID, NgModule } from '@angular/core';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS, MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { TemaService } from './shared/services/tema.service';


const locale = 'pt-BR'
registerLocaleData(localePt, locale);

export function atribuirTemaUsuarioFactory(temaService: TemaService) {
  return () => temaService.obterTemaUsuario()
}

@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    MatSnackBarModule

  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: atribuirTemaUsuarioFactory,
      deps: [TemaService],
      multi: true
    },
    {
      provide: LOCALE_ID, useValue: locale
    },
    {
      provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 4000 }
    },
    provideHttpClient(),
    TemaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
