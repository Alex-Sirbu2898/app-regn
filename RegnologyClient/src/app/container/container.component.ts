import { Component } from '@angular/core';

@Component({
    selector: 'tab-view-scrollable',
    templateUrl: './container.component.html'
})
export class TabViewScrollable {
    activeIndex: number = 0;

    scrollableTabs: any[] = Array.from({ length: 50 }, (_, i) => ({ title: "Title", content: "Content" }));
}