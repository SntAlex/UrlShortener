import React, {useState} from 'react';
import axios from "axios";
import {Link} from "react-router-dom";

const UrlShortenerForm = () => {
    const [input, setInput] = useState('');
    const [shortUrl, setShortUrl] = useState('');

    async function handleClick(event) {
        event.preventDefault();
        const response = await axios.post('https://localhost:8001/api/v1/UrlShortener', {url: input});
        setShortUrl(response.data);
    }

    return (
        <form>
            <input name="Original url" value={input} onChange={event => setInput(event.target.value)}/>
            <input type="submit" value="Get short Url!"  onClick={handleClick}/>
            <br/>
            <Link to={shortUrl}>
                {window.location.hostname + '/' + shortUrl}
            </Link>
        </form>
    );
};

export default UrlShortenerForm;