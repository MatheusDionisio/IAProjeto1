import {useState} from 'react';
import api from '../API/selecao';
import LineChart from './LineChart'
import DotChart from './DotChart'
import Dropdown from 'react-bootstrap/Dropdown';

function App() {
  const [resultado, setResultado] = useState();
  const [populacoes, setPopulacoes] = useState();
  const [indice, setIndice] = useState(0);

  const obtenhaPopulacoes = async () => {
    const result = await api.get('Populacoes')
    return result.data;
  }

  const obtenhaDados = async () =>{
    const pop = await obtenhaPopulacoes();
    console.log(pop);
    var dados =[];
    for(let i = 0; i < pop.length; i++){
      dados.push(Math.max.apply(null, pop[i]));
    }
    console.log(dados);
    setResultado(dados);
    setPopulacoes(pop);
    setIndice(0);
  }
  const obtenhaProximo = () =>{
    const prox = indice+1;
    if(prox >= populacoes.length){
      return;
    }
    setIndice(prox);
  }

  const obtenhaAnterior = () =>{
    const ant = indice-1;
    if(ant < 0){
      return;
    }
    setIndice(ant);
  }
  const obtenhaValor = (e) =>{
    setIndice(e.target.innerText)
  }

  const obtenhaDropDown = () =>{
    var dados = [];
    for(let i=0;i < resultado.length;i++){
      dados.push(<Dropdown.Item key={i}
        onClick ={obtenhaValor}
      >
        {i}
      </Dropdown.Item>)
    }
    return dados;
  }

  return (
    <div className="mainpage">
      <div className="row">
        <div className="col-9">
        { populacoes === undefined ? (
            <></>
          ) : 
          (<>
              <div className="row">
                <LineChart 
                  result= {resultado}
                />
              </div>
              <div className="row">
                <div className="col-12">
                  <DotChart 
                    result= {populacoes[indice]}
                  />
                </div>
              </div>
            </>
          )
        }
        </div>
        <div className="col-3">
          <div className="row">
          <div className="col-12">
            <button type="button" className="btn btn-outline-primary" style={{width:"100%"}} onClick={obtenhaDados}>Obtenha dados</button>
          </div>
          </div>
          {resultado === undefined ? (<></>) :
            (<>
            
          <div className="row mt-2">
            <div className="col-3">
              <button type="button" style={{width:"100%"}} className="btn btn-outline-primary" onClick={obtenhaAnterior}>
              <i class="fa-solid fa-minus"></i>
              </button>
            </div>
            <div className="col-3">
              <button type="button" style={{width:"100%"}} className="btn btn-outline-primary" onClick={obtenhaProximo}>
                <i className="fa-solid fa-plus"></i>
              </button>
            </div>
            <div className="col-6">
              <Dropdown>
                <Dropdown.Toggle variant="primary" style={{width:"100%"}}>
                  {indice}
                </Dropdown.Toggle>
                <Dropdown.Menu
                
                style={{overflow:"scroll",maxHeight:"350px",width:"100%"}}

                >
                  {obtenhaDropDown()}
                </Dropdown.Menu>
              </Dropdown>
             
            </div>
          </div>
          </>
           )
          }
        </div>
      </div>
    </div>
  );
}

export default App;
