import React from 'react';
import classes from "./Header.module.css";
import HeaderLink from "../ui/HeaderLink/HeaderLink";

const Header = () => {
    return (
        <header className={classes.header}>
            <HeaderLink path={'/'}>
                Minification Service
            </HeaderLink>
        </header>
    );
};

export default Header;