import { FormGroup, FormControl, Validators } from "@angular/forms";

export class NewEvent {
    registrationForm: FormGroup = new FormGroup({
        eventId: new FormControl(0, Validators.required),
        eventCode: new FormControl('NOCODE', [Validators.required, Validators.minLength(6), Validators.maxLength(6)]),
        eventName: new FormControl('No Name', Validators.required),
        description: new FormControl(),
        startDate: new FormControl(),
        endDate: new FormControl(),
        seatsFilled: new FormControl(0, [Validators.required, Validators.min(0), Validators.max(100)]),
        fees: new FormControl(0, [Validators.required, Validators.min(0)]),
    });
}
