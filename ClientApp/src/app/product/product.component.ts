import { Component, OnInit } from "@angular/core";
import { ApiServiceService } from "../api-service.service";

@Component({
  selector: "app-product",
  templateUrl: "./product.component.html",
  styleUrls: ["./product.component.css"],
})
export class ProductComponent implements OnInit {
  productList: any;
  constructor(private apiservice: ApiServiceService) {}

  ngOnInit() {
    this.apiservice.getAllProducts().subscribe((res) => {
      this.productList = res;
      this.productList = this.productList.data;
    });
  }
}
