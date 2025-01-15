import { useState } from 'react';
import { NavLink as RRNavLink } from 'react-router-dom';
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from 'reactstrap';
import { logout } from '../../managers/authManager';
import './NavBar.css';
import { useCart } from '../context/useCart';

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const { getTotalItemsInCart } = useCart();

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar
        className="main-navbar-wrapper"
        color="primary"
        light
        fixed="true"
        expand="lg"
      >
        <div className="next-mart-main-text-wrapper">
          <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
            NexMart
          </NavbarBrand>
        </div>
        <div className="cart-link-wrapper">
          <NavItem>
            <NavLink className="cart-link" tag={RRNavLink} to="/cart">
              Cart({getTotalItemsInCart()})
            </NavLink>
          </NavItem>
        </div>

        {loggedInUser ? (
          <div className="nav-bar-links-wrapper">
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                {loggedInUser?.roles.includes('Admin') && (
                  <>
                    <NavItem>
                      <NavLink
                        className="orders-link"
                        tag={RRNavLink}
                        to="/orders"
                      >
                        Orders
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        className="products-link"
                        tag={RRNavLink}
                        to="/products-list"
                      >
                        Products
                      </NavLink>
                    </NavItem>
                  </>
                )}
                {loggedInUser && loggedInUser.roles.includes('Customer') && (
                  <>
                    <NavItem>
                      <NavLink
                        className="my-orders-link"
                        tag={RRNavLink}
                        to="/my-orders"
                      >
                        My Orders
                      </NavLink>
                    </NavItem>
                  </>
                )}
              </Nav>
            </Collapse>
            <Button
              color="primary"
              onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                  setLoggedInUser(null);
                  setOpen(false);
                });
              }}
            >
              Logout
            </Button>
          </div>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
