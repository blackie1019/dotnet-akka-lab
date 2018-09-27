import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Sportsbook from './components/Sportsbook';
import Chat from './components/Chat';

export default () => (
  <Layout>
    <Route exact path='/home' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    <Route path='/:startDateIndex?' component={Sportsbook} />
    <Route path='/chat' component={Chat}/>
  </Layout>
);
