import React, {useState} from 'react';
import axios from "axios";
import {Link} from "react-router-dom";

const UrlShortenerForm = () => {
    const [input, setInput] = useState('');
    const [shortUrl, setShortUrl] = useState('');
    const [error, setError] = useState('');

    async function handleClick(event) {
        event.preventDefault();
        try {
            const response = await axios.post('https://localhost:8001/api/v1/UrlShortener', {url: input})
            setShortUrl(response.data);
            setError('');

        } catch (error){
            if(error.response.data.errors !== undefined) {
                setError(JSON.stringify(error.response.data.errors, null, 4));
            } else if(error.response.data.message !== undefined && error.response.data.statusCode !== undefined){
                setError(error.response.data.message + '\n' + 'Status code: ' + error.response.data.statusCode);
            } else {
                setError(error.message);
            }
        }
    }

    return (
        <form>
            <input name="Original url" value={input} onChange={event => setInput(event.target.value)}/>
            <input type="submit" value="Get short Url!"  onClick={handleClick}/>
            <br/>
            <Link to={shortUrl}>
                {shortUrl === '' ? '' : window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/' + shortUrl}
            </Link>
            <h1>{error !== '' ? error : ''}</h1>
        </form>
    );
};

export default UrlShortenerForm;