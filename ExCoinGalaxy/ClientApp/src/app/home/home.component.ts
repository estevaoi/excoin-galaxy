import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  title = 'Unit converter';
  statusSaida = 'alert-default';
  valorRomano: string = '';
  valorBinario: string = '';

  rForm: FormGroup;
  post: any;
  entrada: string = '';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
  ) {
    this.rForm = fb.group({
      'entrada': [null, Validators.required]
    });
  }

  addPost(post) {

    const url = `api/Conversor/Post`;

    if (post.entrada) {
      this.http.post(url, {
        "atributo": post.entrada
      }).subscribe(
        response => {
          this.statusSaida = response['statusSaida'];
          this.valorRomano = response['valorRomano'];
          this.valorBinario = response['valorBinario'];
        }
      )
    }

  }

}
