import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Client } from 'src/app/models/client';
import { ApiclientService } from 'src/app/services/apiclient.service';
import { Response as ProjectResponse } from '../../../models/response';

@Component({
  selector: 'app-dialog-client',
  templateUrl: './dialog-client.component.html',
  styleUrls: ['./dialog-client.component.sass']
})
export class DialogClientComponent {

  constructor(
    public dialogRef: MatDialogRef<DialogClientComponent>,
    public apiClient: ApiclientService,
    public snackBar: MatSnackBar
  ) { }

  CloseDialog() {
    this.dialogRef.close();
  }

  AddClient() {
    const newClient: Client = {name: "John9"};
    this.apiClient.AddClient(newClient).subscribe((response:ProjectResponse) => {
      if (response.success === 1) {
        this.CloseDialog();
        this.snackBar.open("Client created successfully", "", {duration: 2000});
      }
      console.log(response);
    });
  }
}
