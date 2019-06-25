import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DirectoryComponent } from './directory.component';
import { DirectoryRoutingModule } from './directory-routing.module';
import { HowtoComponent } from './howto/howto.component';
import { SearchComponent } from './search/search.component';
import { CreateComponent } from './create/create.component';
import { FormsModule } from '@angular/forms';
import { DatagridComponent } from './datagrid/datagrid.component';
import { DatacardComponent } from './datacard/datacard.component';

@NgModule({
  declarations: [DirectoryComponent, HowtoComponent, SearchComponent, CreateComponent, DatagridComponent, DatacardComponent],
  imports: [
    CommonModule,
    DirectoryRoutingModule,
    FormsModule
  ]
})
export class DirectoryModule { }
