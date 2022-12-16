import logo from './logo.svg';
import './App.css';

import {Shop} from './Shop';

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="main">
     <Switch>
       <Route path='/' component={Shop} />
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
