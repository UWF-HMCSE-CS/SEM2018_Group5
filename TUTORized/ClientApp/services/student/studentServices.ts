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

    public static MakeStudentAppointment(appointment: Appointment, email: string) : Promise<Appointment> {
        console.log(appointment);
        return axios.post(`api/Student/makeStudentAppointment/${email}`, {
            id: appointment.id,
            date: appointment.date,
            subject: appointment.subject,
            tutorId: appointment.tutorId
            })
            .then( response => {
                return response.data;
            })
            .catch(error => {
                console.log(error)
            })
    }
}