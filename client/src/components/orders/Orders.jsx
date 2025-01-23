import { useEffect, useState } from 'react';
import {
  cancelOrder,
  getAllOrders,
  getCanceledOrders,
} from '../../managers/orderManager';
import './Orders.css';
import { OrderDetails } from './OrderDetails';
import dropdownArrowIcon from '../../assets/dropdown.png';

export const Orders = ({ loggedInUser }) => {
  const [orders, setOrders] = useState([]);
  const [canceledOrders, setCanceledOrders] = useState([]);
  const [selectedOrderId, setSelectedOrderId] = useState(null);
  const [filteredOrders, setFilteredOrders] = useState([]);
  const [isSortDropdownOpen, setIsSortDropdownOpen] = useState(false);
  const [sortOption, setSortOption] = useState('');
  const [dateRange, setDateRange] = useState({ start: '', end: '' });
  const [isViewingCanceledOrders, setIsViewingCanceledOrders] = useState(false);

  const getAllOrdersAndSetOrders = () => {
    getAllOrders().then((data) => setOrders(data));
  };

  useEffect(() => {
    getAllOrdersAndSetOrders();
  }, []);

  useEffect(() => {
    getCanceledOrders().then((data) => setCanceledOrders(data));
  }, []);

  useEffect(() => {
    setFilteredOrders(orders);
  }, [orders]);

  useEffect(() => {
    let filtered = isViewingCanceledOrders ? [...canceledOrders] : [...orders];

    if (dateRange.start && dateRange.end) {
      const startDateUTC = new Date(`${dateRange.start}T00:00:00Z`);
      const endDateUTC = new Date(`${dateRange.end}T23:59:59Z`);

      filtered = filtered.filter((order) => {
        const orderDate = new Date(order.orderDate);

        return orderDate >= startDateUTC && orderDate <= endDateUTC;
      });
    }

    if (sortOption === 'latest') {
      filtered.sort((a, b) => new Date(b.orderDate) - new Date(a.orderDate));
    } else if (sortOption === 'oldest') {
      filtered.sort((a, b) => new Date(a.orderDate) - new Date(b.orderDate));
    }

    setFilteredOrders(filtered);
  }, [sortOption, orders, dateRange.start, dateRange.end]);

  const formatDate = (date) => {
    const jsDate = new Date(date);
    // Manually subtract 6 hours for CST (UTC - 6)
    jsDate.setHours(jsDate.getHours() + 6);
    const formattedCST = jsDate.toLocaleString('en-US', {
      hour12: false, // Use 24-hour format
      year: 'numeric',
      month: 'numeric',
      day: 'numeric',
      hour: 'numeric',
      minute: 'numeric',
      second: 'numeric',
    });
    return formattedCST;
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
      cancelOrder(orderId).then(() => {
        getAllOrdersAndSetOrders();
        getCanceledOrders().then((data) => setCanceledOrders(data));
      });
    }
  };

  const toggleSortDropdown = () => {
    setIsSortDropdownOpen((prev) => !prev);
  };

  const handleSortOptionChange = (option) => {
    setSortOption(option);
    setIsSortDropdownOpen(false); // Close dropdown after selection
  };

  const handleDateRangeChange = (type, value) => {
    setDateRange((prev) => ({ ...prev, [type]: value }));
  };

  const applyDateRangeFilter = () => {
    if (dateRange.start && dateRange.end) {
      const startDate = new Date(dateRange.start);
      const endDate = new Date(dateRange.end);

      const filtered = orders.filter((order) => {
        const orderDate = new Date(order.orderDate);
        return orderDate >= startDate && orderDate <= endDate;
      });

      setFilteredOrders(filtered);
    } else {
      alert('Please select both a start and end date.');
    }
  };

  const handleResetBtnClick = () => {
    setFilteredOrders(orders);
    setDateRange({ start: '', end: '' });
    setSortOption('');
    setIsViewingCanceledOrders(false);
  };

  const handleViewCanceledOrdersClick = () => {
    setIsViewingCanceledOrders(true);
    setFilteredOrders(canceledOrders);
  };

  return (
    <div className="all-order-main-wrapper">
      <div className="sort-order-wrapper">
        <p onClick={toggleSortDropdown} className="sort-toggle">
          Sort By
          <img
            className="drop-down-icon"
            src={dropdownArrowIcon}
            alt="Sort Arrow"
          />
        </p>
        {isSortDropdownOpen && (
          <div className="orders-dropdown">
            <button onClick={() => handleSortOptionChange('latest')}>
              Most Recent
            </button>
            <button onClick={() => handleSortOptionChange('oldest')}>
              Oldest
            </button>
          </div>
        )}
        <div className="date-range-filter">
          <div className="date-input-wrapper">
            <label>
              From:
              <input
                type="date"
                onChange={(e) => handleDateRangeChange('start', e.target.value)}
                value={dateRange.start}
              />
            </label>
          </div>
          <div className="date-input-wrapper">
            <label>
              To:
              <input
                type="date"
                onChange={(e) => handleDateRangeChange('end', e.target.value)}
                value={dateRange.end}
              />
            </label>
          </div>
          <div className="filter-buttons-wrapper">
            <button className="reset-button" onClick={handleResetBtnClick}>
              Reset
            </button>
            <button className="apply-button" onClick={applyDateRangeFilter}>
              Apply
            </button>
          </div>
        </div>
      </div>
      <div className="orders-admin-list-wrapper">
        <h2 className="all-orders-header">Orders</h2>
        <div className="canceled-orders-btn-wrapper">
          <button
            onClick={handleViewCanceledOrdersClick}
            className="view-canceled-order-btn"
          >
            View Canceled Orders
          </button>
        </div>

        <div className="orders-wrapper">
          {filteredOrders.length === 0 && (
            <p className="no-orders-text">No orders found...</p>
          )}
          {filteredOrders.map((o) => {
            return (
              <div className="order-card" key={o.id}>
                <div className="order-date-text-wrapper">
                  <div>Order Id: {o.id}</div>
                  <div className="order-date-wrapper">
                    Order Date:{formatDate(o.orderDate)}
                  </div>
                  <div className="order-total-wrapper">
                    Total:${o.orderTotal}
                  </div>
                </div>
                <div className="order-buttons-wrapper">
                  <button
                    className={
                      selectedOrderId === o.id
                        ? 'cancel-order-btn'
                        : 'view-order-btn'
                    }
                    onClick={() => toggleOrderDetails(o.id)}
                  >
                    {selectedOrderId === o.id ? 'Close' : 'View'}
                  </button>
                  {!o.isCanceled && (
                    <button
                      className="cancel-order-btn"
                      onClick={() => handleCancelBtnClick(o.id)}
                    >
                      Cancel Order
                    </button>
                  )}
                </div>
                <div
                  className={`order-details-wrapper ${
                    selectedOrderId === o.id ? 'open' : ''
                  }`}
                >
                  {selectedOrderId === o.id && (
                    <OrderDetails orderId={o.id} loggedInUser={loggedInUser} />
                  )}
                </div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};
