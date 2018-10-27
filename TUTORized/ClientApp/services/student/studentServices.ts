import { User } from '../../models/User';
import axios from 'axios';
import { Appointment } from '../../models/Appointment';

export default class ScheduleAppointment {

    public static GetListOfAllAvailableAppointments() : Promise<Array<Appointment>> {
        return axios.get('api/Student/getAppointments')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }
}