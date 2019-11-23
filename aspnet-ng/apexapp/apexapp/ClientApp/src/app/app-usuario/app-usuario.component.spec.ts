import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppUsuarioComponent } from './app-usuario.component';

describe('AppUsuarioComponent', () => {
  let component: AppUsuarioComponent;
  let fixture: ComponentFixture<AppUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
