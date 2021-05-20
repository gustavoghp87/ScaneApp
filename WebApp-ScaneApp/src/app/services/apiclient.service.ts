import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { backendUrl } from 'src/environments/environment';
import { Client } from '../models/client';
import { Response as ProjectResponse } from '../models/response'
import { GetHttpHeader } from './GetHttpHeader';

@Injectable({
    providedIn: 'root'
})
export class ApiclientService {

    private url: string = backendUrl + "/client";

    constructor(private http: HttpClient) { }

    GetClients(): Observable<ProjectResponse> {
        return this.http.get<ProjectResponse>(`${this.url}`);
    }

    GetClient(id: number): Observable<ProjectResponse> {
        return this.http.get<ProjectResponse>(`${this.url}/${id}`);
    }

    AddClient(client: Client): Observable<ProjectResponse> {
        return this.http.post<ProjectResponse>(`${this.url}`, client, GetHttpHeader.GetHttpHeader());
    }

    EditClient(client: Client): Observable<ProjectResponse> {
        return this.http.put<ProjectResponse>(`${this.url}`, client, GetHttpHeader.GetHttpHeader());
    }

    DeleteClient(id: number): Observable<ProjectResponse> {
        return this.http.delete<ProjectResponse>(`${this.url}/${id}`);
    }
}
