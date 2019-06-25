import { MessageInterface } from '../interfaces/message.interface';

export class AppError implements MessageInterface {

  private title: string;
  private type: string;
  private message: string;
  private description: string;

  constructor(message: string, type: string, title: string = 'Error', description: string = '') {
    this.message = message;
    this.type = 'danger';
    this.title = title;
    this.description = description;
  }

  getMessage(): string {
    return this.message;
  }

  getType(): string {
    return this.type;
  }

  getTitle(): string {
    return this.title;
  }

  getDescription(): string {
    return this.description;
  }
}
