import React, {useState} from 'react';
import UrlShortenerForm from "../components/UrlShortenerForm/UrlShortenerForm";

const HomePage = () => {

    return (
        <div className='page'>
            <UrlShortenerForm />
        </div>
    );
};

export default HomePage;