import { MessageInterface } from '../interfaces/message.interface';

/**
 * Model part of the global error/messaging bus.  This model
 * is the structure of any message information that is
 * pushed through the system - whether success or warnings
 *
 */
export class AppMessage implements MessageInterface {

  private title: string;
  private type: string;
  private message: string;
  private description: string;

  constructor(message: string, type: string = 'success', title: string = '', description: string = '') {
    this.message = message;
    this.type = type;
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
