import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DirectoryComponent } from './directory.component';
import { DirectoryRoutingModule } from './directory-routing.module';
import { HowtoComponent } from './howto/howto.component';
import { SearchComponent } from './search/search.component';
import { CreateComponent } from './create/create.component';

@NgModule({
  declarations: [DirectoryComponent, HowtoComponent, SearchComponent, CreateComponent],
  imports: [
    CommonModule,
    DirectoryRoutingModule
  ]
})
export class DirectoryModule { }
