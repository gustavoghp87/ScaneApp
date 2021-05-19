import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../models/client';
import { Response as ProjectResponse } from '../models/response'

@Injectable({
    providedIn: 'root'
})
export class ApiclientService {

    private url: string = "https://localhost:44381/api/client";

    constructor(private http: HttpClient) { }

    GetHttpHeader() {
        return { headers: new HttpHeaders({'Content-Type': 'application/json'}) };
    }

    GetClients(): Observable<ProjectResponse> {
        return this.http.get<ProjectResponse>(`${this.url}`);
    }

    GetClient(id: number): Observable<ProjectResponse> {
        return this.http.get<ProjectResponse>(`${this.url}/${id}`);
    }

    AddClient(client: Client): Observable<ProjectResponse> {
        return this.http.post<ProjectResponse>(`${this.url}`, client, this.GetHttpHeader());
    }

    EditClient(client: Client): Observable<ProjectResponse> {
        return this.http.put<ProjectResponse>(`${this.url}`, client, this.GetHttpHeader());
    }

    DeleteClient(id: number): Observable<ProjectResponse> {
        return this.http.delete<ProjectResponse>(`${this.url}/${id}`);
    }
}
