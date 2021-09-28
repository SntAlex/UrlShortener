import React, {useEffect, useState} from 'react';
import axios from "axios";

const RedirectPage = () => {

    const [responseData, setResponseData] = useState();
    const [error, setError] = useState('')

    async function getOriginalLink(){
        try {
            const url = "https://localhost:8001/api/v1/UrlShortener" + window.location.pathname;
            const response = await axios.get(url);

            if(response.data.error !== undefined){
                setError(response.data.error);
            } else {
                setResponseData(response.data);
                setError('');
            }
        } catch (error){
            setError(error.message);
        }
    }


    useEffect(() =>{
        getOriginalLink();
    }, [window.location.pathname])

    function redirect(){
        if(responseData !== undefined){
            window.location.href = responseData
        }
    }

    return (
        <h1>
            {error === '' ? redirect() : error}
        </h1>
    );
};

export default RedirectPage;