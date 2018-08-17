import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs';
import { Observable } from 'rxjs';
import { NotifyMsg }  from '../Entities/NotifyMsg';

@Injectable()
export class ChangeNotifyServices {

  private subject: Subject<NotifyMsg> = new Subject<NotifyMsg>();
  private notifyMsg: NotifyMsg;
  constructor()
  {
    
      this.notifyMsg = new NotifyMsg();
  }
  setPeriodChanged(notifyMsg: NotifyMsg): void {
    this.notifyMsg = notifyMsg;
    this.subject.next(notifyMsg);
  }
  
  getPeriodChanged(): Observable<NotifyMsg> {
    return this.subject.asObservable();
  }
}

