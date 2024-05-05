import { ChangeEvent, useState } from 'react'
import "./Css/TelaLogin.css"
import axios from 'axios'

interface User {
  userName: string
  senha: string
}

const TelaLogin = () => {
    const [user, setUser] = useState<User>({
        userName: '',
        senha: ''
      })
      const url = "http://localhost:5087/api/Auth/Login"
    
      const handleLogin = async () => {
        try {
          const response = await axios.post(url, {
            userName: user.userName,
            password: user.senha
          })
          console.log(response.data);
        } catch (error) {
          console.error('Erro ao fazer login:', error);
        }
      }
    
      const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        setUser(prevUser => ({
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
              <input type="text" name='userName' value={user.userName} onChange={handleChange} />
              <h2>Senha</h2>
              <input type="password" name='senha' value={user.senha} onChange={handleChange} />
              <div className='container-botoes-login'>
                <button className='botao-login' onClick={handleLogin}>Login</button>
              </div>
            </div>
            <div className='container-nao-tem-uma-conta'>
              <h1>Não tem uma conta? cadastre-se Agora</h1>
              <button>Cadastra-se</button>
            </div>
          </div>
        </>
      )
    }

export default TelaLogin
