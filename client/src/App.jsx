import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { tryGetLoggedInUser } from './managers/authManager';
import { Spinner } from 'reactstrap';
import NavBar from './components/navbar/NavBar';
import ApplicationViews from './components/ApplicationView';
import { CartProvider } from './components/context/CartProvider';
import { SearchContextComp } from './components/context/SearchContextComp';
import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLIC_KEY);

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <Elements stripe={stripePromise}>
        <CartProvider loggedInUser={loggedInUser}>
          <SearchContextComp>
            <NavBar
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
            <ApplicationViews
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
          </SearchContextComp>
        </CartProvider>
      </Elements>
    </>
  );
}

export default App;
