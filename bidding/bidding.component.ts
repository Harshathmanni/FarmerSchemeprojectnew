import { Component, OnInit } from '@angular/core';
import { BiddingService} from 'src/Service/Bidding.Service';
import { Bidmodel } from '../model/bidding.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-bidding',
  templateUrl: './bidding.component.html',
  styleUrls: ['./bidding.component.css']
})
export class BiddingComponent implements OnInit {

  constructor(private  bidservice:BiddingService) { }
  bidinfo: any;

  ngOnInit(): void
   {
     
    this.fetchBidding();
  }

biddinginfo?:any;
  fetchBidding()
  {
    this.bidservice.getBidding().subscribe((data:any)=>{this.bidinfo=data;console.table(this.bidinfo)});
  }
    //Post
  //object
  bidding:Bidmodel={}; 
  result:any;
  addCategory()
  {
   
     this.bidservice.insertCategory(this.bidding).subscribe((data:any)=>{console.log(data)
         if(data=="Success")
      {
        window.alert("Data Added!!!");
        this.fetchBidding();
      }
      else{
        window.alert("Data  Not Added!!!");
      }
    }
       
       );
     
  }

}
   




