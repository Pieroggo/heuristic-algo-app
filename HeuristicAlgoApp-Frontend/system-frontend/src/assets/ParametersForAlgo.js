import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function ParametersForAlgo({ id }) {

    const { appStore } = useStore();
    let a = appStore.getAlgorithmById("single", id)

    return (
        <div className="parametersForAlgo">

            {a.parameters.map((parameter, i) => (
                <label key={parameter.id}>
                    {parameter.name}:&nbsp;
                    <input
                        type="number"
                        value={appStore.singleAlgoParameters[i]}
                        id={"single-algo-param-" + parameter.id}
                        min={parameter.lowerBoundary}
                        max={parameter.upperBoundary}
                        className="mediumNumInput"
                        onChange={(e) => appStore.setAlgorithmParameters(id, i, e.target.value)}>
                    </input>
                </label>
            ))}

        </div>
    )

})
