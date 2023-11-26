import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateTime'
})
export class DateTimePipe implements PipeTransform {

  transform(value: Date): Date | null {
    if (!value) {
      return null;
    }

    const parts = value.toString().split('/');
    if (parts.length !== 3) {
      return null;
    }

    const year = parseInt(parts[2], 10);
    const month = parseInt(parts[1], 10);
    const day = parseInt(parts[0], 10);

    if (!isNaN(year) && !isNaN(month) && !isNaN(day)) {
      return new Date(year, month - 1, day);
    } else {
      return null;
    }
  }
}


