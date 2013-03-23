// Interface
interface IPoint {
    getDist(): number;
}

// Module
module Shapes {

    // Class
    export class Point implements IPoint {
        // Constructor
        constructor (public x: number, public y: number) { }

        // Instance member
        getDist() { return Math.sqrt(this.x * this.x + this.y * this.y); }

        // Static member
        static origin = new Point(0, 0);
    }

}

// Local variables
var p: IPoint = new Shapes.Point(3, 4);
var dist = p.getDist();


module Home {

    class NotificationInfo {

        constructor (public date: Date, public title: string, public text?: string) { }

        renderEvent(container : HTMLElement) {
            container.innerHTML = '<span class="lastNotificationDate">'+ this.date.toString() +'</span>';
            container.innerHTML += '<span class="lastNotificationName">'+ this.title +'</span>';
            if (typeof (this.text) != 'undefined') {
                 container.innerHTML += '<span class="lastNotificationText">'+ this.text +'</span>';
            }
        }
    }
}