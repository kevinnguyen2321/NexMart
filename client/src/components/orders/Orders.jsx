import { useEffect, useState } from 'react';
import { cancelOrder, getAllOrders } from '../../managers/orderManager';
import './Orders.css';
import { OrderDetails } from './OrderDetails';

export const Orders = ({ loggedInUser }) => {
  const [orders, setOrders] = useState([]);
  const [selectedOrderId, setSelectedOrderId] = useState(null);

  const getAllOrdersAndSetOrders = () => {
    getAllOrders().then((data) => setOrders(data));
  };

  useEffect(() => {
    getAllOrdersAndSetOrders();
  }, []);

  const formatDate = (date) => {
    const jsDate = new Date(date);

    return jsDate.toLocaleString();
  };

  const toggleOrderDetails = (orderId) => {
    // Toggle the details view for the specific order
    if (selectedOrderId === orderId) {
      setSelectedOrderId(null); // Close the details if already open
    } else {
      setSelectedOrderId(orderId); // Open the details for the clicked order
    }
  };

  const handleCancelBtnClick = (orderId) => {
    const userConfirmed = window.confirm(
      'Are you sure you want to cancel this order?'
    );

    if (userConfirmed) {
      cancelOrder(orderId).then(() => getAllOrdersAndSetOrders());
    }
  };

  return (
    <div>
      <div className="orders-wrapper">
        {orders.map((o) => {
          return (
            <div className="order-card" key={o.id}>
              <div className="order-date-text-wrapper">
                <div>Order Id: {o.id}</div>
                <div className="order-date-wrapper">
                  Order Date:{formatDate(o.orderDate)}
                </div>
                <div className="order-total-wrapper">Total:${o.orderTotal}</div>
              </div>
              <div className="order-buttons-wrapper">
                <button onClick={() => toggleOrderDetails(o.id)}>
                  {selectedOrderId === o.id ? 'Close' : 'View'}
                </button>
                <button onClick={() => handleCancelBtnClick(o.id)}>
                  Cancel Order
                </button>
              </div>
              {selectedOrderId === o.id && (
                <OrderDetails orderId={o.id} loggedInUser={loggedInUser} />
              )}
            </div>
          );
        })}
      </div>
    </div>
  );
};
