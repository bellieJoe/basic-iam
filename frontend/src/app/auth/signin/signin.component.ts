import { Component } from '@angular/core';
import { CardModule, Card } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [
    CardModule,
    ButtonModule,
    InputTextModule,
    FloatLabelModule
  ],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss'
})
export class SigninComponent {

}
