export class Message {
    id: string;
    studentId: string;
    tutorId: string;
    sendToId: string;
    messageBody: string;
    studentFirstName: string;
    studentLastName: string;
    tutorFirstName: string;
    tutorLastName: string;
    
    

    constructor() {
        this.id = "";
        this.studentId = "";
        this.tutorId = "";
        this.sendToId = "";
        this.messageBody = "";
        this.studentFirstName = "";
        this.studentLastName = "";
        this.tutorFirstName = "";
        this.tutorLastName = "";
        
    }
}
