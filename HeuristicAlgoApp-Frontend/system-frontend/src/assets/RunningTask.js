import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function RunningTask({ singleOrMulti }) {

    const { appStore } = useStore();

    if(singleOrMulti == "single"){
        return (
            <div className="runningTask">
                SingleTask się mieli..
                <button onClick={() => appStore.breakTask(singleOrMulti)}>Przerwij</button>
            </div>
        )
    }

    if(singleOrMulti == "multi"){
        return (
            <div className="runningTask">
                MultiTask się mieli..
                <button onClick={() => appStore.breakTask(singleOrMulti)}>Przerwij</button>
            </div>
        )
    }


})
