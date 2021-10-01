import React, {useEffect, useState} from 'react';
import {Link} from "react-router-dom";
import classes from "./ShortUrlLinker.module.css";
import {getShortUrl} from "../../utils/UrlUtils";
import ErrorMessage from "../UI/ErrorMessage/ErrorMessage";

const ShortUrlLinker = ({urlPath, error}) => {
    const [shortUrl, setShortUrl] = useState('');

    useEffect(() =>{
        setShortUrl(urlPath==='' ?
            '' :
            getShortUrl(urlPath));
    }, [urlPath])

    return error === '' ?
            <Link className={classes.shortUrl} to={urlPath}>
                {shortUrl}
            </Link> :
            <ErrorMessage error={error}/>
};

export default ShortUrlLinker;