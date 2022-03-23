import { Injectable } from "@angular/core";
import{ HttpClient } from "@angular/common/http";
import { Insurancemodel } from "src/app/model/Insurance.model";

@Injectable()
export class InsuranceService
{
    constructor(private http:HttpClient)
    {

    }
    //.net core prjwebapi1 url
    readonly uri="http://localhost:39890/api/insurance"

    getInsurance()
    {
        return this.http.get(this.uri);
    }
    //Post
    
    insertCategory(cat:Insurancemodel)
    {
    
       return this.http.post(this.uri,cat,{responseType: 'text'})
    }
  
  //Delete

  deleteCategory(cid:number)
  {
    return this.http.delete(this.uri+'/'+cid);
    debugger;
  }
  getcatbyid(id:number)
  {
    return this.http.get(this.uri+'/'+id);
  }
  //Put

  editcategoryservice(cat:any)
  {
    
    return this.http.put(this.uri+'/'+cat.categoryId,cat);
  }

}
