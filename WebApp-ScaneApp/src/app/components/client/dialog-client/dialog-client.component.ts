import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
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

  public name: string = "";
  public phone: string | undefined = "";

  constructor(
    public dialogRef: MatDialogRef<DialogClientComponent>,
    public apiClient: ApiclientService,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public client: Client
  ) {
    if (this.client) this.name = client.name;
    if (this.client.phone) this.phone = client.phone;
  }

  CloseDialog() {
    this.dialogRef.close();
  }

  AddClient() {
    const newClient: Client = {name: this.name, phone: this.phone};
    this.apiClient.AddClient(newClient).subscribe((response:ProjectResponse) => {
      if (response.success === 1) {
        this.CloseDialog();
        this.snackBar.open("Client created successfully", "", {duration: 2000});
      }
      console.log(response);
    });
  }

  EditClient() {
    let client: Client = {
      id: this.client.id,
      name: this.name,
      phone: this.phone
    };
    this.apiClient.EditClient(client).subscribe((response:ProjectResponse) => {
      if (response.success === 1) {
        this.CloseDialog();
        this.snackBar.open("Client edited successfully", "", {duration: 2000});
      }
      console.log(response);
    });
  }

  DeleteClient(clientId: number) {
    this.apiClient.DeleteClient(clientId).subscribe((response:ProjectResponse) => {
      if (response.success === 1) {
        this.CloseDialog();
        this.snackBar.open("Client deleted successfully", "", {duration: 2000});
      }
      console.log(response);
    });
  }
}
