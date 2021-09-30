import React, {useEffect, useState} from 'react';
import axios from "axios";

const OriginalUrlRedirect = ({errorState}) => {
    const [responseData, setResponseData] = useState();

    async function getOriginalLink(){
        try {
            const response = await axios.get("https://localhost:8001/api/v1/UrlShortener/shortUrl?ShortUrlPath=" + (window.location.pathname).replace('/', ''));
            setResponseData(response.data);
            errorState('');

        } catch (error){
            try {
                errorState(error.response.data.message + ' Status code: ' + error.response.data.statusCode);
            } catch (error2) {
                errorState(error.message);
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
        <div>
            {redirect()}
        </div>
    );
};

export default OriginalUrlRedirect;