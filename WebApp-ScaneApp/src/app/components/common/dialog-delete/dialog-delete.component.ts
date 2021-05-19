import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Client } from 'src/app/models/client';

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html',
  styleUrls: ['./dialog-delete.component.sass']
})
export class DialogDeleteComponent implements OnInit {

  public clientToDelete: Client;

  constructor(
    public dialogRef: MatDialogRef<DialogDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public client: Client
  ) {
    this.clientToDelete = client;
  }

  ngOnInit(): void {
  }

}
