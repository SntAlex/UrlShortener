import React, {useState} from 'react';
import classes from "./UrlShortenerForm.module.css";
import Input from "../UI/Input/Input";

const UrlShortenerForm = ({setUrl, createShortUrl}) => {
    const [input, setInput] = useState('');

    async function handleClick(event) {
        event.preventDefault();
        setUrl('')
        await createShortUrl(input);
    }

    return (
            <form className={classes.urlShortenerForm}>
                <Input name="Original url" value={input} onChange={event => setInput(event.target.value)}/>
                <Input type="submit" value="Get short Url!" onClick={handleClick}/>
            </form>
    );
};

export default UrlShortenerForm;