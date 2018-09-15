import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import { 
  TaskPage,
  SingleTaskPage
} from './components/Pages';

const NotFound = () => <div>Not Found</div>;

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='/counter' component={Counter} />
          <Route path='/fetchdata' component={FetchData} />
          <Route path='/task/:id' component={SingleTaskPage} />
          <Route path='/task' component={TaskPage} />
          <Route component={NotFound} />
        </Switch>
      </Layout>
    );
  }
}
