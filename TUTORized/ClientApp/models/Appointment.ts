export class Appointment {
    id: string;
    studentId: string;
    tutorId: string;
    date: string;
    duration: string;
    subject: string;
    studentFirstName: string;
    studentLastName: string;
    tutorFirstName: string;
    tutorLastName: string;

    constructor() {
        this.id = "";
        this.studentId = "";
        this.tutorId = "";
        this.date = "";
        this.duration = "";
        this.subject = "";
        this.studentFirstName = "";
        this.studentLastName = "";
        this.tutorFirstName = "";
        this.tutorLastName = "";
    }
}
