import {useState} from 'react';
import api from '../API/selecao';
import LineChart from './LineChart'
import DotChart from './DotChart'


function App() {
  const [resultado, setResultado] = useState();
  const [populacoes, setPopulacoes] = useState();

  const obtenhaMelhores = async () => {
    const result = await api.get('Melhores')
    console.log("Buscou na api");
    setResultado(result.data);
  }

  const obtenhaPopulacoes = async () => {
    const result = await api.get('Populacoes')
    setPopulacoes(result.data);
  }

  const obtenhaDados = async () =>{
    await obtenhaMelhores();
    await obtenhaPopulacoes();
  }

  return (
    <div className="mainpage">
      <div className="row">
        <div className="col-3">
          <button type="button" className="btn btn-outline-primary" onClick={obtenhaDados}>Obtenha dados</button>
        </div>
        <div className="col-12">
          <LineChart 
            result= {resultado}
          />
        </div>
        <div className="col-12">
          <DotChart 
            result= {populacoes}
          />
        </div>
      </div>
    </div>
  );
}

export default App;
