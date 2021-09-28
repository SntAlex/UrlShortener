import React, {useEffect, useState} from 'react';
import axios from "axios";

const RedirectPage = () => {

    const [responseData, setResponseData] = useState();
    const [error, setError] = useState('')

    async function getOriginalLink(){
        try {
            const url = "https://localhost:8001/api/v1/UrlShortener" + window.location.pathname;
            const response = await axios.get(url);
            setResponseData(response.data);
            setError('');

        } catch (error){
            if(error.response.data.message !== undefined && error.response.data.statusCode !== undefined){
                setError(error.response.data.message + '\n' + 'Status code: ' + error.response.data.statusCode);
            } else {
                setError(error.message);
            }
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