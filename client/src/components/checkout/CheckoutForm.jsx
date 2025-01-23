import { useStripe, useElements, CardElement } from '@stripe/react-stripe-js';
import { useState } from 'react';
import { placeOrder } from '../../managers/orderManager';
import { useNavigate } from 'react-router-dom';
import { useCart } from '../context/useCart';
import './CheckoutForm.css';

const CheckoutForm = ({ clientSecret, order, loggedInUser }) => {
  const stripe = useStripe();
  const elements = useElements();
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState('');
  const { clearCart } = useCart();
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);

    // Get a reference to the card element
    const cardElement = elements.getElement(CardElement);

    // Confirm the payment using the client secret
    const { error, paymentIntent } = await stripe.confirmCardPayment(
      clientSecret,
      {
        payment_method: {
          card: cardElement,
        },
      }
    );

    if (error) {
      // Handle any error
      console.error('Payment failed: ', error);
      setLoading(false);
      setMessage(error.message);
    } else if (paymentIntent.status === 'succeeded') {
      // Payment was successful
      console.log('Payment successful!');
      // Proceed with placing the order and clearing the cart
      placeOrder(order);
      clearCart();
      navigate('/order-success');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="card-element-container">
        <CardElement />
        {message && <div className="error-message">{message}</div>}
        <button
          className="place-order-btn"
          type="submit"
          disabled={!stripe || loading}
        >
          {loading ? 'Processing...' : 'Pay Now'}
        </button>
      </div>
    </form>
  );
};

export default CheckoutForm;
