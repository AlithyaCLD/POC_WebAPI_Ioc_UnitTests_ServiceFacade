import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from "@angular/material";
import { ModalService } from './Services';
import {CourseDialogComponent} from "./Dialog/course-dialog.component";

import './Content/app.less';
import './Content/modal.less';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  constructor(private dialog: MatDialog) {}

  openDialog() {

      const dialogConfig = new MatDialogConfig();

      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;

      this.dialog.open(CourseDialogComponent, dialogConfig);
  }
}

// export class AppComponent  implements OnInit {
//   private bodyText: string;

//   constructor(private modalService: ModalService) 
//   {
//   }

//   ngOnInit() {
//       this.bodyText = 'This text can be updated in modal 1';
//   }

//   openModal(id: string) {
//     console.log("OPENING MODAL!");
//     this.modalService.open(id);
//   }

//   closeModal(id: string) {
//       this.modalService.close(id);
//   }
// }