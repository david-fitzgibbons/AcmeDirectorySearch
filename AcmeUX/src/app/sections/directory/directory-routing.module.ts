import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DirectoryComponent } from './directory.component';

const directoryRoutes: Routes = [
  { path: 'directory', component: DirectoryComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(directoryRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class DirectoryRoutingModule { }
