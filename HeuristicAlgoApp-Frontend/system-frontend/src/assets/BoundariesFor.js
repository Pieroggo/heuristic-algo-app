import { useStore } from "../store";
import { observer } from "mobx-react-lite";

export default observer(function BoundariesFor({ id }) {

    const { appStore } = useStore();

    let f = appStore.getFunctionById(id);

    if (f.dimension < 1) { appStore.setFuntionDimension(id, 0) }

    // console.log("function ", f.id, " dimensions ", f.dimension)

    return (
        // console.log("for")
        // for (let i = 0; i < f.dimension; i++) {
        //     <div>
        //         {console.log("inside for")}
        //         {i}
        //         <label>gorna granica:
        //             <input type="number" value={f.upperBoundaries[i]} className="mediumNumInput"></input>
        //         </label>
        //         <label>dolna granica:
        //             <input type="number" value={f.lowerBoundaries[i]} className="mediumNumInput"></input>
        //         </label>
        //     </div>
        // };
        <div className="bounds">
            <div className="lowerBounds">
                {f.lowerBoundaries.map((v, k) => (
                    <label key={f.name + "_dim_0_" + k}>
                        {/* {console.log("dolne - val:", v, "key:", k)} */}
                        &lt; &nbsp;
                        <input type="number" id={f.name + "_dim_0_" + k} value={v} className="mediumNumInput" onChange={() => { }}></input>
                    </label>
                ))}
            </div>
            <div className="upperBounds">
                {f.upperBoundaries.map((v, k) => (
                    <label key={f.name + "_dim_1_" + k}>
                        {/* {console.log("gorne - val:", v, "key:", k)} */}
                        &nbsp; &#59; &nbsp;
                        <input type="number" id={f.name + "_dim_1_" + k} value={v} className="mediumNumInput" onChange={() => { }}></input>
                        &nbsp; &gt;
                    </label>
                ))}
            </div>
        </div>
    )


})
