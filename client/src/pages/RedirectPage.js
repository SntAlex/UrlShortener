import React, {useState} from 'react';
import ErrorMessage from "../components/ui/ErrorMessage/ErrorMessage";
import OriginalUrlRedirect from "../components/OriginalUrlRedirect/OriginalUrlRedirect";
import Loader from "../components/ui/Loader/Loader";

const RedirectPage = () => {

    const [error, setError] = useState('')

    const tryRedirect = (error) =>{
        setError(error);
    };

    return (
        <div className='page'>
            <OriginalUrlRedirect errorState={tryRedirect}/>
            {error === '' ? <Loader/> : <ErrorMessage error={error}/>}
        </div>
    );
};

export default RedirectPage;