import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatoverviewComponent } from './chatoverview.component';

describe('ChatoverviewComponent', () => {
  let component: ChatoverviewComponent;
  let fixture: ComponentFixture<ChatoverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatoverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatoverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
