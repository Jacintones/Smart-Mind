import "./Css/BarraDePesquisa.css";

interface User {
  nome: string;
  
}

interface BarraDePesquisaProps {
  user: User | null;
  handleUsuario: () => void; // Defina a propriedade handleUsuario na interface
}

const BarraDePesquisa: React.FC<BarraDePesquisaProps> = ({ user, handleUsuario }) => {
  return (
    <div className='barra-pesquisa'>
      <h2 className="h2-titulo-smart">Smart-Mind</h2>
      {user ? (
        <div className="barra-user-logado">
          <h3> Bem-vindo, {user.nome}!</h3>
        </div>
      ) : (
        <div className="container-botoes-pesquisa">
          <button>Entrar</button>
          <button>Cadastrar</button>
        </div>
      )}
      <button className="area-botao" onClick={handleUsuario}>Área do Aluno</button>
    </div>
  )
}

export default BarraDePesquisa;
