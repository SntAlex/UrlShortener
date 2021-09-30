import React, {useState} from 'react';
import axios from "axios";
import classes from "./UrlShortenerForm.module.css";
import ShortUrlLinker from "../ShortUrlLinker/ShortUrlLinker";
import ErrorMessage from "../ui/ErrorMessage/ErrorMessage";
import Loader from "../ui/Loader/Loader";

const UrlShortenerForm = ({operation}) => {
    const [input, setInput] = useState('');
    const [shortUrl, setShortUrl] = useState('');
    const [error, setError] = useState('');
    const [isOperation, setIsOperation] = useState(false);

    async function handleClick(event) {
        event.preventDefault();
        try {
            setIsOperation(true);
            const response = await axios.post('https://localhost:8001/api/v1/UrlShortener', {url: input})
            setShortUrl(response.data);
            setError('');
            setIsOperation(false);
        } catch (error){
            setIsOperation(false);
            try {
                if(error.response.data.message !== undefined && error.response.data.statusCode !== undefined){
                    setError(error.response.data.message + ' Status code: ' + error.response.data.statusCode);
                }
            } catch (error2){
                setError(error.message);
            }
        }
    }

    return (isOperation ?
            <Loader/> :
            <form className={classes.urlShortenerForm}>
                <input className={classes.originalUrlInput} name="Original url" value={input} onChange={event => setInput(event.target.value)}/>
                <input className={classes.shortUrlButton} type="submit" value="Get short Url!" onClick={handleClick}/>
                <ShortUrlLinker urlPath={shortUrl} />
                <ErrorMessage error={error}/>
            </form>
    );
};

export default UrlShortenerForm;