/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MainTodoComponent } from './main-todo.component';

describe('MainTodoComponent', () => {
  let component: MainTodoComponent;
  let fixture: ComponentFixture<MainTodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainTodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainTodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
