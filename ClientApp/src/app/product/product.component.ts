import { Component, OnInit } from "@angular/core";
import { ApiServiceService } from "../api-service.service";

@Component({
  selector: "app-product",
  templateUrl: "./product.component.html",
  styleUrls: ["./product.component.css"],
})
export class ProductComponent implements OnInit {
  productList: any;
  productId: number;
  productName = "";
  productDesc = "";
  productPrice = 0;
  productQRStr = "";

  constructor(private apiservice: ApiServiceService) {}

  ngOnInit() {
    this.apiservice.getAllProducts().subscribe((res) => {
      this.productList = res;
      this.productList = this.productList.data;
    });
  }
  displayStyle = "none";

  openPopup(id) {
    this.apiservice.getProductById(id).subscribe((res) => {
      var resp: any = res;
      this.productName = resp.name;
      this.productDesc = resp.details;
      this.productPrice = resp.price;
      this.productQRStr = resp.qrCode;
    });
    this.displayStyle = "block";
  }
  closePopup() {
    this.productName = "";
    this.displayStyle = "none";
  }
}
