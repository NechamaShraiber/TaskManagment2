import { ValidatorFn, FormGroup } from '@angular/forms';
export class validate {
  public static createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} must be max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} must be min ${min} chars` } : null,
    ];
  }
   public static createValidatorDate(group: FormGroup): Array<ValidatorFn> {
     return null;
   }


}
