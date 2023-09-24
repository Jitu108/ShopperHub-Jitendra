import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-address',
  templateUrl: './order-address.component.html',
  styleUrls: ['./order-address.component.scss']
})
export class OrderAddressComponent implements OnInit {

  constructor() { }

  public isLoading: boolean = false;
  public error: { hasError: boolean, message: string } = { hasError: false, message: "" };

  firstName: string;
  lastName: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  state: string;
  pin: string;
  cardType: string;

  ngOnInit(): void {
  }

  onSaveAddressClick(form: any) {
  }
  onCancelClick() {

  }

}
