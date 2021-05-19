import { Component, OnInit } from '@angular/core';
import { ApiclientService } from 'src/app/services/apiclient.service';
import { Response as ProjectResponse } from '../../models/response';
import { DialogClientComponent } from './dialog-client/dialog-client.component';
import { MatDialog } from '@angular/material/dialog';
import { Client } from 'src/app/models/client';
import { DialogDeleteComponent } from '../common/dialog-delete/dialog-delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-client',
    templateUrl: './client.component.html',
    styleUrls: ['./client.component.sass']
})
export class ClientComponent implements OnInit {

    public lstClients: any[] = [];
    public clientColumns: string[] = ['id', 'name', 'phone', 'actions'];
    readonly dialogWidth: string = '300';

    constructor(
        private apiClient: ApiclientService,
        public matDialog: MatDialog,
        public snackBar: MatSnackBar
    ) { }
    
    ngOnInit(): void {
        this.GetClients();
        this.GetClient();
    }

    GetClient() {
        this.apiClient.GetClient(5).subscribe(response => {console.log(response);});
    }

    GetClients(): void {
        this.apiClient.GetClients().subscribe((response:ProjectResponse) => {
            console.log(response);
            this.lstClients = response['data']
        });
    }

    OpenDialog(): void {
        const dialogRef = this.matDialog.open(DialogClientComponent, {
            width: this.dialogWidth
        });
        dialogRef.afterClosed().subscribe(result => {
            this.GetClients();
        });
    }

    OpenEdit(client: Client) {
        const dialogRef = this.matDialog.open(DialogClientComponent, {
            width: this.dialogWidth,
            data: client
        });
        dialogRef.afterClosed().subscribe(result => {
            console.log(result);
            this.GetClients();
        });
    }

    Delete(client: Client) {
        const dialogRef = this.matDialog.open(DialogDeleteComponent, {
            width: this.dialogWidth,
            data: client
        });
        dialogRef.afterClosed().subscribe(result => {
            if (result && client.id)
                this.apiClient.DeleteClient(client.id).subscribe(response => {
                    console.log(response);
                    this.GetClients();
                    this.snackBar.open("Client deleted successfully", "", {duration:2000});
                });
        });
    }
}
