import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RisksGraphComponent } from './risks-graph.component';

describe('RisksGraphComponent', () => {
  let component: RisksGraphComponent;
  let fixture: ComponentFixture<RisksGraphComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RisksGraphComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RisksGraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
