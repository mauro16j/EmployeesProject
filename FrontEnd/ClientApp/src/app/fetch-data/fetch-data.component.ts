import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmployeeService } from '../shared/employee.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public formGroup: FormGroup;
  public employees: any = [];

  constructor( private formBuilder: FormBuilder,
              private employeeService: EmployeeService ) { }

  public ngOnInit() {
    this.buildForm();
  }
  private buildForm(){
    this.formGroup = this.formBuilder.group({
      idEmployee:[]
    });
  }

  async onSubmit(){
    try{
      this.employees = [];
      const id = this.formGroup.value.idEmployee;

      if(id === null){
          this.employees = await this.employeeService.listEmployees();
      } else {
        this.employees = await this.employeeService.getemployee(id);
      }
    } catch(err){
      alert('Ocurrio un error inesperado');
    }

  }


}

