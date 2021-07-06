import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeleteQuestionService {

  constructor(private http:HttpClient) { }
DeleteQuestion(id:string):Observable<string>
{

  return this.http.delete<string>("https://localhost:5001/api/Questions/Delete/" + id);
 

}

}
