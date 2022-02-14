import React from "react";
import {Line} from 'react-chartjs-2';
import {Chart as ChartJS, registerables} from 'chart.js';

ChartJS.register(
  ...registerables
);

function LineChart(props) {
  function Grafico(){
    return(
      <div style={{height:'500px'}}>
        <Line 
            data={{
                labels: [...Array(props.result.length).keys()],
                datasets: [{
                label: 'Line Dataset',
                data: props.result,
                fill: false,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1
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
export default LineChart;