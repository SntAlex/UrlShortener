import React from 'react';
import {Link} from "react-router-dom";
import classes from "./HeaderLink.module.css";

const HeaderLink = ({children, path, ...props}) => {
    return (
        <Link className={classes.headerLink} to = {path} {...props}>
            <h1 className={classes.headerContent}>
                {children}
            </h1>
        </Link>
    );
};

export default HeaderLink;