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
    <div className="App flex-box-main">

      <div className='flex-box-row'>

        <div className='flex-box-items'>
          <h2>Single</h2>
          <div className='item1'>
            <h3>Algorytmy: </h3>
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
                    <td>{ }</td>
                    <td>{algo}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <div className='item2'>
            <h3>Funkcje: </h3>
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
                    <td>{ }</td>
                    <td>{func}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

        </div>


        <div className='flex-box-items'>
          <h2>Multi</h2>
          <div className='item1'>
            <h3>Algorytmy: </h3>
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
                    <td>{ }</td>
                    <td>{algo}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <div className='item2'>
            <h3>Funkcje: </h3>
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
                    <td>{ }</td>
                    <td>{func}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

        </div>
      </div>

      <div className='flex-box-buttons'>
        <h1>Upload</h1>
        <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce venenatis justo ut augue tempus, id facilisis diam aliquam. Sed libero nisi, consectetur sed molestie vitae, varius et lacus. Aenean massa magna, maximus at porta non, viverra at turpis. Suspendisse auctor, ante eu bibendum hendrerit, odio ligula viverra quam, sed mattis lectus mauris sed justo. Ut facilisis, massa in pulvinar vehicula, dolor nulla mollis nisi, condimentum fringilla ligula lectus eu neque. Sed et libero sapien. Fusce dapibus pulvinar enim sit amet placerat. Nulla efficitur ac arcu et feugiat. 
        </p>
      </div>

    </div>
  );
}

export default observer(App);
