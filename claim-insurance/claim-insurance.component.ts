import { Component, OnInit } from '@angular/core';
import { Claimmodel } from "src/app/model/ClaimInsurance.model";
import { ClaimInsuranceService} from 'src/Service/ClaimInsurance.Service';



@Component({
  selector: 'app-claim-insurance',
  templateUrl: './claim-insurance.component.html',
  styleUrls: ['./claim-insurance.component.css']
})
export class ClaimInsuranceComponent implements OnInit {
 
  

 

  constructor(private claimservice:ClaimInsuranceService) { }

  ngOnInit(): void{
     
    this.fetchClaimInsurance();
  }

  claiminsuranceinfo?:any;
  fetchClaimInsurance()
  {
    

    this.claimservice.getClaimInsurance().subscribe((data:any)=>{this.claiminsuranceinfo=data;console.table(this.claiminsuranceinfo)});
  }
   //Post
  //object
  Claimmodels:Claimmodel={}; 
  result:any;
  addCategory()
  {
    
   
     this.claimservice.insertCategory(this.Claimmodels).subscribe((data)=>{console.log(data)
         if(data=="Success")
      {
        window.alert("Data Added!!!");
        debugger;
        this.fetchClaimInsurance();
      }
      else{
        window.alert("Data Not Added!!!");
      }
    }
       
     );
     
  }
  //Delete
msg:any;
removeCategory(cid:number)
{
  this.claimservice.deleteCategory(cid).subscribe((data)=>{this.msg=data,console.log(this.msg)
 });
  
}
//get particular category details
editCategory(id:number)
{
   this.claimservice.getcatbyid(id).subscribe((data:any)=>{this.Claimmodels=data,console.log(this.Claimmodels)});
}

//update
updateCategory()
{
  
   this.claimservice.editcategoryservice(this.Claimmodels).subscribe((data:any)=>{this.msg,console.log(this.msg)});
}
}
  

   

