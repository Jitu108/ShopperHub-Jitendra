import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from 'src/app/services/identity.service';
import { LoginModel } from 'src/models/login-model';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  public isLoading: boolean = false;
  public error: { hasError: boolean, message: string } = { hasError: false, message: "" };


  Email: string;
  Password: string;
  constructor(private identityService: IdentityService, private router: Router) { }

  ngOnInit(): void {
    this.error.hasError = false;
  }

  // Submit
  onLoginClick(form: any) {
    if (form.valid) {
      this.isLoading = true;
      this.error.hasError = false;

      this.identityService.login(new LoginModel(this.Email, this.Password))
        .subscribe(res => {
          console.log(res);
          this.isLoading = false;
          this.router.navigate(['/products']);
        }), (error: any) => {
          this.error = { hasError: true, message: error.message };
          this.isLoading = false;
        }
    }
  }

  // Cancel
  onCancelClick() {
    this.error = { hasError: false, message: "" };
  }

}
