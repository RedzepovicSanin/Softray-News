import { UserStatus } from '../enums/UserStatus';
import { News } from './news';

export class User {
    id: number;
    firstName: string;
    lastName: string;
    username: string;
    password: string;
    token: string;
    role: string;
    status: UserStatus;
    dateInserted: Date;
    news: News[];
}
