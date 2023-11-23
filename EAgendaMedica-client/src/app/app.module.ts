import './extensions/http-error-response.extension';

import { registerLocaleData } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { LOCALE_ID, NgModule } from '@angular/core';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS, MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';


const locale = 'pt-BR'
registerLocaleData(localePt, locale);

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
      provide: LOCALE_ID, useValue: locale
    },
    {
      provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 }
    },
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
