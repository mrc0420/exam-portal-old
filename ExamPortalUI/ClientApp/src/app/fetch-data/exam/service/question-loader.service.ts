import { Injectable } from '@angular/core';
import { Question } from '../../nav-menu/models/question';
import { HttpClient } from '@angular/common/http';
import { observable, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestionLoaderService {
  fetchedQuestions:  Question;






  constructor(private http:HttpClient) { }

  public QuestionFetch(selectedId: number): Observable<Question>
  {
   
  return this.http.get<Question>("https://localhost:5001/api/Questions/" + selectedId);


 // alert(this.fetchedQuestions[1].question);

}


}
