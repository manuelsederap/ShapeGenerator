import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ValidatorComponent } from '../validator.component';
import { ShapeGeneratorService } from '../shape-generator/shape-generator.service';

@Component({
  selector: 'app-shape-generator',
  templateUrl: './shape-generator.component.html',
  styleUrls: ['./shape-generator.component.css']
})
export class ShapeGeneratorComponent extends ValidatorComponent implements OnInit {

  //shape name
  shapeName?: string;

  //shapeInError
  shapeInError: boolean = false;

  //command
  command!: string;

  // canvas
  @ViewChild('canvas', { static: true }) myCanvas!: ElementRef;

  constructor(
    private fb: FormBuilder,
    private shapeGeneratorService: ShapeGeneratorService
  ) {
    super();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      input: ['', Validators.required, [this.formatCommandAsyncValidator(), this.validateInputtedValue()]]
    })
  };

  onSubmit() {
    const input = this.form.get('input')?.value.toLowerCase();
    this.sendRequestBasedOnShape(input)
  }

  clearCanvas() {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const context = canvas.getContext('2d');
    context?.clearRect(0, 0, canvas.width, canvas.height);
  }

  sendRequestBasedOnShape(input : string) {
    if (input.includes('isosceles triangle')) {
      // send API request to isosceles
      const matches = this.getIsoscelesTriangleData(input)
      if (matches && matches.length === 3) {
        const sideLength: number = parseInt(matches[1], 10)
        const baseLength: number = parseInt(matches[2], 10);
        const data = { sideLength: sideLength, baseLength : baseLength}
        this.shapeGeneratorService.getIsoscelesTriangle(data).subscribe(result => {
          console.log(result);
          this.drawIsoscelesTriangle(result);
        }, error => console.error(error))
      }
    }

    if (input.includes('scalene triangle')) {
      // send API request to scalene
      const matches = this.getScaleneTriangleData(input)
      if (matches) {
        const aSide: number = parseInt(matches[1], 10);
        const bSide: number = parseInt(matches[2], 10);
        const cSide: number = parseInt(matches[3], 10);

        const data = { aSide: aSide, bSide: bSide, cSide: cSide }
        this.shapeGeneratorService.getScaleneTriangle(data).subscribe(result => {
          this.drawScaleneTriangle(result);
        }, error => console.error(error));
      }
    }
  }

  // Method to draw Isosceles Triangle into canvas
  drawIsoscelesTriangle(result : any) {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const context = canvas.getContext('2d');

    // Calculate center of the canvas
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Define triangle vertices
    const x1 = centerX;
    const y1 = centerY - result.height / 2;
    const x2 = centerX - result.baseLength / 2;
    const y2 = centerY + result.height / 2;
    const x3 = centerX + result.baseLength / 2;
    const y3 = y2;

    // Draw the triangle
    context?.beginPath();
    context?.moveTo(x1, y1);
    context?.lineTo(x2, y2);
    context?.lineTo(x3, y3);
    context?.lineTo(x1, y1);
    context?.stroke();
  }

  // Method to draw Scalene Triangle into canvas
  drawScaleneTriangle(result: any) {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const context = canvas.getContext('2d');

    // Define coordinates of vertices
    const x1 = 300;
    const y1 = 500;
    const x2 = x1 + result.cSide;
    const y2 = y1;
    const x3 = x1 + (result.bSide * Math.cos(result.cAngle));
    const y3 = y1 - (result.bSide * Math.sin(result.cAngle));

    // Draw the triangle
    context?.beginPath();
    context?.moveTo(x1, y1);
    context?.lineTo(x2, y2);
    context?.lineTo(x3, y3);
    context?.lineTo(x1, y1);
    //context?.closePath();
    context?.stroke();
  }

}
