import React, {useEffect, useState} from 'react';
import axios from "axios";

const RedirectPage = () => {

    const [responseData, setResponseData] = useState();

    async function getOriginalLink(){
        const url = "https://localhost:8001/api/v1/UrlShortener" + window.location.pathname;
        console.log(url);
        const response = await axios.get(url);
        setResponseData(response.data);
        console.log(response.data)
    }

    useEffect(() =>{
        getOriginalLink();

    }, [window.location.pathname])
    return (
        <div>
            {window.location.href = responseData}
        </div>
    );
};

export default RedirectPage;