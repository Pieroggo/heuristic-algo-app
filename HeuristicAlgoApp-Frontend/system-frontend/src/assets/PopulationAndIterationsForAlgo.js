import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function PopulationAndIterationsForAlgo({ singleOrMulti, id }) {

    const { appStore } = useStore();
    let popInputId = singleOrMulti + "Population"
    let iterInputId = singleOrMulti + "Iterations"

    return (
        <div className="populationAndIterations">

            <label htmlFor={popInputId}>
                Populacja:&nbsp;
                <input
                    type="number"
                    id={popInputId}
                    value={
                        (singleOrMulti == "single") ?
                            appStore.singlePopulation
                            :
                            appStore.multiPopulation
                    }
                    className="mediumNumInput"
                    onChange={(e) => appStore.setPopulation(singleOrMulti, e.target.value)}>
                </input>
            </label>

            &nbsp;&nbsp;

            <label htmlFor={iterInputId}>
                Iteracje:&nbsp;
                <input
                    type="number"
                    id={iterInputId}
                    value={
                        (singleOrMulti == "single") ?
                            appStore.singleIterations
                            :
                            appStore.multiIterations
                    }
                    className="mediumNumInput"
                    onChange={(e) => appStore.setIterations(singleOrMulti, e.target.value)}>
                </input>
            </label>

        </div>
    )

})
