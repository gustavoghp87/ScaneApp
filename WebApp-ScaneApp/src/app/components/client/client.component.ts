import { Component, OnInit } from '@angular/core';
import { ApiclientService } from 'src/app/services/apiclient.service';
import { Response as ProjectResponse } from '../../models/response';
import { DialogClientComponent } from './dialog-client/dialog-client.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
    selector: 'app-client',
    templateUrl: './client.component.html',
    styleUrls: ['./client.component.sass']
})
export class ClientComponent implements OnInit {

    public lstClients: any[] = [];
    public clientColumns: string[] = ['id', 'name', 'phone'];

    constructor(
        private apiClient: ApiclientService,
        public matDialog: MatDialog
    ) { }
    
    ngOnInit(): void {
        this.GetClients();
    }

    GetClients(): void {
        this.apiClient.GetClients().subscribe((response:ProjectResponse) => {
            console.log(response);
            this.lstClients = response['data']
        });
    }

    OpenDialog(): void {
        const dialogRef = this.matDialog.open(DialogClientComponent, {
            width: '300'
        });
        dialogRef.afterClosed().subscribe(result => {
            this.GetClients();
        });
    }

}
