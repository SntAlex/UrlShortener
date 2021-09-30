import React from 'react';
import {Link} from "react-router-dom";

const ShortUrlLinker = ({urlPath}) => {
    return (
        <Link to={urlPath}>
            {urlPath === '' ? '' : window.location.protocol + '//' + window.location.hostname + ':' + window.location.port + '/' + urlPath}
        </Link>
    );
};

export default ShortUrlLinker;