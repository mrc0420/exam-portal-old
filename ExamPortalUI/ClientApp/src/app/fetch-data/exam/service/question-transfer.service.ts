import { Injectable } from '@angular/core';
import { Question } from '../../nav-menu/models/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionTransferService {
 iquestion:  Question[];
 countOfQuestions:number;
 totalScore:number;
  constructor() { }
}
