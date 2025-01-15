import { useState } from 'react';
import { CartContext } from './CartContext';

export const CartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState(() => {
    // Retrieve cart items from localStorage on initial load
    const savedCartItems = localStorage.getItem('cartItems');
    return savedCartItems ? JSON.parse(savedCartItems) : [];
  });

  const addItemToCart = (item) => {
    setCartItems((prev) => {
      const updatedCartItems = [...prev];
      const existingItem = updatedCartItems.find(
        (cartItem) => cartItem.id === item.id
      );

      if (existingItem) {
        // Increment quantity if item already exists
        existingItem.quantity += 1;
      } else {
        // Add new item with quantity of 1
        updatedCartItems.push({ ...item, quantity: 1 });
      }

      // Save updated cartItems to localStorage
      localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
      return updatedCartItems;
    });
  };

  const removeItemFromCart = (itemId) => {
    setCartItems((prev) => {
      const updatedCartItems = prev
        .map((item) => {
          if (item.id === itemId) {
            // Decrement quantity if more than 1 exists
            return { ...item, quantity: item.quantity - 1 };
          }
          return item;
        })
        .filter((item) => item.quantity > 0); // Remove items with quantity 0

      // Save updated cartItems to localStorage
      localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
      return updatedCartItems;
    });
  };

  const getTotalItemsInCart = () => {
    const totalQuantity = cartItems.reduce(
      (sum, product) => sum + product.quantity,
      0
    );

    return totalQuantity;
  };

  return (
    <CartContext.Provider
      value={{
        cartItems,
        addItemToCart,
        removeItemFromCart,
        getTotalItemsInCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};
