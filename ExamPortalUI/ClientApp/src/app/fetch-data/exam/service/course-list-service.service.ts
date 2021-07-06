import { Injectable } from '@angular/core';
import { Courselist } from '../../nav-menu/models/courselist';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseListServiceService {

  courselist = new Courselist();


  constructor(private http:HttpClient) { }

courseListLoader():Observable<Courselist>
{
  return this.http.get<Courselist>("https://localhost:5001/api/Course");
  
}

}
