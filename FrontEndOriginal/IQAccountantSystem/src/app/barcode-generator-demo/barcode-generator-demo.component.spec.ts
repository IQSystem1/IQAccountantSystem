import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BarcodeGeneratorDemoComponent } from './barcode-generator-demo.component';

describe('BarcodeGeneratorDemoComponent', () => {
  let component: BarcodeGeneratorDemoComponent;
  let fixture: ComponentFixture<BarcodeGeneratorDemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BarcodeGeneratorDemoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BarcodeGeneratorDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
