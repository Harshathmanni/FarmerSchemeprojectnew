import { Injectable } from "@angular/core";
import{ HttpClient } from "@angular/common/http";
import { Bidmodel } from "src/app/model/bidding.model";

@Injectable()
export class BiddingService
{
    constructor(private http:HttpClient)
    {

    }
    //.net core prjwebapi1 url
    readonly uri="http://localhost:39890/api/bidding"

    getBidding()
    {
        return this.http.get(this.uri);
    }
    //Post
    
    insertCategory(cat:Bidmodel)
    {
    
       return this.http.post(this.uri,cat,{responseType: 'text'})
    }
  
}


