import React from 'react';
import classes from "./Footer.module.css";

const Footer = () => {
    return (
        <footer className={classes.footer}>
            <h3 className={classes.footerContent}>
                Made by Alex Golikov
            </h3>
        </footer>
    );
};

export default Footer;