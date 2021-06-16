import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { CalculationService } from './calculation.service';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      providers:[CalculationService]
    }).compileComponents();
  }));

  it('should create the AppComponent', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'Bill Calculation'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Bill Calculation');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Bill Calculation');
  });

  it('should calculate bill amount', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    let service=new CalculationService();
    app.quantity=6;
    app.perProductCost=2500;    
    expect(service.BiilCalculation(app.quantity,app.perProductCost)).toEqual(17025);
  }));

  it('should render bill amount in a h3 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;    
    expect(compiled.querySelector('h3').textContent).toContain('Total Bill Amount: 3405');
  });

});
