import { Component, OnInit } from '@angular/core';
import { QuestionTransferService } from '../exam/service/question-transfer.service';
import { Question } from '../nav-menu/models/question';
import { FLAGS } from '@angular/core/src/render3/interfaces/view';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';
import { Router } from '@angular/router';
import { style } from '@angular/animations';

@Component({
  selector: 'app-conduct-test',
  templateUrl: './conduct-test.component.html',
  styleUrls: ['./conduct-test.component.css']
})
export class ConductTestComponent implements OnInit {


  scoreList = new Array();
  course: string;
  tQuestions : Question[];
  k: number;
  //timer
  //counter: { hour:number, min: number, sec: number };
  intervalId: any;
  //counter: number = localStorage.getItem('timerHr');
  timeSec: number = 0;
  timeMin: number = 0;
  timeHr: number = 0;
  limit:number =0;
  swtchAttr:string ='null';
  startExam:string='Start Exam';
  clr:string='#007bff';





  constructor(private ReadQuestions: QuestionTransferService, private router: Router) { }
  questionsLength: number;
  ngOnInit() {
    //debugger;
    this.course = sessionStorage.getItem('cnkey');
    this.tQuestions = this.ReadQuestions.iquestion;
    this.questionsLength = this.tQuestions.length;
    for (let c = 0; c < this.questionsLength; c++) { this.scoreList[c] = 0; }
    //alert( this.tQuestions.length);
    this.swtchAttr = null;
    //debugger
    this.limit = parseInt(localStorage.getItem('time'));
    
    localStorage.removeItem;
    //this.time = this.timeMin/60;

    //alert("Time for exam is:" + this.timeHr + ":" + this.timeMin);

  }


  //To show 
  showQuestions() {
    
    var x = document.getElementById("main");
    if (x.style.display === "none") {
      x.style.display = "block";
    }
   this. swtchAttr='false';
   this.clr='red';
   this.startExam ='Exam Started';
    this.routerOnActivate();


  }


  //timer
  routerOnActivate() {


   
    // this.counter++;
    this.intervalId = setInterval(() => {
      // this.counter++;
      this.timeSec++;
      if (this.timeSec == 60) {
      this.timeMin++;
        this.timeSec = 0;
      }
      if (this.timeMin == 60) {
      this.timeHr++;
        this.timeMin = 0;
      }
      if (this.timeHr == (this.limit/3600) && this.timeMin == (this.limit/60) && this.timeSec == 0) {
        //this.limit = 1;
        this.scoreCalculator();
        clearInterval(this.intervalId);
      }

    }, 1000);
  }

  routerOnDeactivate() {
    clearInterval(this.intervalId);
  }




  score: number = 0;

  scoreBoard(i: number) {

    this.scoreList[i] = 1;

    this.flag[i] = 'true';
  }


  flag: string[] = [];
  disableOption(i: number) {
    this.flag[i] = 'true';

  }


  clearResponse(i: number) {
    this.flag[i] = null;
    this.scoreList[i] = 0;

  }

  totalMarks: number = 0;
  finalScore: number = 0;
  scoreCalculator() {
    this.totalMarks = 0;
    this.k = 0;
    while (this.k < this.questionsLength) {
      //alert(this.totalMarks);
      this.totalMarks = this.totalMarks + this.scoreList[this.k];
      this.k++;
    }
    // this.fquestion.totalScore=this.totalMarks;

    this.submitResult()

  }

  submitResult() {
    if (this.limit == 1) {
      sessionStorage.setItem('finalScore', this.totalMarks.toString());//alert(this.questionsLength);
      sessionStorage.setItem('questionCount', this.questionsLength.toString());
      this.router.navigateByUrl('scoreBoard');

    }
    else {

      if (confirm("Are you sure to submit exam?") == true) {

        sessionStorage.setItem('finalScore', this.totalMarks.toString());//alert(this.questionsLength);
        sessionStorage.setItem('questionCount', this.questionsLength.toString());
        this.router.navigateByUrl('scoreBoard');

      }


    }





  }


}
