import { useLocation, useNavigate, useParams } from 'react-router-dom';
import "./Css/TelaUsuario.css";
import BarraDePesquisa from '../Component/BarraDePesquisa';

interface Teste {
  id: number;
  nome : string
  pontuacao: string;
  pontuacaoUsuario: string;
}

const TelaUsuario = () => {
    const location = useLocation();
    const { id } = useParams();
    const user: any = location.state ? location.state.user : null; // Usando 'any' como tipo de user
    const token: string | null = location.state ? location.state.token : null;

    const navigate = useNavigate();

    const handleAreaUsuario = () => {
      navigate(`/User/${user.id}`, {
          state: {
              token : token,
              user: user
            }
      });
  }

  return (
    <>
    <BarraDePesquisa user={user} handleUsuario={handleAreaUsuario} />
    <div className='container-principal-usuario'>
        <div className='container-user-infos'> 
            <h2>Informações</h2>
            {user && (
              <>
                <p>Nome: {user.nomeCompleto}</p>
                <p>E-mail: {user.email}</p>
                <p>Idade: {user.idade}</p>
              </>
            )}
        </div>
        <div className='container-meus-testes'>
          <h2>Minhas avaliações</h2>
          {user && user.testes.map((teste: Teste) => ( // Especificando o tipo de 'teste' como 'Teste'
            <li key={teste.id}>
              <div className='container-teste-feitos'>
                <p>{teste.nome}</p>
                <p>{teste.pontuacao}/{teste.pontuacaoUsuario}</p>
              </div>
            </li>
          ))}
        </div>
    </div>
    </>
  )
}

export default TelaUsuario;
