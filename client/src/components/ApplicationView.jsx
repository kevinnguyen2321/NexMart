import { Route, Routes } from 'react-router-dom';
import { AuthorizedRoute } from './auth/AuthorizedRoute';
import Login from './auth/Login';
import Register from './auth/Register';
import { Home } from './home/Home';
import { Orders } from './orders/Orders';
import { ProductsListAdmin } from './products/ProductsListAdmin';
import { ProductDetails } from './products/ProductDetails';
import { MyOrders } from './orders/MyOrders';
import { Cart } from './cart/Cart';
import { CategoryListAdmin } from './categories/CategoryListAdmin';
import { Results } from './search/Results';
import { OrderSuccess } from './orders/OrderSuccess';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route index element={<Home loggedInUser={loggedInUser} />} />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />

        <Route
          path="products-list"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={['Admin']}>
              <ProductsListAdmin loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="orders"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={['Admin']}>
              <Orders loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="order-success"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrderSuccess loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="my-orders"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <MyOrders loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="cart"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Cart loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="category-list"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={['Admin']}>
              <CategoryListAdmin loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route path="results" element={<Results />} />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
