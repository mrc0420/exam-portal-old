import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConductTestComponent } from './conduct-test.component';

describe('ConductTestComponent', () => {
  let component: ConductTestComponent;
  let fixture: ComponentFixture<ConductTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConductTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConductTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
