import { Component, Input, Output } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { InvestmentUtilities, EntityTypes } from '../../Utilities';
import { InvestmentNote } from '../../Models/InvestmentNote';
import { NewInvestmentNoteComponent } from '../Note/new-note';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'app-list-notes',
  templateUrl: './list-notes.html'
})
export class ListNotesComponent extends InvestmentUtilities {
  modalRef: BsModalRef;
  EntityTypes = EntityTypes;
  errorMessage: string;
  Title = 'Investment Notes';
  @Input() Notes: InvestmentNote[];
  private _OwningEntityType: EntityTypes;
  @Input() OwningEntityId: number;
  @Input()
  set OwningEntityType(OwningEntityType: EntityTypes) {
      this._OwningEntityType = OwningEntityType;
      this.apiService.GetNotes(OwningEntityType, this.OwningEntityId).subscribe( (notes) => {
          console.log('got some notres!');
        notes.forEach(note => {
            this.Notes.push(note);
           console.log('note is' + note.name);
        });
      },  error => this.errorMessage = <any>error);
  }
  get OwningEntityType(): EntityTypes {
    return this._OwningEntityType;
  }


  constructor(protected apiService: ApiService,
              private modalService: BsModalService) {
    super(apiService);
  }

  
}
