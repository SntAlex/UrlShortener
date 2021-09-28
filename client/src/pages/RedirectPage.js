import React, {useEffect, useState} from 'react';
import axios from "axios";

const RedirectPage = () => {

    const [responseData, setResponseData] = useState();

    async function getOriginalLink(){
        const url = "https://localhost:8001/api/v1/UrlShortener" + window.location.pathname;
        const response = await axios.get(url);
        setResponseData(response.data);
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

export default RedirectPage;