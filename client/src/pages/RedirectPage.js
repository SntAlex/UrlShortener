import React, {useEffect, useState} from 'react';
import ErrorMessage from "../components/UI/ErrorMessage/ErrorMessage";
import Loader from "../components/UI/Loader/Loader";
import {useFetching} from "../hooks/useFetching";
import UrlMinificationService from "../API/UrlMinificationService";

const RedirectPage = () => {
    const [originalUrl, setOriginalUrl] = useState(undefined);
    const [getOriginalUrl, isLoading, error] = useFetching(async () => {
        const response = await UrlMinificationService.getOriginalUrl();
        setOriginalUrl(response.data);
    })

    useEffect(() =>{
        getOriginalUrl().then(() => redirect());
    }, [originalUrl])

    function redirect(){
        if(originalUrl !== undefined){
            window.location.href = originalUrl
        }
    }

    return (
        <div className='page'>
            {isLoading || error === '' ?
                <Loader/> :
                <ErrorMessage error={error}/>
            }
        </div>
    );
};

export default RedirectPage;