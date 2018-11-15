import { User } from '../../models/User';
import axios from 'axios';
import { Message } from '../../models/Message';

export default class UserService {

    public static GetListOfMessages(): Promise<Array<Message>> {
        return axios.get('api/chat/getListOfMessages')
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
}