import { useEffect, useState } from 'react';
import { CartContext } from './CartContext';

export const CartProvider = ({ children, loggedInUser }) => {
  const [cartItems, setCartItems] = useState([]);

  // useEffect(() => {
  //   if (loggedInUser) {
  //     // Load cart for the logged-in user from localStorage
  //     const savedCartItems = localStorage.getItem(
  //       `cartItems_${loggedInUser.id}`
  //     );
  //     setCartItems(savedCartItems ? JSON.parse(savedCartItems) : []);
  //   } else {
  //     // Clear cart when no user is logged in
  //     setCartItems([]);
  //   }
  // }, [loggedInUser]);

  // const saveCartToLocalStorage = (cart) => {
  //   if (loggedInUser) {
  //     localStorage.setItem(
  //       `cartItems_${loggedInUser.id}`,
  //       JSON.stringify(cart)
  //     );
  //   }
  // };

  useEffect(() => {
    if (loggedInUser) {
      // Load cart for the logged-in user from localStorage
      const savedCartItems = localStorage.getItem(
        `cartItems_${loggedInUser.id}`
      );
      setCartItems(savedCartItems ? JSON.parse(savedCartItems) : []);
    } else {
      // Load guest cart when no user is logged in
      const guestCartItems = localStorage.getItem('cartItems_guest');
      setCartItems(guestCartItems ? JSON.parse(guestCartItems) : []);
    }
  }, [loggedInUser]);

  // Call transferGuestCart after a user logs in
  useEffect(() => {
    if (loggedInUser) {
      transferGuestCart();
    }
  }, [loggedInUser]);

  const saveCartToLocalStorage = (cart) => {
    if (loggedInUser) {
      localStorage.setItem(
        `cartItems_${loggedInUser.id}`,
        JSON.stringify(cart)
      );
    } else {
      localStorage.setItem('cartItems_guest', JSON.stringify(cart));
    }
  };

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

      saveCartToLocalStorage(updatedCartItems);
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

      saveCartToLocalStorage(updatedCartItems);
      return updatedCartItems;
    });
  };

  const transferGuestCart = () => {
    const guestCart = localStorage.getItem('cartItems_guest');
    if (guestCart) {
      const guestCartItems = JSON.parse(guestCart);

      setCartItems((prevCartItems) => {
        // Merge guest cart into the existing user cart
        const mergedCartItems = [...prevCartItems];

        guestCartItems.forEach((guestItem) => {
          const existingItem = mergedCartItems.find(
            (cartItem) => cartItem.id === guestItem.id
          );

          if (existingItem) {
            // If the item already exists, add the quantities
            existingItem.quantity += guestItem.quantity;
          } else {
            // If the item is new, add it to the cart
            mergedCartItems.push(guestItem);
          }
        });

        // Save the merged cart to the user's localStorage
        saveCartToLocalStorage(mergedCartItems);
        return mergedCartItems;
      });

      // Clear the guest cart from localStorage
      localStorage.removeItem('cartItems_guest');
    }
  };

  const getTotalItemsInCart = () => {
    const totalQuantity = cartItems.reduce(
      (sum, product) => sum + product.quantity,
      0
    );

    return totalQuantity;
  };

  // const clearCart = () => {
  //   setCartItems([]);
  //   if (loggedInUser) {
  //     localStorage.removeItem(`cartItems_${loggedInUser.id}`);
  //   }
  // };

  const clearCart = () => {
    setCartItems([]);
    if (loggedInUser) {
      localStorage.removeItem(`cartItems_${loggedInUser.id}`);
    } else {
      localStorage.removeItem('cartItems_guest');
    }
  };

  return (
    <CartContext.Provider
      value={{
        cartItems,
        addItemToCart,
        removeItemFromCart,
        getTotalItemsInCart,
        clearCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};
