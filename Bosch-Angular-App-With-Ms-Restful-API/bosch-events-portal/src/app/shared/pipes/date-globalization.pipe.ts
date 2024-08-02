import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateGlobalization',
  standalone: true
})
export class DateGlobalizationPipe implements PipeTransform {

  transform(value: Date | number, ...args: string[]): string {
    let locale: string = args[0] ? args[0] : 'en-IN';
    return Intl.DateTimeFormat(locale, {
      weekday: 'long',
      day: '2-digit',
      month: 'long',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    }).format(new Date(value));
  }

}
