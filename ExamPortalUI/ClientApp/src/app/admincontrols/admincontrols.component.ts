import { Component, OnInit } from '@angular/core';
import { Question} from '../nav-menu/models/question';
import { HttpClient } from '@angular/common/http';
import { CourseListServiceService } from '../exam/service/course-list-service.service';
import { Courselist } from '../nav-menu/models/courselist';
import { QuestionLoaderService } from '../exam/service/question-loader.service';
import { Observable } from 'rxjs';
import { DeleteQuestionService } from '../exam/service/delete-question.service';

@Component({
  selector: 'app-admincontrols',
  templateUrl: './admincontrols.component.html',
  styleUrls: ['./admincontrols.component.css']
})
export class AdmincontrolsComponent implements OnInit {


adminQuestion = new Question;
message:string ='';
courses= new Courselist();

  selectedId: number;
  addattr: Boolean;
  viewattr:boolean;
 
  qstnBtn: string;
  timerattr:boolean;
  timerKey:Number;
  timer:number;
  time:string;

  constructor(private listOfCourses : CourseListServiceService, private http:HttpClient, private GetQuestionService:QuestionLoaderService, private DeleteQuestionService:DeleteQuestionService) { }

  ngOnInit() {
    this.listOfCourses.courseListLoader().subscribe(result=>this.courses=result);
  
    this.addattr = false;
    this.viewattr = false;
    this.timerattr=false;
   
  }



ViewQuestions()
{
  //alert('kk');
  this.viewattr = !this.viewattr;
//   this.selectedId = vevent.target.value;
 


}

GetCourse(getEvent:any)
{
 this.GetQuestionService.QuestionFetch(getEvent.target.value).subscribe(result=>this.adminQuestion=result);
 
}


  response: string;
  
DeleteQuestion(questionId:string)
{

 
  //this.http.delete<string>('https://localhost:5001/api/Questions/Delete/'+ questionId).subscribe(result;
  
  this.DeleteQuestionService.DeleteQuestion(questionId).subscribe(result => this.message = result);
  debugger
  alert(this.message);
  
}

  AddQuestion()
  {
  
    this.addattr = !this.addattr;
    
  }



  selectedCourse(event: any)
  {
    
    this.selectedId = event.target.value;
    alert(this.selectedId);
    
  }


  submitQuestions()
  {
    this.adminQuestion.courseId=this.selectedId;
    alert(this.adminQuestion.courseId)
    
    
    this.http.post<string >('https://localhost:44303/api/values/addQuestion', this.adminQuestion).subscribe(result => {this.message=result;
    alert(result);
  });

  }

  ExamTimerView()
  {
    this.timerattr = !this.timerattr;
  }

  SetTime()
  {
     
    var x =this.timer.toString()  ;
  this. time = x.split(':',1).toString();
alert('timer: '+this.time+' minutes');
  
    localStorage.setItem('time',this.time);
  }

}
