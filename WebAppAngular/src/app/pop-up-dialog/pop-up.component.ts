import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'pop-up-dialog',
  templateUrl: 'pop-up.component.html'
})
export class PopUpDialog {

  constructor(
    public dialogRef: MatDialogRef<PopUpDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { ok: false , question : ""}) { }

  Cancel(): void {
    this.dialogRef.close(false);
  }

  Save(): void {
    this.dialogRef.close(true);
  }
}
