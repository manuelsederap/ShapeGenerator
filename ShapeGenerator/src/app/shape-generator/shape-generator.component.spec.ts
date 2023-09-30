import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { ShapeGeneratorComponent } from './../shape-generator/shape-generator.component';
import { ShapeGeneratorService } from '../shape-generator/shape-generator.service';

describe('ShapeGeneratorComponent', () => {
  let component: ShapeGeneratorComponent;
  let fixture: ComponentFixture<ShapeGeneratorComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShapeGeneratorComponent],
      imports: [
        BrowserAnimationsModule,
        RouterTestingModule,
        ReactiveFormsModule,
        HttpClientModule
      ],
      providers: [
        ShapeGeneratorService
      ]
    })
     .compileComponents();
  });
  beforeEach(() => {
    fixture = TestBed.createComponent(ShapeGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display a "Shape Generator" title', () => {
    let title = fixture.nativeElement
      .querySelector('h1');
    expect(title.textContent).toEqual('Shape Generator');
  });
});
