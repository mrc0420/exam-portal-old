import { Component, OnInit } from '@angular/core';
import { QuestionTransferService } from '../exam/service/question-transfer.service';
import { HttpClient } from '@angular/common/http';
import { Courselist } from '../nav-menu/models/courselist';

@Component({
  selector: 'app-score-board',
  templateUrl: './score-board.component.html',
  styleUrls: ['./score-board.component.css']
})
export class ScoreBoardComponent implements OnInit {

  constructor() { }
  
  finalScore:number;
  questionCount:number;
  percentage:number=0;
  passPercentage:number;
  status:string;
  ngOnInit() {

     
  
    this.finalScore = parseInt(sessionStorage.getItem('finalScore'));
    this.questionCount = parseInt(sessionStorage.getItem('questionCount'));
     this.passPercentage =  parseInt(sessionStorage.getItem('percentage'));
    this.percentage = (this.finalScore/this.questionCount)*100;
   
    if(this.percentage>this.passPercentage || this.percentage == this.passPercentage)
    {
        this.status='Pass';
    }
    else
    {
      this.status='Fail';
    }
     


  }
  
   

}
