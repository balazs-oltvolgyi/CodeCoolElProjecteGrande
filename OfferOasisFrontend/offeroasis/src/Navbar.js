import React, { useState } from "react";
import "../src/Navbar.css"

function Navbar() {
  const [active, setActive] = useState("nav__menu");
  const [icon, setIcon] = useState("nav__toggler");
  const navToggle = () => {
    if (active === "nav__menu") {
      setActive("nav__menu nav__active");
    } else setActive("nav__menu");

    // Icon Toggler
    if (icon === "nav__toggler") {
      setIcon("nav__toggler toggle");
    } else setIcon("nav__toggler");
  };
  return (
    <nav className="nav">
      <a href="#" className="nav__brand">
      OfferOasis
      </a>
      <ul className={active}>
        <li className="nav__item">
          <a href="/home" className="nav__link">
            Home
          </a>
        </li>
        <li className="nav__item">
          <a href="/about" className="nav__link">
            About
          </a>
        </li>
        <li className="nav__item">
          <a href="/products" className="nav__link">
         Endpoints
          </a>
        </li>
        <li className="nav__item">
          <a href="/account" className="nav__link">
           Account
          </a>
        </li>
        <li className="nav__item">
          <a href="/contact" className="nav__link">
            Contact
          </a>
        </li>
        <li className="nav__item">
          <a href="/information" className="nav__link">
          Shipping information
          </a>
        </li>
      </ul>
      <div onClick={navToggle} className={icon}>
        <div className="line1"></div>
        <div className="line2"></div>
        <div className="line3"></div>
      </div>
    </nav>
  );
}

export default Navbar;