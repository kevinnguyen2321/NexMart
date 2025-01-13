import { Route, Routes } from 'react-router-dom';
import { AuthorizedRoute } from './auth/AuthorizedRoute';
import Login from './auth/Login';
import Register from './auth/Register';
import { Home } from './home/Home';
import { Orders } from './orders/Orders';
import { ProductsListAdmin } from './products/ProductsListAdmin';
import { ProductDetails } from './products/ProductDetails';

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
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
