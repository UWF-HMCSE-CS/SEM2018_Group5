import { Appointment } from '../../models/Appointment';
import axios from 'axios';

export default class Calendar {

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