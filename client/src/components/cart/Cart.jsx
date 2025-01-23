import { useEffect, useState } from 'react';
import { useCart } from '../context/useCart';
import './Cart.css';
import { placeOrder } from '../../managers/orderManager';
import { useNavigate } from 'react-router-dom';
import deleteIcon from '../../assets/delete.png';
import { loadStripe } from '@stripe/stripe-js'; //TEST Stripe API
import CheckoutForm from '../checkout/CheckoutForm';

export const Cart = ({ loggedInUser }) => {
  const [order, setOrder] = useState({
    userProfileId: loggedInUser.id,
    orderProductsFromCart: [],
  });
  const [clientSecret, setClientSecret] = useState(''); //TEST Stripe API//
  const { cartItems, removeItemFromCart, clearCart } = useCart();

  const navigate = useNavigate();
  //TEST Stripe API START//
  const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLIC_KEY);
  //TEST Stripe API END//

  // Update order state when cartItems change
  useEffect(() => {
    const updatedOrderProducts = mapCartItemsToOrderProducts(cartItems);
    setOrder((prevOrder) => ({
      ...prevOrder,
      orderProductsFromCart: updatedOrderProducts,
    }));
  }, [cartItems]);

  const orderTotalInCents = cartItems.reduce(
    (total, item) => total + Math.round(item.price * item.quantity * 100), // Round to avoid floating-point precision issues
    0
  );

  // Map cartItems to orderProducts structure
  const mapCartItemsToOrderProducts = (cartItems) => {
    const orderProductsMap = {};

    cartItems.forEach((item) => {
      orderProductsMap[item.id] = {
        productId: item.id,
        quantity: item.quantity,
      };
    });

    return Object.values(orderProductsMap); // Convert map to array
  };

  // Remove product from cart
  const handleRemoveBtnClick = (id) => {
    removeItemFromCart(id);
  };

  // Create PaymentIntent and get clientSecret
  useEffect(() => {
    const createPaymentIntent = async () => {
      const response = await fetch('/api/payment/create-intent', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ AmountInCents: orderTotalInCents }), // Set order total here
      });
      const data = await response.json();
      setClientSecret(data.clientSecret);
    };

    if (orderTotalInCents > 0) {
      createPaymentIntent();
    }
  }, [cartItems, orderTotalInCents]);

  // Calculate total order price
  let orderTotal = 0;
  order?.orderProductsFromCart.forEach((op) => {
    const product = cartItems.find((cartItem) => cartItem.id === op.productId);
    const productTotal = product?.price * op.quantity;
    orderTotal += productTotal;
  });

  return (
    <div className="cart-wrapper">
      <h1>My Cart</h1>
      {order?.orderProductsFromCart.map((op) => {
        const product = cartItems.find(
          (cartItem) => cartItem.id === op.productId
        );
        const productTotal = product?.price * op.quantity;
        return (
          <div className="order-product" key={op.productId}>
            <p>{product?.name}</p>
            <div>
              <img className="my-cart-product-img" src={product?.imageUrl} />
              <button
                className="remove-product-cart-btn"
                onClick={() => handleRemoveBtnClick(op.productId)}
              >
                <img
                  className="remove-product-cart-icon"
                  src={deleteIcon}
                  alt="delete"
                />
              </button>
            </div>
            <p>Quantity: {op.quantity}</p>
            {product && <p>Product Total: ${productTotal?.toFixed(2)}</p>}
          </div>
        );
      })}
      <div>
        <h2 className="order-total-text">
          Order Total: <span> ${orderTotal.toFixed(2)}</span>
        </h2>
      </div>
      {clientSecret && order.orderProductsFromCart.length > 0 && (
        <CheckoutForm
          loggedInUser={loggedInUser}
          clientSecret={clientSecret}
          order={order}
        />
      )}
    </div>
  );
};
