
/**
 * Part of the global message bus that allows notifications
 * to be presented to the user from all parts of the
 * application
 *
 */
export interface MessageInterface {

  getMessage(): string;
  getType(): string;
  getDescription(): string;
  getTitle(): string;
}
