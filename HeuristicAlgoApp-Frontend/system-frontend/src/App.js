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
    axios.get(appStore.apiPath + '/Algorithm/GetAll')
      .then(response => {
        appStore.algorithms = response.data
      })
    axios.get(appStore.apiPath + '/FitnessFunction')
      .then(response => {
        appStore.functions = response.data
      })
  }, [])


  return (
    <div className="App">

      <div>
        <p>Algorytmy: </p>
        <table className="bp4-html-table .modifier">
          <thead>
            <tr>
              <th>l.p.</th>
              <th>nazwa</th>
            </tr>
          </thead>
          <tbody>
            {appStore.algorithms.map(algo => (
              <tr key={algo.id}>
                <td>{}</td>
                <td>{algo}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <br/>
      
      <div>
        <p>Funkcje: </p>
        <table className="bp4-html-table .modifier">
          <thead>
            <tr>
              <th>l.p.</th>
              <th>nazwa</th>
            </tr>
          </thead>
          <tbody>
            {appStore.functions.map(func => (
              <tr key={func.id}>
                <td>{}</td>
                <td>{func}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

    </div>
  );
}

export default observer(App);
