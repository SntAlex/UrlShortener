import React, {useState} from 'react';
import UrlShortenerForm from "../components/UrlShortenerForm/UrlShortenerForm";
import {useFetching} from "../hooks/useFetching";
import UrlMinificationService from "../API/UrlMinificationService";
import Loader from "../components/UI/Loader/Loader";
import ShortUrlLinker from "../components/ShortUrlLinker/ShortUrlLinker";
import classes from "./HomePage.module.css";

const HomePage = () => {
    const [createShortUrl, isLoading, error] = useFetching(async (input) =>{
        const response = await UrlMinificationService.createShortUrl(input);
        setShortUrl(response.data);
    })
    const [shortUrl, setShortUrl] = useState('');

    const setUrl = (url) => {
        setShortUrl(url);
    }

    return (
        <div className='page'>
            {isLoading ?
                <Loader/> :
                <div className={classes.urlShorterner}>
                    <UrlShortenerForm setUrl={setUrl} createShortUrl={createShortUrl}/>
                    <ShortUrlLinker urlPath={shortUrl} error={error}/>
                </div>
            }
        </div>
    );
};

export default HomePage;