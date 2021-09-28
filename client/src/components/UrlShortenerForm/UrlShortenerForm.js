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
            try {
                if(error.response.data.errors !== undefined) {
                    setError(JSON.stringify(error.response.data.errors, null, 4));
                } else if(error.response.data.message !== undefined && error.response.data.statusCode !== undefined){
                    setError(error.response.data.message + ' Status code: ' + error.response.data.statusCode);
                }
            } catch (error2){
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
            <h4>{error !== '' ? error : ''}</h4>
        </form>
    );
};

export default UrlShortenerForm;