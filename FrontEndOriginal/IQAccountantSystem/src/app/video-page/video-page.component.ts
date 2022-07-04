import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';

@Component({
  selector: 'app-video-page',
  templateUrl: './video-page.component.html',
  styleUrls: ['./video-page.component.css']
})
export class VideoPageComponent implements OnInit {

  private sub: any;
  url:any;
  constructor(private route: ActivatedRoute, private dialog:MatDialog,private router:Router) { }

  ngOnInit(): void {
    this.dialog.closeAll();
    this.route.params.subscribe(
      data=>console.log(data)
    )
    
  }

}
