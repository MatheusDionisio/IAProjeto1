import React from "react";
import {Scatter} from 'react-chartjs-2';
import {Chart as ChartJS, registerables} from 'chart.js';

ChartJS.register(
  ...registerables
);

function DotChart(props) {

    const Grafico = () => {
        console.log(props.result)
        const filtrado = props.result[0];
        var dados = []
        for(let i=0;i<filtrado.length;i++){
            const info = {x:i, y:filtrado[i]};
            dados.push(info);
        }
        debugger;
        return(
            <div style={{height:'500px'}}>
                <Scatter 
                    data={{
                        datasets: [{
                            label: 'Scatter Dataset',
                            data: dados,
                            backgroundColor: 'rgb(255, 99, 132)'
                        }]
                    }}
                    height={400}
                    width = {600}
                    options = {{
                        maintainAspectRatio: false
                    }}
                />
            </div>
        );
    }

  return(
    <>
        {props.result === undefined ? <div></div> : Grafico()}
    </>
  );
}
export default DotChart;