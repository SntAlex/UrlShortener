import {BrowserRouter, Route, Switch} from "react-router-dom";
import AppRouter from "./components/AppRouter/AppRouter";

const App = () => {

    return (
        <BrowserRouter>
            <AppRouter/>
        </BrowserRouter>
    );
};

export default App;