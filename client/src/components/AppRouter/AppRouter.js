import React from 'react';
import {Route, Switch} from "react-router-dom";
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
        </Switch>
    );
};

export default AppRouter;