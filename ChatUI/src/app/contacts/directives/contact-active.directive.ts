import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appContactActive]'
})
export class ContactActiveDirective {

  constructor(private elementRef: ElementRef, private render: Renderer2) {
    this.render.setStyle(elementRef.nativeElement,
      'background', 'red');
  }

}
