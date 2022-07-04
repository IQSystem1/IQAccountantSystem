import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'IQAccountantSystem';
  ngOnInit(): void {
    
  }
  Click(){
    window.open("https://stackoverflow.com/questions/726761/javascript-open-in-a-new-window-not-tab", "_blank", "height=500,width=1000");

  }
}
