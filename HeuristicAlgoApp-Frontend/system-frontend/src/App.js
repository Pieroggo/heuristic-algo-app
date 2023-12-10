import logo from './logo.svg';
import './App.css';
import { useEffect } from 'react';
import { useStore } from './store';
import { observer } from 'mobx-react-lite';
import axios from 'axios';

function App() {

  // stany i funkcje z magazynu
  const { appStore } = useStore();

  // dane z bazy
  useEffect(() => {
    axios.get(appStore.apiPath + '/users')
      .then(response => {
        appStore.algorithms = response.data
      })
  }, [])


  return (
    <div className="App">

      <div>
        <table className="bp4-html-table .modifier">
          <thead>
            <tr>
              <th>Nazme</th>
              <th>Email</th>
            </tr>
          </thead>
          {appStore.algorithms.map(algo => (
            <tr key={algo.id}>
              <td>{algo.name}</td>
              <td>{algo.email}</td>
            </tr>
          ))}
        </table>
      </div>

    </div>
  );
}

export default observer(App);
