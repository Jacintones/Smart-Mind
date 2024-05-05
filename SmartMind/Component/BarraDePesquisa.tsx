import "./Css/BarraDePesquisa.css"

const BarraDePesquisa = () => {
  return (
    <div className='barra-pesquisa'>
          <div className="h2-barra">
            <h2>Smart-Mind</h2>
          </div>
            <div className="container-botoes-pesquisa">
              <button>Entrar</button>
              <button>Cadastrar</button>
              <button className="area-botao">Área do Aluno</button>
            </div>
    </div>
  )
}

export default BarraDePesquisa
