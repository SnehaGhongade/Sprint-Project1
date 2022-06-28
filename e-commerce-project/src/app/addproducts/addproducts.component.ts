import { Component, OnInit } from '@angular/core';
import { Product } from '../Models/ProductData';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-addproducts',
  templateUrl: './addproducts.component.html',
  styleUrls: ['./addproducts.component.css']
})
export class AddproductsComponent implements OnInit {

  constructor(public httpc:HttpClient){}
  ngOnInit(): void {
  }

  adminprod: Product=new Product();
  adminprods:Array<Product>=new Array<Product>();

  AddProduct()
  {
    console.log(this.adminprod)
    var admindto={
      id:Number(this.adminprod.id),
      productName:this.adminprod.productName,
      productDescription:this.adminprod.productDescription,
      CatID:Number(this.adminprod.catID),
      productImage:this.adminprod.productImage,
      productMrp:Number(this.adminprod.productMrp),
      productDiscount:Number(this.adminprod.productDiscount),
      productFinal:Number(this.adminprod.productFinal),
      productQuantity:Number(this.adminprod.productQuantity),

    }
    this.httpc.post("https://localhost:44398/api/Product",admindto).subscribe(res=>this.PostSuccess(res),res=>this.PostError(res));
    this.adminprod=new Product();
  }
  PostSuccess(res:any){
    console.log(res);
    
  }
  PostError(res:any){
    console.log(res);
  }

  Show(){
    console.log("Hi");
    this.httpc.get("https://localhost:44398/api/Product").subscribe(res=>this.GetSuccess(res),res=>this.GetError(res));
  }
  GetSuccess(input:any){
    this.adminprods=input;
  }
  GetError(input:any){
    console.log(input);
  }
}
