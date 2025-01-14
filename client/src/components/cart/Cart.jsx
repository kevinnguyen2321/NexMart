import { useEffect, useState } from 'react';
import { useCart } from '../context/useCart';
import './Cart.css';

export const Cart = ({ loggedInUser }) => {
  const [order, setOrder] = useState({
    userProfileId: loggedInUser.id,
    orderProducts: [],
  });
  const { cartItems, removeItemFromCart } = useCart();

  // Helper function to update the cart and order
  const updateOrderProducts = (cartItems) => {
    const orderProducts = [];

    // Iterate over cartItems and adjust the quantity if the product already exists
    cartItems.forEach((item) => {
      const existingProduct = orderProducts.find(
        (op) => op.productId === item.id
      );

      if (existingProduct) {
        existingProduct.quantity += 1; // Increment quantity if product already exists
      } else {
        // Otherwise, add a new product to the order with quantity 1
        orderProducts.push({ productId: item.id, quantity: 1 });
      }
    });

    return orderProducts;
  };

  useEffect(() => {
    // Fetch the products from cartItems stored in localStorage
    const savedCartItems = localStorage.getItem('cartItems');
    if (savedCartItems) {
      const products = JSON.parse(savedCartItems);
      const updatedOrderProducts = updateOrderProducts(products);

      setOrder((prevOrder) => ({
        ...prevOrder,
        orderProducts: updatedOrderProducts,
      }));
    }
  }, []);

  useEffect(() => {
    if (cartItems.length > 0) {
      const updatedOrderProducts = updateOrderProducts(cartItems);

      setOrder((prevOrder) => ({
        ...prevOrder,
        orderProducts: updatedOrderProducts,
      }));
    }
  }, [cartItems]);

  const handleRemoveBtnClick = (id) => {
    removeItemFromCart(id);
  };

  return (
    <div className="cart-wrapper">
      <h1>Your Cart</h1>
      {order?.orderProducts.map((op) => {
        const cartItemsFromLocalStorage = localStorage.getItem('cartItems');
        const cartItems = JSON.parse(cartItemsFromLocalStorage);
        const product = cartItems.find((ci) => ci.id === op.productId);
        const productTotal = product?.price * op.quantity;
        return (
          <div className="order-product" key={op.productId}>
            <p>{product?.name}</p>
            <p>Quantity: {op.quantity}</p>
            {product && <p>Product Total: ${productTotal.toFixed(2)}</p>}
            <button onClick={() => handleRemoveBtnClick(op.productId)}>
              Remove from cart
            </button>
          </div>
        );
      })}
    </div>
  );
};
