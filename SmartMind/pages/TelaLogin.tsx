import { ChangeEvent, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import "./Css/TelaLogin.css"
import axios from 'axios'

interface User {
  email: string
  senha: string
}
const TelaLogin = () => {
  const [user, setUser] = useState()  
  const [loginData, setLoginData] = useState<User>({
      email: '',
        senha: ''
      })
      const url = "https://localhost:7019/api/Auth/login"

    const [token, setToken] = useState();
    const navigate = useNavigate();

      const handleLogin = async () => {
        try {
          const response = await axios.post(url, {
            email: loginData.email,
            senha: loginData.senha
          })
          setToken(response.data)

          if (token != null) {
            alert("Usuário logado com sucesso")
            handleGetUser()
          }

        } catch (error) {
          console.error('Erro ao fazer login:', error);
        }
      }

      const handleGetUser = async () => {
        try {
          const response = await axios.get(`https://localhost:7019/api/Auth/${loginData.email}`);
          setUser(response.data);
          
          navigate(`/`, {
            state: {
              token : token,
              user: response.data
            }
          }); 

        } catch (error) {
          console.error('Erro ao obter informações do usuário:', error);
        }
      };
      

      const handleRegister = () => {
        navigate(`/cadastro`); 
      }
    
      const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        setLoginData(prevUser => ({
          ...prevUser,
          [name]: value
        }))
      }
      
      return (
        <>
          <div className='container-login'>
            <div className='container-barras-login'>
              <h1>Login</h1>
              <h2>Usuario</h2>
              <input type="text" name='email' value={loginData.email} onChange={handleChange} />
              <h2>Senha</h2>
              <input type="password" name='senha' value={loginData.senha} onChange={handleChange} />
              <div className='container-botoes-login'>
                <button className='botao-login' onClick={handleLogin}>Login</button>
              </div>
            </div>
            <div className='container-nao-tem-uma-conta'>
              <h1>Não tem uma conta? cadastre-se Agora</h1>
              <button className='botao-cadastra-se' onClick={handleRegister}>Cadastra-se</button>
            </div>
          </div>
        </>
      )
    }

export default TelaLogin
