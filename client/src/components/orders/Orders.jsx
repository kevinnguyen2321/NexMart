import { useEffect, useState } from 'react';
import { getAllOrders } from '../../managers/orderManager';
import './Orders.css';

export const Orders = () => {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    getAllOrders().then((data) => setOrders(data));
  }, []);

  const formatDate = (date) => {
    const jsDate = new Date(date);

    return jsDate.toLocaleString();
  };

  return (
    <div>
      <div className="orders-wrapper">
        {orders.map((o) => {
          return (
            <div className="order-card" key={o.id}>
              <div>Order Id: {o.id}</div>
              <div className="order-date-wrapper">
                Order Date:{formatDate(o.orderDate)}
              </div>
              <button>View</button>
              <button>Cancel Order</button>
            </div>
          );
        })}
      </div>
    </div>
  );
};
