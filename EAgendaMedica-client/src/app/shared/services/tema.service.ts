import { Injectable, Renderer2, RendererFactory2 } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()

export class TemaService {

  private renderer!: Renderer2

  private alterarCorImagens!: BehaviorSubject<string | null>

  private darkTheme: string = 'dark-theme'

  private localStorageName = 'temaEAgenda'

  constructor(private rf: RendererFactory2) {
    this.alterarCorImagens = new BehaviorSubject<string | null>(null)

    this.renderer = this.rf.createRenderer(null, null)
  }

  alterarTema() {
    if (document.documentElement.className == this.darkTheme) {

      this.renderer.removeClass(document.documentElement, this.darkTheme)
      this.alterarCorImagens.next(null)
    }
    else {
      this.renderer.addClass(document.documentElement, this.darkTheme)
      this.alterarCorImagens.next(this.darkTheme)
    }

    this.salvarTemaUsuario()
  }

  temaAlteradoObservable() {
    return this.alterarCorImagens.asObservable()
  }

  carregarTemaPadrao() {
    if (document.documentElement.className == this.darkTheme) {

      this.renderer.removeClass(document.documentElement, this.darkTheme)
      this.alterarCorImagens.next(null)
    }
    localStorage.removeItem(this.localStorageName)

  }


  salvarTemaUsuario() {
    let tema = localStorage.getItem(this.localStorageName)

    if (tema)
      localStorage.removeItem(this.localStorageName)
    else
      localStorage.setItem(this.localStorageName, JSON.stringify({ tema: 'dark-theme' }))
  }

  obterTemaUsuario() {
    let tema = localStorage.getItem(this.localStorageName)

    if (tema) {
      this.renderer.addClass(document.documentElement, this.darkTheme)
      this.alterarCorImagens.next(this.darkTheme)
    }
  }
}
