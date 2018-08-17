import { BrowserModule,Title } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule, HttpClient }          from '@angular/common/http';
import { RouterModule, Routes }                  from '@angular/router';
import { FormsModule }                           from '@angular/forms';
import { BrowserAnimationsModule }               from '@angular/platform-browser/animations';

import { AppComponent }               from './app.component';
import { LoadMonthlyComponent}        from './LoadMonthly/LoadMonthly';
import { ProcessTaxCADComponent}      from './ProcessTaxCAD/ProcessTaxCAD';
import { ProcessTaxUSDComponent}      from './ProcessTaxUSD/ProcessTaxUSD';
import { TaxRemVerificationComponent} from './TaxRemittanceVerification/TaxRemittanceVerification';
import { LoadReportDialogComponent}   from './TaxRemittanceVerification/LoadReport.dialog';
import { ExportTemplatesComponent}    from './ExportTemplates/ExportTemplates';
import { TaxRemAdminComponent}        from './TaxRemAdmin/TaxRemAdmin';
import { ReconciliationComponent}     from './Reconciliation/Reconciliation';
import { TaxDtl502009dialog}          from './ProcessTaxCAD/TaxDtl502009.dialog';
import { TaxDtl502010dialog}          from './ProcessTaxCAD/TaxDtl502010.dialog';
import { TaxDtl502563dialog}          from './ProcessTaxCAD/TaxDtl502563.dialog';

import { TaxDtl502103Adialog}          from './ProcessTaxCAD/TaxDtl502103A.dialog';
import { TaxDtl502103Bdialog}          from './ProcessTaxCAD/TaxDtl502103B.dialog';
// TaxDtl502010dialog

import { GenerateTaxAmtRptComponent}      from './GenerateTaxAmtRpt/GenerateTaxAmtRpt';

import { GlobalCacheServices}             from './Services/GlobalCacheServices';
import { LoadMonthlyServices}             from './Services/LoadMonthlyServices';
import { ConstantsServices}               from './Services/ConstantsServices';
import { TaxRemittanceCAServices}         from './Services/TaxRemittanceCAServices';
import { ChangeNotifyServices}            from './Services/ChangeNotifyServices';
import { UiOverRideServices}              from './Services/UiOverRideServices';
import { TaxReportServices}               from './Services/TaxReportServices';
import { DropDownServices}                from './Shared/DropDownServices';

const appRoutes: Routes = [
  { path: '', redirectTo: 'LoadMthly', pathMatch: 'full' },    // generateTaxAmtRptComponent
  { path: 'LoadMthly', component: LoadMonthlyComponent},
  { path: 'TaxRemCAD', component: ProcessTaxCADComponent},
  { path: 'TaxRemUSD', component: ProcessTaxUSDComponent},
  { path: 'TaxRemVer', component: TaxRemVerificationComponent},
  { path: 'ExportTem', component: ExportTemplatesComponent},
  { path: 'TaxRemAdmin', component: TaxRemAdminComponent},
  { path: 'Reconcili', component: ReconciliationComponent},
  { path: 'GenTaxRpt', component: GenerateTaxAmtRptComponent}
];

@NgModule({
  // TaxDtl502009dialog
  declarations: [
    AppComponent,LoadMonthlyComponent,ProcessTaxCADComponent,TaxRemVerificationComponent,GenerateTaxAmtRptComponent,
    LoadReportDialogComponent,TaxDtl502009dialog,TaxDtl502563dialog,ProcessTaxUSDComponent,ExportTemplatesComponent,
    TaxRemAdminComponent, ReconciliationComponent,TaxDtl502103Adialog,TaxDtl502103Bdialog,TaxDtl502010dialog
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    BrowserModule,HttpClientModule,FormsModule,BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [Title,HttpClientModule, HttpClient,DropDownServices,GlobalCacheServices,LoadMonthlyServices,ConstantsServices,
              TaxRemittanceCAServices,ChangeNotifyServices,UiOverRideServices, TaxReportServices],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})

export class AppModule { }
