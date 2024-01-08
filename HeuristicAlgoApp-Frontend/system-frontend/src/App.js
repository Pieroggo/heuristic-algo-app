import './App.css';
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
      })
    axios.get(appStore.apiPath + '/FitnessFunction/GetAll')
      .then(response => {
        appStore.setFunctions(response.data)
      })
  }, [])

  return (
    <div className="App flex-box-main">

      <div className='flex-box-row'>

        <div className='flex-box-items'>
          <h2>Single task</h2>
          <p>jeden algorytm dla wielu funkcji testowych</p>
          <div className='item1 items'>
            <h3>wybierz algorytm: </h3>

            <Inputs which={"algo"} many={false} />

          </div>

          <div className='item2 items'>
            <h3>wybierz funkcje: </h3>

            <Inputs which={"func"} many={true} />

          </div>

          <button onClick={() => appStore.runSinlgeTask()}>Uruchom</button>


        </div>


        <div className='flex-box-items'>
          <h2>Multi task</h2>
          <p>jedna funkcja testowa dla wielu algorytmów</p>
          <div className='item1 items'>
            <h3>wybierz algorytmy: </h3>
            <p>automatyczny dobór najlepszych parametrów</p>

            <Inputs which={"algo"} many={true} />

          </div>

          <div className='item2 items'>
            <h3>wybierz funkcję: </h3>

            <Inputs which={"func"} many={false} />

          </div>

          <button onClick={() => appStore.runMultiTask()}>Uruchom</button>

        </div>
      </div>

      <div className='flex-box-footer'>
        <h1>Wgrywanie</h1>
        <p>Tutaj możesz przesłać własny plik (.dll) z funkcją lub algorytmem do systemu</p>
        <div>
          <input type="file" id="fileUpload" onChange={appStore.handleFileChange} /> <br />
          <button onClick={appStore.handleUpload}>Prześlij plik</button>
        </div>
      </div>

    </div>
  );
}

export default observer(App);
