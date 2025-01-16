import { useEffect, useState } from 'react';
import { useCart } from '../context/useCart';
import './Cart.css';
import { placeOrder } from '../../managers/orderManager';
import { useNavigate } from 'react-router-dom';

export const Cart = ({ loggedInUser }) => {
  const [order, setOrder] = useState({
    userProfileId: loggedInUser.id,
    orderProductsFromCart: [],
  });
  const { cartItems, removeItemFromCart, clearCart } = useCart();

  const navigate = useNavigate();

  useEffect(() => {
    const updatedOrderProducts = mapCartItemsToOrderProducts(cartItems);
    setOrder((prevOrder) => ({
      ...prevOrder,
      orderProductsFromCart: updatedOrderProducts,
    }));
  }, [cartItems]);

  let orderTotal = 0;

  // Map cartItems to orderProducts structure
  const mapCartItemsToOrderProducts = (cartItems) => {
    const orderProductsMap = {};

    // Aggregate quantity for each product
    cartItems.forEach((item) => {
      orderProductsMap[item.id] = {
        productId: item.id,
        quantity: item.quantity,
      };
    });

    return Object.values(orderProductsMap); // Convert map to array
  };

  // Update local storage and state
  const handleRemoveBtnClick = (id) => {
    removeItemFromCart(id);
  };

  const handlePlaceOrderBtnClick = () => {
    placeOrder(order).then(() => {
      clearCart();
      navigate('/my-orders');
    });
  };

  return (
    <div className="cart-wrapper">
      <h1>My Cart</h1>
      {order?.orderProductsFromCart.map((op) => {
        const product = cartItems.find(
          (cartItem) => cartItem.id === op.productId
        );
        const productTotal = product?.price * op.quantity;
        orderTotal += productTotal;
        return (
          <div className="order-product" key={op.productId}>
            <p>{product?.name}</p>
            <p>Quantity: {op.quantity}</p>
            {product && <p>Product Total: ${productTotal?.toFixed(2)}</p>}
            <button onClick={() => handleRemoveBtnClick(op.productId)}>
              Remove from cart
            </button>
          </div>
        );
      })}
      <div>
        <h2 className="order-total-text">
          Order Total:<span> ${orderTotal.toFixed(2)}</span>
        </h2>
        {order.orderProductsFromCart.length > 0 && (
          <button onClick={handlePlaceOrderBtnClick}>Place Order</button>
        )}
      </div>
    </div>
  );
};
