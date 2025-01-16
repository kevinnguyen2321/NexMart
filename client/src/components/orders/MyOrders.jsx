import { useEffect, useState } from 'react';
import { cancelOrder, getAllOrders } from '../../managers/orderManager';
import { OrderDetails } from './OrderDetails';
import './MyOrders.css';

export const MyOrders = ({ loggedInUser }) => {
  const [myOrders, setMyOrders] = useState([]);
  const [selectedOrderId, setSelectedOrderId] = useState(null);

  const getMyOdersAndSetMyOrders = () =>
    getAllOrders(loggedInUser.id).then((data) => setMyOrders(data));

  useEffect(() => {
    getMyOdersAndSetMyOrders();
  }, [loggedInUser]);

  const formatDate = (date) => {
    const jsDate = new Date(date);

    return jsDate.toLocaleDateString();
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
      cancelOrder(orderId).then(() => getMyOdersAndSetMyOrders());
    }
  };

  return (
    <div>
      <div className="orders-wrapper">
        {myOrders.map((o) => {
          return (
            <div className="order-card" key={o.id}>
              <div className="order-date-text-wrapper">
                {o.isCanceled && <div>(Order Canceled)</div>}
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
                {!o.isCanceled && (
                  <button onClick={() => handleCancelBtnClick(o.id)}>
                    Cancel Order
                  </button>
                )}
              </div>
              {selectedOrderId === o.id && <OrderDetails orderId={o.id} />}
            </div>
          );
        })}
      </div>
    </div>
  );
};
