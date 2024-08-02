import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoschHomeComponent } from './bosch-home.component';

describe('BoschHomeComponent', () => {
  let component: BoschHomeComponent;
  let fixture: ComponentFixture<BoschHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BoschHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BoschHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
