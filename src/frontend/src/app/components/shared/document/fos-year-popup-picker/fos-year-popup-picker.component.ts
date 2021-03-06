import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FieldOfStudy } from 'src/app/core/models/field-of-study/field-of-study';
import { Specialization } from 'src/app/core/models/field-of-study/specialization';

@Component({
  selector: 'app-fos-year-popup-picker',
  templateUrl: './fos-year-popup-picker.component.html',
  styleUrls: ['./fos-year-popup-picker.component.scss']
})
export class FosYearPopupPickerComponent implements OnInit {

  title: string = '';
  isSpec: boolean = false;
  selectedFos: FieldOfStudy | null = null;
  selectedSpec: Specialization | null = null;
  selectedYear: string | null = null;
  allFields: boolean = false;

  constructor(public dialogRef: MatDialogRef<FosYearPopupPickerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
    dialogRef.disableClose = true;
    this.title = data.title;
    this.isSpec = data.isSpec ?? false;
    this.allFields = data.allFields ?? false;
  }

  ngOnInit(): void {
  }

  submit() {
    this.dialogRef.close({
      fos: this.selectedFos,
      year: this.selectedYear,
      spec: this.selectedSpec
    });
  }
}
