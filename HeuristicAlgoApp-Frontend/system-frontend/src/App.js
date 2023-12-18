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
        appStore.setAlgorithms(response.data)
      })
    axios.get(appStore.apiPath + '/FitnessFunction/Get')
      .then(response => {
        appStore.setFunctions(response.data)
      })
  }, [])

  return (
    <div className="App flex-box-main">

      <div className='flex-box-row'>

        <div className='flex-box-items'>
          <h2>Single task</h2>
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
          <h2>Multi task</h2>
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
        <h1>Wgrywanie</h1>
        <p>Tutaj możesz przesłać własny plik (.dll) z funkcją lub algorytmem do systemu</p>
        <div>
          <input type="file" id="fileUpload" onChange={appStore.handleFileChange} /> <br /><br />
          <button onClick={appStore.handleUpload}>Prześlij plik</button>
        </div>
      </div>

    </div>
  );
}

export default observer(App);
