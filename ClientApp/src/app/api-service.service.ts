import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class ApiServiceService {
  private headers: HttpHeaders;
  Api_URL = "https://localhost:44390/api/product";
  constructor(private httpclient: HttpClient) {
    this.headers = new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8",
    });
  }
  getAllProducts() {
    return this.httpclient.get(this.Api_URL);
  }
  getProductById(id: number) {
    return this.httpclient.get(`${this.Api_URL}/${id}`);
  }
}
