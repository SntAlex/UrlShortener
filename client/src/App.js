import {BrowserRouter, Route, Switch} from "react-router-dom";
import Home from "./pages/Home";
import ErrorPage from "./pages/ErrorPage";
import RedirectPage from "./pages/RedirectPage";

const App = () => {

    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/error">
                    <ErrorPage />
                </Route>
                <Route exact path="/">
                    <Home />
                </Route>
                <Route path='/'>
                    <RedirectPage/>
                </Route>
            </Switch>
        </BrowserRouter>
    );
};

export default App;