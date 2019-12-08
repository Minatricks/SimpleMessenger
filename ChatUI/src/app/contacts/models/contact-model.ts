import { Message } from 'src/app/messages/models/message';

export class ContactModel {
    id: number;
    userName: string;
    isActiveContact: boolean;
    lastMessage: Message;
}
