import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ShapeGeneratorComponent } from './shape-generator/shape-generator.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { ShapeGeneratorService } from '../app/shape-generator/shape-generator.service';

@NgModule({
  declarations: [
    AppComponent,
    ShapeGeneratorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  exports: [
    MatInputModule,
    MatButtonModule
  ],
  providers: [ShapeGeneratorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
