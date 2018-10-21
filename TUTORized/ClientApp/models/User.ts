export class User {
    id: string;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    role: string;

    constructor() {
        this.id = "";
        this.email = "";
        this.password = "";
        this.firstName = "";
        this.lastName = "";
        this.role = "";
    }
}