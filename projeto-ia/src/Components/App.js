import {useState} from 'react';
import api from '../API/selecao';
import LineChart from './LineChart'


function App() {
  const [resultado, setResultado] = useState();
  const [populacoes, setPopulacoes] = useState();

  const obtenhaMelhores = async () => {
    const result = await api.post('Melhores')
    console.log("Buscou na api");
    setResultado(result.data);
  }

  const obtenhaPopulacoes = async () => {
    const result = await api.post('Populacoes')
    setPopulacoes(result.data);
  }

  return (
    <div className="mainpage">
      <div className="row">
        <div className="col-3">
          <button type="button" className="btn btn-outline-primary" onClick={obtenhaMelhores}>Obtenha dados</button>
        </div>
        <div className="col-12">
          <LineChart 
            result= {resultado}
          />
        </div>
        
        {/* {resultado !== undefined ? resultado.map((resultado, index) => <p>{`${index} - ${resultado}`}</p>): <p></p>} */}
      </div>
    </div>
  );
}

export default App;
