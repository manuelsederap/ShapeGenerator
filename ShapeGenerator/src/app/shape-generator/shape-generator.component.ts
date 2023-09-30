import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ValidatorComponent } from '../validator.component';
import { ShapeGeneratorService } from '../shape-generator/shape-generator.service';
import { ShapeDrawer } from '../shape-generator/shape-drawer';

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

  // using viewchild to interact with DOM
  // canvas, to access canvas need to be static true
  @ViewChild('canvas', { static: true }) myCanvas!: ElementRef;
  constructor(
    private fb: FormBuilder,
    private shapeGeneratorService: ShapeGeneratorService,
    private shapeDrawer: ShapeDrawer
  ) {
    super();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      input: ['', Validators.required, [this.formatCommandAsyncValidator(), this.validateInputtedValue()]]
    })
  };

  // Submit button for sending the request
  onSubmit() {
    const input = this.form.get('input')?.value.toLowerCase();
    // Method to check what shape are inputted and get the info from backend
    this.sendRequestBasedOnShape(input)
  }

  // When Clear button click, this method will clear canvas board
  clearCanvas() {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const context = canvas.getContext('2d');
    context?.clearRect(0, 0, canvas.width, canvas.height);
  }

  sendRequestBasedOnShape(input : string) {
    const matches = this.getIsoscelesTriangleData(input)
    if (input.includes('isosceles triangle')) {
      if (matches && matches.length === 3) {
      // send API request to get isosceles triangle info
        this.getIsoscelesTriangle(matches);
      }
    }

    if (input.includes('scalene triangle')) {
      const matches = this.getScaleneTriangleData(input)
      if (matches) {
      // send API request to get scalene triangle info
        this.getScaleneTriangle(matches);
      }
    }

    if (input.includes('equilateral triangle')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get equilateral triangle info
        this.getEquilateralTriangle(matches);
      }
    }

    if (input.includes('rectangle')) {
      const matches = this.getRectangleData(input);
      if (matches) {
      // send API request to  get rectangle info
        this.getRectangle(matches);
      }
    }

    if (input.includes('square')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get square info
        this.getSquare(matches);
      }
    }

    if (input.includes('parallelogram')) {
      const matches = this.getParallelogramData(input);
      if (matches) {
      // send API request to get parallelogram info
        this.getParallelogram(matches);
      }
    }

    if (input.includes('pentagon')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get pentagon info
        this.getPentagon(matches);
      }
    }

    if (input.includes('hexagon')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get hexagon info
        this.getHexagon(matches);
      }
    }

    if (input.includes('heptagon')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get heptagon info
        this.getHeptagon(matches);
      }
    }

    if (input.includes('octagon')) {
      const matches = this.getShapesData(input);
      if (matches) {
      // send API request to get octagon info
        this.getOctagon(matches);
      }
    }

    if (input.includes('circle')) {
      const matches = this.getCircleData(input);
      if (matches) {
      // send API request to get circle info
        this.getCircle(matches);
      }
    }
  }

  getIsoscelesTriangle = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10)
    const baseLength: number = parseInt(matches[2], 10);
    const data = { sideLength: sideLength, baseLength: baseLength }
    this.shapeGeneratorService.sendIsoscelesTriangle(data).subscribe(result => {
      this.shapeDrawer.drawIsoscelesTriangle(result, canvas);
    }, error => console.error(error))
  };

  getScaleneTriangle = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const aSide: number = parseInt(matches[1], 10);
    const bSide: number = parseInt(matches[2], 10);
    const cSide: number = parseInt(matches[3], 10);

    const data = { aSide: aSide, bSide: bSide, cSide: cSide }
    this.shapeGeneratorService.sendScaleneTriangle(data).subscribe(result => {
      this.shapeDrawer.drawScaleneTriangle(result, canvas);
    }, error => console.error(error));
  };

  getEquilateralTriangle = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendEquilateralTriangle(data).subscribe(result => {
      this.shapeDrawer.drawEquilateralTriangle(result, canvas);
    }, error => console.error(error))
  };

  getRectangle = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const length: number = parseInt(matches[1], 10);
    const width: number = parseInt(matches[2], 10);
    const data = { length: length, width: width };
    this.shapeGeneratorService.sendRectangle(data).subscribe(result => {
      this.shapeDrawer.drawRectangle(result, canvas);
    }, error => console.error(error))
  };

  getSquare = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendSquare(data).subscribe(result => {
      this.shapeDrawer.drawSquare(result, canvas);
    }, error => console.error(error))
  };

  getParallelogram = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const height: number = parseInt(matches[1], 10);
    const sideLength: number = parseInt(matches[2], 10);
    const data = { height: height, sideLength: sideLength }
    this.shapeGeneratorService.sendParallelogram(data).subscribe(result => {
      this.shapeDrawer.drawParallelogram(result, canvas);
    }, error => console.error(error))
  };

  getPentagon = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendPentagon(data).subscribe(result => {
      this.shapeDrawer.drawPentagon(result, canvas);
    }, error => console.error(error));
  };

  getHexagon = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendHexagon(data).subscribe(result => {
      this.shapeDrawer.drawHexagon(result, canvas);
    }, error => console.error(error));
  };

  getHeptagon = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendHeptagon(data).subscribe(result => {
      this.shapeDrawer.drawHeptagon(result, canvas);
    }, error => console.error(error));
  };

  getOctagon = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const sideLength: number = parseInt(matches[1], 10);
    const data = { sideLength: sideLength }
    this.shapeGeneratorService.sendOctagon(data).subscribe(result => {
      this.shapeDrawer.drawOctagon(result, canvas);
    }, error => console.error(error));
  };

  getCircle = (matches: RegExpMatchArray) => {
    const canvas: HTMLCanvasElement = this.myCanvas.nativeElement;
    const diameter: number = parseInt(matches[1], 10);
    const data = { diameter: diameter }
    this.shapeGeneratorService.sendCirlce(data).subscribe(result => {
      this.shapeDrawer.drawCircle(result, canvas);
    }, error => console.error(error));
  };
}
