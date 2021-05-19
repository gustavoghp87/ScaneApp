import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './components/home/home.component';
import { ClientComponent } from './components/client/client.component';
import { HttpClientModule } from "@angular/common/http";

import { MatSidenavModule } from "@angular/material/sidenav";
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { DialogClientComponent } from './components/client/dialog-client/dialog-client.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientComponent,
    DialogClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSidenavModule,
    MatTableModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
