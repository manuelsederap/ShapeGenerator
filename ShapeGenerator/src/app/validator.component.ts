import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable, of } from 'rxjs';

@Component({
  template: ''
})
export abstract class ValidatorComponent {

  // the form model
  form!: FormGroup;

  //error message
  errorMessage?: string;

  //shapeErrorMessage
  shapeErrorMessage?: string;

  /// validate if the inputted value is > 1000
  validateInputtedValue(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      const inputString = control.value;

      const inputValue = this.form.get('input')?.value.toLowerCase();

      /// check the value of inputted in isosceles triangle form invalid if greater than 1000
      if (inputValue.includes('isosceles triangle')) {

        const matches = this.getIsoscelesTriangleData(inputValue);

        if (matches && matches.length === 3) {
          const sideLength: number = parseInt(matches[1], 10)
          const baseLength: number = parseInt(matches[2], 10);

          // if value greater than 1000, form invalid will trigger
          if (sideLength > 1000 || baseLength > 1000) {
            return of({ invalidValue: true });
          }

          // if baseLength > sideLength, form invalid will trigger
          if (baseLength > sideLength) {
            return of({ inputIsoscelesValue: true });
          }
        }

        /// check the value of inputted in scalene triangle form invalid if greater than 1000
      } else if (inputValue.includes('scalene triangle')) {

        const matches = this.getScaleneTriangleData(inputValue);

        if (matches) {
          const aSide: number = parseInt(matches[1], 10);
          const bSide: number = parseInt(matches[2], 10);
          const cSide: number = parseInt(matches[3], 10);

          // if value greater than 1000, form invalid will trigger
          if (aSide > 1000 || bSide > 1000 || cSide > 1000) {
            return of({ invalidValue: true });
          }

          // check side, scalen triangle side must not equal to each other
          if (aSide == bSide) {
            return of({ inputScaleneValue: true })
          } else if (bSide == cSide) {
            return of({ inputScaleneValue: true })
          } else if (cSide == aSide) {
            return of({ inputScaleneValue: true })
          } else {
            return of(null);
          }
        }

        /// other shapes also, if length is greater than 1000, form is invalid
      } else {
        const matches = this.getShapesData(inputValue);
        if (matches) {
          const sideLength: number = parseInt(matches[1], 10);
          // if value greater than 1000, form invalid will trigger
          if (sideLength > 1000) {
            return of({ invalidValue: true });
          }
        }
      }
      return of(null);
    };
  }

  // validate format of command, form is invalid if wrong format
  formatCommandAsyncValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      const inputString = control.value;

      const formatPattern = /^Draw a (isosceles triangle with a side length of \d+ and base length of \d+|scalene triangle with a A-Side length of \d+, B-Side length of \d+, and C-Side length of \d+|rectangle with a length of \d+ and width of \d+|circle with a diameter of \d+|parallelogram with a height of \d+ and side length of \d+|(equilateral triangle|square|pentagon|hexagon|heptagon|octagon) with a side length of \d+)$/


      const inputValue = this.form.get('input')?.value.toLowerCase();

      if (inputString && !formatPattern.test(inputString)) {

        if (inputValue.includes('isosceles triangle')) {

          this.errorMessage = `For Isosceles Triangle, Please follow this sample format: ${this.getisoscelesErrorMessage()}`;

        } else if (inputValue.includes('scalene triangle')) {

          this.errorMessage = `For Scalene Triangle, Please follow this sample format: ${this.getScaleneErrorMessage()}`;

        } else if (inputValue.includes('rectangle')) {

          this.errorMessage = `For rectangle, Please follow this sample format: ${this.getRectangleErrorMessage()}`;

        } else if (inputValue.includes('circle')) {

          this.errorMessage = `For circle, Please follow this sample format: ${this.getCircleErrorMessage()}`;

        } else if (inputValue.includes('parallelogram')) {

          this.errorMessage = `For parallelogram, Please follow this sample format: ${this.getParallelogramErrorMessage()}`;

        } else {

          this.errorMessage = `Invalid Shape or Format, Please follow this sample format: ${this.getShapeErrorMessage(inputValue)}`
        }
        return of({ invalidFormat: true });
      }
      return of(null);
    };
  }

  getisoscelesErrorMessage() {
    this.shapeErrorMessage = "Draw a isosceles triangle with a side length of 600 and base length of 300";
    return this.shapeErrorMessage;
  }

  getScaleneErrorMessage() {
    this.shapeErrorMessage = "Draw a scalene triangle with a A-Side length of 340, B-Side length of 150, and C-Side length of 320";
    return this.shapeErrorMessage;
  }

  getRectangleErrorMessage() {
    this.shapeErrorMessage = "Draw a rectangle with a length of 600 and width of 300";
    return this.shapeErrorMessage;
  }

  getCircleErrorMessage() {
    this.shapeErrorMessage = "Draw a circle with a diameter of 300";
    return this.shapeErrorMessage;
  }

  getParallelogramErrorMessage() {
    this.shapeErrorMessage = "Draw a parallelogram with a height of 300 and side length of 500";
    return this.shapeErrorMessage;
  }

  getShapeErrorMessage(inputValue: string) {
    if (inputValue.includes('square')) {
      this.shapeErrorMessage = "Draw a square with a side length of 500"
    } else if (inputValue.includes('pentagon')) {
      this.shapeErrorMessage = "Draw a pentagon with a side length of 500";
    } else if (inputValue.includes('hexagon')) {
      this.shapeErrorMessage = "Draw a hexagon with a side length of 500";
    } else if (inputValue.includes('heptagon')) {
      this.shapeErrorMessage = "Draw a heptagon with a side length of 500";
    } else if (inputValue.includes('octagon')) {
      this.shapeErrorMessage = "Draw a octagon with a side length of 500";
    } else if (inputValue.includes('equilateral triangle')) {
      this.shapeErrorMessage = "Draw a equilateral triangle with a side length of 500";
    } else {
      this.shapeErrorMessage = "Draw a square with a side length of 500";
    }
    return this.shapeErrorMessage;
  }

  getIsoscelesTriangleData(inputValue: string) {
    return inputValue.match(/side length of (\d+) and base length of (\d+)/i);
  }

  getScaleneTriangleData(inputValue: string) {
    return inputValue.match(/A-Side length of (\d+), B-Side length of (\d+), and C-Side length of (\d+)/i);
  }

  getRectangleData(inputValue: string) {
    return inputValue.match(/length of (\d+) and width of (\d+)/i);
  }

  getCircleData(inputValue: string) {
    return inputValue.match(/diameter of (\d+)/i);
  }

  getParallelogramData(inputValue: string) {
    return inputValue.match(/height of (\d+) and side length of (\d+)/i);
  }

  getShapesData(inputValue: string) {
    return inputValue.match(/side length of (\d+)/i);
  }

  constructor() { }
}
