import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <div><h1>{{pageTitle}}</h1>
      <app-products></app-products>
    </div>
    `
})

export class AppComponent {
  pageTitle: string = 'webshop';
}
