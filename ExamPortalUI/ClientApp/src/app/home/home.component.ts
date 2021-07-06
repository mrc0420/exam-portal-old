import { Component, OnInit} from '@angular/core';
import { QuestionTransferService } from '../exam/service/question-transfer.service';
import {HttpClient} from '@angular/common/http';
import { Question } from '../nav-menu/models/question';
import { Courselist } from '../nav-menu/models/courselist';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Alert } from 'selenium-webdriver';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  courses : Courselist[];
  searchedCourse =new Courselist();
  flag:number=0;
  message:string='';
  courseLength:number=0;
  searchValue : Courselist = new Courselist();
  test: string;
  private baseUrl: string = 'https://localhost:5001';
  
  constructor(private http:HttpClient, private courseSearch:FormBuilder) { 
    this.formdata = courseSearch.group({
      courseName: new FormControl('')
    });
  }
  formdata:FormGroup;

ngOnInit()
{
  this.http.get<Courselist[]>(`${this.baseUrl}/api/Course`).subscribe(result=>this.courses=result);//this.courses.passPercentage
  //this.http.post<Courselist[]>()
  
 

  
}
  
Search()
{
  // alert(this.formdata.value.getall);
  this.courseLength=this.courses.length;
 // alert( this.searchValue.search);
  
  var b =  this.searchValue.search.toString();
  for(let i = 0; i<this.courseLength;i++)
  { 
    var a =this.courses[i].courseName.toString();
   // alert(a);
   // alert(b);
    if( a==b )
    {
      alert();
      this.searchedCourse=this.courses[i];
      this.flag=1;
    }
    
  }
  if(this.flag==0)
  {this.message='Not Found';}
}



}
