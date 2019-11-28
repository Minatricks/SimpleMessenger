export class ContactViewModel {
    friendId: number;
    name: string;
    date: Date;
    text: string;

    constructor(id) {
        this.friendId = id;
    }
}
