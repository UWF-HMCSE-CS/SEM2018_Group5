import { User } from '../../models/User';
import axios from 'axios';
import { Appointment } from '../../models/Appointment';
import { Message } from '../../models/Message';

export default class UserService {

    public static GetListOfUsersWorkedWith(): Promise<Array<User>> {
        return axios.get('api/user/getListOfUsersWorkedWith')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }

    public static GetListOfAppointments(): Promise<Array<Appointment>> {
        return axios.get('api/user')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }

    public static UserLogin(email: string, password:string): Promise<User> {
        return axios.post('api/user/loginUser', {
            Email: email,
            Password: password
        })
        .then(response => {
            return response.data;
        })
        .catch(error => {
            console.log(error);
        })
    }

    public static sendMessage(message: Message): Promise<Message> {
        return axios.post('api/user/sendMessage', {
            ToUserId: message.toUserId,
            MessageBody: message.messageBody
        })
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }
}