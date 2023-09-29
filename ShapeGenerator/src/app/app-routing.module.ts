import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShapeGeneratorComponent } from './shape-generator/shape-generator.component';

const routes: Routes = [
  { path: '', component: ShapeGeneratorComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
