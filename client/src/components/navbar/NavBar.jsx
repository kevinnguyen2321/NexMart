import { useState } from 'react';
import { NavLink as RRNavLink, useNavigate } from 'react-router-dom';
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
import { useContext } from 'react';
import SearchContext from '../context/SearchContextComp';
import searchIcon from '../../assets/search.png';
import cartIcon from '../../assets/cart.png';

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const { getTotalItemsInCart } = useCart();
  const { keyword, handleUserSearchTypeOnChange } = useContext(SearchContext);

  const navigate = useNavigate();

  const handleSearchBtnClick = () => {
    navigate('/results');
  };

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
        <div className="left-side-wrapper">
          <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
            NexMart
          </NavbarBrand>
          <div className="search-bar-wrapper">
            <input
              type="search"
              placeholder="Search NexMart"
              onChange={handleUserSearchTypeOnChange}
            />
            <button className="search-button" onClick={handleSearchBtnClick}>
              <img src={searchIcon} alt="Search" className="search-icon" />
            </button>
          </div>
        </div>
        <div className="right-side-wrapper">
          <div className="cart-link-wrapper">
            {loggedInUser ? (
              <>
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
                        <NavItem>
                          <NavLink
                            className="categories-link"
                            tag={RRNavLink}
                            to="/category-list"
                          >
                            Categories
                          </NavLink>
                        </NavItem>
                      </>
                    )}
                    {loggedInUser && !loggedInUser.roles.includes('Admin') && (
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
              </>
            ) : (
              <Nav navbar>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">
                    <Button color="primary">Login</Button>
                  </NavLink>
                </NavItem>
              </Nav>
            )}
            <NavItem>
              <NavLink className="cart-link" tag={RRNavLink} to="/cart">
                <img src={cartIcon} />
                <p className="cart-item-total">({getTotalItemsInCart()})</p>
              </NavLink>
            </NavItem>
          </div>
        </div>
      </Navbar>
    </div>
  );
}
