import { Link } from 'react-router-dom';
import './OrderSuccess.css';

export const OrderSuccess = ({ loggedInUser }) => {
  // Generate a random 8-digit order confirmation number
  const generateConfirmationNumber = () => {
    return Math.floor(10000000 + Math.random() * 90000000); // Random number between 10000000 and 99999999
  };

  const confirmationNumber = generateConfirmationNumber();

  return (
    <div className="order-success-wrapper">
      <h1>Order Confirmed!</h1>
      <p>Your order has been placed successfully.</p>
      <p className="confirmation-number">
        Confirmation Number: <span>{confirmationNumber}</span>
      </p>
      <div className="navigation-links">
        <Link
          to={loggedInUser.roles.includes('Admin') ? '/orders' : '/my-orders'}
          className="order-success-link"
        >
          {loggedInUser.roles.includes('Admin')
            ? 'Return to All Orders'
            : 'Return to My Orders'}
        </Link>
        <Link to="/" className="order-success-link">
          Return to Homepage
        </Link>
      </div>
    </div>
  );
};
