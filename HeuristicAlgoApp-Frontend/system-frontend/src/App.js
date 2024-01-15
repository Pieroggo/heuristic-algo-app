import './App.css';
import React, { Component }  from 'react';
import { useEffect } from 'react';
import { useStore } from './store';
import { observer } from 'mobx-react-lite';
import axios from 'axios';
import Inputs from './assets/Inputs';

function App() {

  // stany i funkcje z magazynu
  const { appStore } = useStore();

  // dane z bazy
  useEffect(() => {
    axios.get(appStore.apiPath + '/Algorithm/GetAll')
      .then(response => {
        appStore.setAlgorithms(response.data)
        appStore.setAllAlgorithms(response.data)
      })
      axios.get(appStore.apiPath + '/FitnessFunction/GetAll')
      .then(response => {
        appStore.setFunctions(response.data)
        appStore.setAllFunctions(response.data)
      })
  }, [])

  return (
    <div className="App flex-box-main">

      <div className='flex-box-row'>

        <div className='flex-box-items'>
          <h1>Single task</h1>
          <p>"Jeden algorytm dla wielu funkcji testowych"</p>
          <div className='item1 items'>
            <h3>Wybierz algorytm: </h3>
            <p>(ustaw ilość iteracji i wielkość populacji)</p>
            <p>(oraz dodatkowe parametry (jeśli posiada))</p>

            <Inputs algoOrFunc={"algo"} multiple={false} />

          </div>

          <div className='item2 items'>
            <h3>Wybierz funkcje: </h3>
            <p>(ustaw ilość parametrów i ich zakresy)</p>

            <Inputs algoOrFunc={"func"} multiple={true} />

          </div>

          <button onClick={() => appStore.runSinlgeTask()}>Uruchom</button>

        </div>


        <div className='flex-box-items'>
          <h1>Multi task</h1>
          <p>"Jedna funkcja testowa dla wielu algorytmów"</p>
          <div className='item1 items'>
            <h3>Wybierz algorytmy: </h3>
            <p>(ustaw ilość iteracji i wielkość populacji)</p>
            <p>(automatyczny dobór parametrów)</p>

            <Inputs algoOrFunc={"algo"} multiple={true} />

          </div>

          <div className='item2 items'>
            <h3>Wybierz funkcję: </h3>
            <p>(ustaw ilość jej parametrów i ich zakresy)</p>

            <Inputs algoOrFunc={"func"} multiple={false} />

          </div>

          <button onClick={() => appStore.runMultiTask()}>Uruchom</button>

        </div>
      </div>

      <div className='flex-box-footer'>
        <h1>Wgrywanie</h1>
        <p>Tutaj możesz przesłać własny plik (.dll) z funkcją lub algorytmem do systemu</p>
        <div>
          <input type="file" id="fileUpload" onChange={appStore.handleOnChangeFile} /> <br />
          <button onClick={appStore.handleUpload}>Prześlij plik</button>
        </div>
      </div>

    </div>
  );
}

export default observer(App);
