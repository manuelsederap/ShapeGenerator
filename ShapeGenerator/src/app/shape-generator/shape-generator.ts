export interface IsoscelesTriangle {
  name: string;
  isValidResponse: boolean;
  height: number;
  baseLength: number;
  sideLength: number;
}

export interface ScaleneTriangle {
  name: string;
  isValidResponse: boolean;
  aSide: number;
  bSide: number;
  cSide: number;
  aAngle: number;
  bAngle: number;
  cAngle: number;
}

export interface EquilateralTriangle {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  height: number;
}

export interface Rectangle {
  name: string;
  isValidResponse: boolean;
  length: number;
  width: number;
  area: number;
}

export interface Square {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  area: number;
}

export interface Parallelogram {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  height: number;
  area: number;
  angle: number;
}

export interface Pentagon {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  perimeter: number;
  area: number;
  radius: number;
}

export interface Hexagon {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  perimeter: number;
  area: number;
  SumOfAllInternalAngles: number;
}

export interface Heptagon {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  perimeter: number;
  area: number;
}

export interface Octagon {
  name: string;
  isValidResponse: boolean;
  sideLength: number;
  perimeter: number;
  area: number;
}

export interface Circle {
  name: string;
  isValidResponse: boolean;
  diameter: number;
  radius: number;
  area: number;
  circumference: number;
}



