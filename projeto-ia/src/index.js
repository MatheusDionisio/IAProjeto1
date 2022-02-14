import React from 'react';
import ReactDOM from 'react-dom';
import './css/index.css';
import App from './Components/App';
import 'bootstrap/dist/css/bootstrap.min.css';

ReactDOM.render(
  <React.StrictMode>
    <div style={{marginLeft:'100px', marginRight:'100px', marginTop:'10px'}}>
      <App />
    </div>
  </React.StrictMode>,
  document.getElementById('root')
);
