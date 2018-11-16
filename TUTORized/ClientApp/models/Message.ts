export class Message {
    id: string;
    fromUserId: string;
    toUserId: string;
    messageBody: string;

    constructor() {
        this.id = "";
        this.fromUserId = "";
        this.toUserId = "";
        this.messageBody = "";
    }
}
