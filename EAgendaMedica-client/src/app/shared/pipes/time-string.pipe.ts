import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeString'
})
export class TimeStringPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
