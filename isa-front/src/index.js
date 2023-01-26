import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
import 'font-awesome/css/font-awesome.css';
import { BrowserRouter } from 'react-router-dom';
import {registerLicense} from '@syncfusion/ej2-base'
registerLicense('Mgo+DSMBaFt/QHRqVVhjVFpFaV1LQmFJfFBmRGlYeVRxckUmHVdTRHRdQ19gSX9Qd0NiXn5XeXM=;Mgo+DSMBPh8sVXJ0S0J+XE9HflRDQmFAYVF2R2BJflRxcl9HZkwxOX1dQl9hSHxQdkRgWHlfd3ZUQWc=;ORg4AjUWIQA/Gnt2VVhkQlFadVdJXHxLd0x0RWFab196dVNMYVpBJAtUQF1hS39RdUViWn5YcXNXRWdb;ODQ2MjUyQDMyMzAyZTM0MmUzMGh5cUdTdjI3K0E0Qzk0RzM4ODF4MkY0V29UUVViQ29EejRuYy9SWjVGUVk9;ODQ2MjUzQDMyMzAyZTM0MmUzMEhCNnNOdmRlNUN2RG9kSkRvd2d2dWkxdHkwWDAwMlVaaVBlTFJTd3REWjQ9;NRAiBiAaIQQuGjN/V0Z+WE9EaFxKVmJWfFppR2NbfE5xflRAal1XVBYiSV9jS3xSdEZjWHxfdnVSRWBbVg==;ODQ2MjU1QDMyMzAyZTM0MmUzME1hTG1PVDkxYTI2eU1PNmRub1NkdTJtenl4ZUNHcVE5Qjl2TmljZFpseHM9;ODQ2MjU2QDMyMzAyZTM0MmUzMGNDYWJjaXdoY08yR1l3R2pqVW1zd1NsVGxNNDZkb0lCYmdWNnBQdEVFdWs9;Mgo+DSMBMAY9C3t2VVhkQlFadVdJXHxLd0x0RWFab196dVNMYVpBJAtUQF1hS39RdUViWn5YcXNWQWhb;ODQ2MjU4QDMyMzAyZTM0MmUzMGhTaSt5a0F4TmtGSlZNNnFzWFBSNy9xbmE1SkxseHM4S21lemd4ZWVZeGc9;ODQ2MjU5QDMyMzAyZTM0MmUzMEh2N2w2cDdmUzVRKytaY09ZbndZYVM5cjNQb0w1d0M1Z3RyRGI4Mk9pbEE9;ODQ2MjYwQDMyMzAyZTM0MmUzME1hTG1PVDkxYTI2eU1PNmRub1NkdTJtenl4ZUNHcVE5Qjl2TmljZFpseHM9')
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <App />
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
