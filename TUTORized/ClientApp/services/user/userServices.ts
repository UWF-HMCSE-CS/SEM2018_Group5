import { User } from '../../models/User';
import axios from 'axios';
import { Appointment } from '../../models/Appointment';

export default class displayListOfAppointments {

    public static getListOfAppointments(): Promise<Array<Appointment>> {
        return axios.get('api/user')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }
}