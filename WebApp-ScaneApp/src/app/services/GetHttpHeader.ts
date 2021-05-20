import { HttpHeaders } from "@angular/common/http";

export class GetHttpHeader {
    static GetHttpHeader() {
        return { headers: new HttpHeaders({'Content-Type': 'application/json'}) };
    }
}