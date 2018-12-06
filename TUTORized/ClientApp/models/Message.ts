import { User } from "./User";

export class Message {
    id: string;
    fromUser: User;
    toUser: User;
    messageBody: string;

    constructor() {
        this.id = "";
        this.fromUser = new User();
        this.toUser = new User();
        this.messageBody = "";
    }
}
