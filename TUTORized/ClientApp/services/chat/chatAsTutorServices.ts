import axios from 'axios';
import { Message } from '../../models/Message';

export default class ChatAsTutorServices {

    public static GetListOfMessages(): Promise<Array<Message>> {
        return axios.get('api/chatAsTutor/getListOfMessages')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
            })
    }



}