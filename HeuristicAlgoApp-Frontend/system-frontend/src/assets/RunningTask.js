import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function RunningTask({ singleOrMulti }) {

    const { appStore } = useStore();

    if (singleOrMulti == "single") {
        return (
            <div className="runningTask">
                {appStore.singleTaskIsStarted && appStore.singleTaskIsRunning &&
                    <div>
                        SingleTask się mieli..
                        <button onClick={() => appStore.breakTask(singleOrMulti)}>Przerwij</button>
                    </div>
                }
                {appStore.singleTaskIsStarted && !appStore.singleTaskIsRunning &&
                    <div>
                        Wstrzymany. <br /> 
                        {appStore.singleTaskState} &nbsp; 
                        <button onClick={() => appStore.resumeTask(singleOrMulti)}>Wznów</button>
                    </div>
                }
            </div>
        )
    }

    if (singleOrMulti == "multi") {
        return (
            <div className="runningTask">
                {appStore.multiTaskIsStarted && appStore.multiTaskIsRunning &&
                    <div>
                        MultiTask się mieli..
                        <button onClick={() => appStore.breakTask(singleOrMulti)}>Przerwij</button>
                    </div>
                }
                {appStore.multiTaskIsStarted && !appStore.multiTaskIsRunning &&
                    <div>
                        Wstrzymany. <br />
                        {appStore.multiTaskState} <br />
                        <button onClick={() => appStore.resumeTask(singleOrMulti)}>Wznów</button>
                    </div>
                }
            </div>
        )
    }


})
