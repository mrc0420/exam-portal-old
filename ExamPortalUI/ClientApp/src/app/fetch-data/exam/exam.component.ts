import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Question } from '../nav-menu/models/question';
import { Courselist } from '../nav-menu/models/courselist';
import { QuestionTransferService } from './service/question-transfer.service';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent implements OnInit {

  constructor(private http:HttpClient, private questionService:QuestionTransferService) { }

 questions :Question[];
 // courses:Courselist[];
  courses: Courselist[];
  private baseUrl: string = 'https://localhost:5001';

  ngOnInit() {

    this.http.get<Courselist[]>(`${this.baseUrl}/api/Course`).subscribe(result=>this.courses=result);//this.courses.passPercentage
   //sessionStorage.setItem('passPercentage', this.courses.)
  }
  percentage:Number;
  p:any=0;
  courseSelected:string ='';
  selectedId:number;
  selectedCourse(event:any)
  {
    //debugger

    
    this.selectedId = event.target.value;
    while(this.p<this.courses.length)
      {
          if(this.courses[this.p].courseId == this.selectedId)
          {
            
            this.percentage=this.courses[this.p].passPercentage;
          }
          this.p=this.p+1;
      }
      this.p=0;
    this.courseSelected = event.target.options[event.target.selectedIndex].text; 
   
    
    
    
    
    sessionStorage.setItem('cnkey',this.courseSelected );
    sessionStorage.setItem('percentage', this.percentage.toString());
   
    
    this.http.get<Question[]>("https://localhost:5001/api/Questions/"+this.selectedId).subscribe(result=>{
      this.questionService.iquestion = result});
      //this.questionService.countOfQuestions= this.questionService.iquestion.length;
    
  }
}
