import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../Models/Category';


@Component({
  selector: 'app-addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.css']
})
export class AddcategoryComponent implements OnInit {

  constructor(public httpc: HttpClient) { }

  ngOnInit(): void {
  }
  cat:Category=new Category();
  cats:Array<Category>=new Array<Category>();

  AddCategory()
  {
    console.log(this.cat)

    var cato={
      id:Number(this.cat.id),
      catName:this.cat.catName,
    }
    this.httpc.post("https://localhost:44398/api/Product",cato).subscribe(res=>this.PostSuccess(res),res=>this.PostError(res));
    this.cat=new Category();
  }
  PostSuccess(res:any){
    console.log(res);
  }
  PostError(res:any){
    console.log(res);
  }

  Show(){
    console.log("hi");
    this.httpc.get("https://localhost:44398/api/Product").subscribe(res=>this.GetSuccess(res),res=>this.GetError(res));
  }
  GetSuccess(input:any){
    this.cats=input;
  }
  GetError(input:any){
    console.log(input);
  }
}
