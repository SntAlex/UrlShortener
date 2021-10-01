import React from 'react';
import {Redirect, Route, Switch} from "react-router-dom";
import {routes} from "../../routes/routes";

const AppRouter = () => {
    return (
        <Switch>
            {routes.map(route =>
                <Route
                    exact={route.exact}
                    component={route.component}
                    path={route.path}
                />
            )}
            <Redirect to='/error'/>
        </Switch>
    );
};

export default AppRouter;