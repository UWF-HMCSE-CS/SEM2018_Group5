
export default class userInfoModules{

    public firstName: string;
    public lastName: string;
    public userEmail: string;
    public userPassword: string;
    public studentRole: boolean;
    public teacherRole: boolean;


    constructor(firstName: string, lastName:string, userEmail: string, userPassword: string, studentRole: boolean, teacherRole: boolean){

        this.firstName = firstName;
        this.lastName = lastName;
        this.userEmail = userEmail;
        this.userPassword = userPassword;
        this.studentRole = studentRole;
        this.teacherRole = teacherRole;
   
    }
    
}