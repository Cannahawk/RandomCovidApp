export class Chart {
  title: string;
  type: 'LineChart';
  data: any[];
  columnName: string[];
  options: ChartOptions;
  width: number;
  height: number;
}

export class ChartOptions {
  hAxis: Axis;
  vAxis: Axis;
  pointSize: number;
  backgroundColor: string; // hexcode
  colors: string[]; // 1 color per axis
  crosshair: Crosshair; // point on condition(hover)
}

export class Crosshair {
 color: string;
 trigger: 'selection';
}

export class Axis {
  title: string;
  textStyle: TextStyle;
}

export class TextStyle {
  color: string;
  fontSize: number;
  fontName: string;
  bold: boolean;
  italic: boolean;
}
