import React, {useState} from 'react';
import classes from "./UrlShortenerForm.module.css";
import ShortUrlLinker from "../ShortUrlLinker/ShortUrlLinker";
import ErrorMessage from "../UI/ErrorMessage/ErrorMessage";
import Loader from "../UI/Loader/Loader";
import UrlMinificationService from "../../API/UrlMinificationService";
import {useFetching} from "../../hooks/useFetching";

const UrlShortenerForm = () => {
    const [input, setInput] = useState('');
    const [shortUrl, setShortUrl] = useState('');
    const [createShortUrl, isLoading, error] = useFetching(async () =>{
        const response = await UrlMinificationService.createShortUrl(input);
        setShortUrl(response.data);
    })

    async function handleClick(event) {
        event.preventDefault();
        setShortUrl('');
        await createShortUrl();
    }

    return (isLoading ?
            <Loader/> :
            <form className={classes.urlShortenerForm}>
                <input className={classes.originalUrlInput} name="Original url" value={input} onChange={event => setInput(event.target.value)}/>
                <input className={classes.shortUrlButton} type="submit" value="Get short Url!" onClick={handleClick}/>
                <ShortUrlLinker urlPath={shortUrl} />
                <ErrorMessage error={error}/>
            </form>
    );
};

export default UrlShortenerForm;