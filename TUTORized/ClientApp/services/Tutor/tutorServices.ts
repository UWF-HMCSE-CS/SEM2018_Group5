import { User } from '../../models/User';
import axios from 'axios';
import { Appointment } from '../../models/Appointment';

export default class TutorService {

    public static addAppointment() {

    }


    public static getListOfTutors(): Promise<Array<User>> {
        return axios.get('api/student')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }

    public static getListOfStudents(): Promise<Array<User>> {
        return axios.get('api/tutor/getAllStudents')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }

    public static upgradeStudentToTutor(user: User) {
        return axios.post('api/tutor/upgradeStudentToTutor', {
            email: user.email,
            id: user.id,
            password: user.password,
            firstName: user.firstName,
            lastName: user.lastName,
            role: user.role
        })
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }
}
