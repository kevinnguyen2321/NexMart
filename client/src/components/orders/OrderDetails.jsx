import { useEffect, useState } from 'react';
import { getOrderById } from '../../managers/orderManager';
import './Orders.css';

export const OrderDetails = ({ orderId, loggedInUser }) => {
  const [orderDetails, setOrderDetails] = useState(null);

  useEffect(() => {
    getOrderById(orderId).then((data) => setOrderDetails(data));
  }, [orderId]);

  if (!orderDetails) {
    return <div>Loading...</div>;
  }

  return (
    <div className="order-details">
      <h4>Order Details (Order {orderId})</h4>
      {loggedInUser?.roles.includes('Admin') && (
        <p>Customer Name: {orderDetails.userProfile.fullName}</p>
      )}
      <ul className="order-details-product-list">
        {orderDetails.orderProducts.map((product) => (
          <li className="order-list-item" key={product.id}>
            {product.product.name} - Quantity: {product.quantity} - ($
            {product.productTotal})
            <img className="order-image" src={product.product.imageUrl} />
          </li>
        ))}
      </ul>
    </div>
  );
};
