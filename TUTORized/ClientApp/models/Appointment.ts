export class Appointment {
    id: string;
    studentId: string;
    tutorId: string;
    date: string;
    duration: string;
    subject: string;

    constructor() {
        this.id = "";
        this.studentId = "";
        this.tutorId = "";
        this.date = "";
        this.duration = "";
        this.subject = "";
    }
}
