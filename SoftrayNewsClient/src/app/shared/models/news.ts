import { NewsStatus } from '../enums/NewsStatus';
import { User } from './user';

export class News {
    id: number;
    title: string;
    text: string;
    status: NewsStatus;
    dateInserted: Date;
    userCreated: User;
}