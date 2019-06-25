import { MessageInterface } from '../interfaces/message.interface';

/**
 * Model part of the global error/messaging bus.  This model
 * is the structure of any error information that is
 * pushed through the system - whether client or server
 *
 */
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
