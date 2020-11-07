import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loginFailed: boolean;

  constructor(private router: Router, private toastrService: ToastrService) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      'username': new FormControl('', { validators: [Validators.required] }),
      'password': new FormControl('', { validators: [Validators.required] }),
    });
    this.loginFailed = false;
  }
  // login method
  login() {
    this.router.navigate(['/news']);
  }
  // reset validation after exiting validation window
  closeValidationInfo(inputValidation: AbstractControl) {
    inputValidation.markAsUntouched();
    inputValidation.markAsPristine();
  }
  // reset div
  reset() {
    this.loginFailed = false;
  }
  // getters
  get username() { return this.loginForm.get('username') }
  get password() { return this.loginForm.get('password') }
}
