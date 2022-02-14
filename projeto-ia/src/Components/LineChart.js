import React from "react";
import {Line} from 'react-chartjs-2';
import {Chart as ChartJS, registerables} from 'chart.js';

ChartJS.register(
  ...registerables
);

function LineChart(props) {
  console.log(props.result);
  debugger;
  return(
    <div style={{height:'500px'}}>
        <Line 
            data={{
                labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange', 'Orange'],
                datasets: [{
                label: 'My First Dataset',
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
export default LineChart;