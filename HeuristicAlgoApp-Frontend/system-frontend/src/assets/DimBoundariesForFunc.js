import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function DimBoundariesForFunc({ singleOrMulti, id }) {

    const { appStore } = useStore();
    let f = appStore.getFunctionById(singleOrMulti, id);

    if (singleOrMulti === "single") {
        return (

            <div className="bounds">
                <div className="lowerBounds">
                    {f.lowerBoundaries.map((v, k) => (
                        <label key={"single-func-" + f.name + "-dim-lower-" + k}>
                            {/* {console.log("dolne - val:", v, "key:", k)} */}
                            &lt; &nbsp;
                            <input type="number" id={"single-func-" + f.name + "-dim-lower-" + k} value={v} className="mediumNumInput" onChange={(e) => appStore.handleOnChangeFuncLowerBound(singleOrMulti, f.id, k, e)}></input>
                        </label>
                    ))}
                </div>
                <div className="upperBounds">
                    {f.upperBoundaries.map((v, k) => (
                        <label key={"single-func-" + f.name + "-dim-upper-" + k}>
                            {/* {console.log("gorne - val:", v, "key:", k)} */}
                            &nbsp; &#59; &nbsp;
                            <input type="number" id={"single-func-" + f.name + "-dim-upper-" + k} value={v} className="mediumNumInput" onChange={(e) => appStore.handleOnChangeFuncUpperBound(singleOrMulti, f.id, k, e)}></input>
                            &nbsp; &gt;
                        </label>
                    ))}
                </div>
            </div>
        )
    }

    if (singleOrMulti === "multi") {
        return (

            <div className="bounds">
                <div className="lowerBounds">
                    {f.lowerBoundaries.map((v, k) => (
                        <label key={"multi-func-" + f.name + "-dim-lower-" + k}>
                            {/* {console.log("dolne - val:", v, "key:", k)} */}
                            &lt; &nbsp;
                            <input type="number" id={"multi-func-" + f.name + "-dim-lower-" + k} value={v} className="mediumNumInput" onChange={(e) => appStore.handleOnChangeFuncLowerBound(singleOrMulti, f.id, k, e)}></input>
                        </label>
                    ))}
                </div>
                <div className="upperBounds">
                    {f.upperBoundaries.map((v, k) => (
                        <label key={"multi-func-" + f.name + "-dim-upper-" + k}>
                            {/* {console.log("gorne - val:", v, "key:", k)} */}
                            &nbsp; &#59; &nbsp;
                            <input type="number" id={"multi-func-" + f.name + "-dim-upper-" + k} value={v} className="mediumNumInput" onChange={(e) => appStore.handleOnChangeFuncUpperBound(singleOrMulti, f.id, k, e)}></input>
                            &nbsp; &gt;
                        </label>
                    ))}
                </div>
            </div>
        )
    }

})
