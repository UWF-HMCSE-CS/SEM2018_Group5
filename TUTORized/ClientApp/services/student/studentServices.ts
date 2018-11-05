import { User } from '../../models/User';
import axios from 'axios';
import { Appointment } from '../../models/Appointment';

export default class StudentService {

    public static GetListOfAllAvailableAppointments() : Promise<Array<Appointment>> {
        return axios.get('api/Student/getAppointments')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }

    public static MakeStudentAppointment(appointmentId: string) : Promise<Appointment> {
        return axios.post('api/Student/makeStudentAppointment', {
            id: appointmentId
            })
            .then( response => {
                return response.data;
            })
            .catch(error => {
                console.log(error)
            })
    }
}