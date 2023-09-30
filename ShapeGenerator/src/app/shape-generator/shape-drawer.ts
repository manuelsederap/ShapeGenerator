import { Injectable, ElementRef, ViewChild } from '@angular/core';
import {
  IsoscelesTriangle,
  ScaleneTriangle,
  EquilateralTriangle,
  Rectangle,
  Square,
  Parallelogram,
  Pentagon,
  Hexagon,
  Heptagon,
  Octagon,
  Circle
} from '../../app/shape-generator/shape-generator';

@Injectable({
  providedIn: 'root',
})

export class ShapeDrawer {

  constructor() {}

  // Method to draw Isosceles Triangle into canvas
  drawIsoscelesTriangle(result: IsoscelesTriangle, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Define triangle vertices
    //const x1 = 500;
    //const y1 = 500;
    const x1 = canvas.width / 2;
    const y1 = (canvas.height - result.height) / 2;
    const x2 = x1 - result.baseLength / 2;
    const y2 = canvas.height;
    const x3 = x1 + result.baseLength / 2;
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
  drawScaleneTriangle(result: ScaleneTriangle, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Define coordinates of vertices
    const x1 = 500;
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

  // Method to draw Equilateral Triangle into canvas
  drawEquilateralTriangle(result: EquilateralTriangle, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Define coordinates of the vertices
    const x1 = canvas.width / 2;
    const y1 = (canvas.height - result.height) / 2;
    const x2 = x1 - result.sideLength / 2;
    const y2 = y1 + result.height;
    const x3 = x1 + result.sideLength / 2;
    const y3 = y1 + result.height;

    // Draw the equilateral triangle
    context?.beginPath();
    context?.moveTo(x1, y1);
    context?.lineTo(x2, y2);
    context?.lineTo(x3, y3);
    context?.lineTo(x1, y1);
    context?.stroke();
  }

  // Method to draw Rectangle into canvas
  drawRectangle(result: Rectangle, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate coordinates of the top-left corner
    const x = (canvas.width - result.length) / 2;
    const y = (canvas.height - result.width) / 2;

    context?.beginPath();
    context?.rect(x, y, result.length, result.width);
    context?.stroke();
  }

  // Method to draw square into canvas
  drawSquare(result: Square, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate coordinates of the top-left corner
    const x = (canvas.width - result.sideLength) / 2;
    const y = (canvas.height - result.sideLength) / 2;

    // Draw the square using path and stroke
    context?.beginPath();
    context?.rect(x, y, result.sideLength, result.sideLength);
    context?.stroke();
  }

  // Method to draw parallelogram into canvas
  drawParallelogram(result: Parallelogram, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate coordinates of the vertices
    const x1 = (canvas.width - result.sideLength) / 2;
    const y1 = (canvas.height - result.height) / 2;
    const x2 = x1 + result.sideLength;
    const y2 = y1;
    const x3 = x2 - result.height;
    const y3 = y2 + result.height;
    const x4 = x1 - result.height;
    const y4 = y1 + result.height;

    // Draw the parallelogram
    context?.beginPath();
    context?.moveTo(x1, y1);
    context?.lineTo(x2, y2);
    context?.lineTo(x3, y3);
    context?.lineTo(x4, y4);
    context?.lineTo(x1, y1);
    context?.stroke();
  }

  // Method to draw pentagon into canvas
  drawPentagon(result: Pentagon, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate the coordinates of the vertices
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Draw the pentagon
    context?.beginPath();
    context?.moveTo(centerX + result.radius * Math.cos(0), centerY + result.radius * Math.sin(0));

    for (let i = 1; i <= 5; i++) {
      const angle = i * (2 * Math.PI / 5);
      context?.lineTo(centerX + result.radius * Math.cos(angle), centerY + result.radius * Math.sin(angle));
    }

    context?.closePath();
    context?.stroke();
  }

  // Method to draw hexagon into canvas
  drawHexagon(result: Hexagon, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate the coordinates of the vertices
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Draw the hexagon
    context?.beginPath();
    context?.moveTo(centerX + result.sideLength * Math.cos(0), centerY + result.sideLength * Math.sin(0));

    for (let i = 1; i <= 6; i++) {
      const angle = i * (2 * Math.PI / 6);
      context?.lineTo(centerX + result.sideLength * Math.cos(angle), centerY + result.sideLength * Math.sin(angle));
    }

    context?.closePath();
    context?.stroke();
  }

  // Method to draw heptagon into canvas
  drawHeptagon(result: Heptagon, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate the coordinates of the vertices
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Draw the heptagon
    context?.beginPath();
    context?.moveTo(centerX + result.sideLength * Math.cos(0), centerY + result.sideLength * Math.sin(0));

    for (let i = 1; i <= 7; i++) {
      const angle = i * (2 * Math.PI / 7);
      context?.lineTo(centerX + result.sideLength * Math.cos(angle), centerY + result.sideLength * Math.sin(angle));
    }

    context?.closePath();
    context?.stroke();
  }

  // Method to draw octagon into canvas
  drawOctagon(result: Octagon, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate the coordinates of the vertices
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Draw the octagon
    context?.beginPath();
    context?.moveTo(centerX + result.sideLength * Math.cos(0), centerY + result.sideLength * Math.sin(0));

    for (let i = 1; i <= 8; i++) {
      const angle = i * (2 * Math.PI / 8);
      context?.lineTo(centerX + result.sideLength * Math.cos(angle), centerY + result.sideLength * Math.sin(angle));
    }

    context?.closePath();
    context?.stroke();
  }

  // Method to draw octagon into canvas
  drawCircle(result: Circle, canvas: HTMLCanvasElement) {
    const context = canvas.getContext('2d');

    // Calculate the center coordinates
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    // Draw the circle
    context?.beginPath();
    context?.arc(centerX, centerY, result.radius, 0, 2 * Math.PI);
    context?.stroke();
  }

}
