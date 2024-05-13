import React, { ChangeEvent, useState } from 'react'
import "./Css/TelaCadastro.css"
import axios from 'axios';

interface Usuario {
    id: string;
    email: string;
    login: string;
    nome: string;
    sobrenome: string;
    nomeCompleto: string;
    idade: number;
    senha: string;
    confirmarSenha: string;
}

const TelaCadastro = () => {
    const [usuario, setUsuario] = useState<Usuario>({
        id: '',
        email: '',
        login: '',
        nome: '',
        sobrenome: '',
        nomeCompleto: '',
        idade: 0,
        senha: '',
        confirmarSenha: ''
    })

    const url = 'http://localhost:5087/api/Auth/register'

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        setUsuario(prevUser => ({
            ...prevUser,
            [name]: value
        }))
    }

    const handleSenhaChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        if (name === 'senha' || name === 'confirmarSenha') {
            setUsuario(prevUser => ({
                ...prevUser,
                [name]: value
            }))
        }
    }

    const handleSubmit = async () => {
        try {
            const response = await axios.post(url, {
                login: usuario.login,
                nome: usuario.nome,
                sobrenome: usuario.sobrenome,
                email: usuario.email,
                password: usuario.senha,
                idade: usuario.idade
            })
            console.log("Usuário criado com sucesso");
            setUsuario(response.data)
        } catch (error) {
            console.error("Erro ao criar usuário:", error);
        }
    }

    return (
        <>
            <div className='containeir-registro-usuario'>
                <div className='container-inputs-cadastro'>
                    <div className='containser-texto-cadastro'>
                        <h1>Crie a sua conta</h1>
                    </div>
                    <div className='organizador-cadastro'>
                    <div className='container-infos-registro'>
                        <h2>Nome</h2>
                        <input type="text" name="nome" value={usuario.nome} onChange={handleChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>Sobrenome</h2>
                        <input type="text" name="sobrenome" value={usuario.sobrenome} onChange={handleChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>E-mail</h2>
                        <input type="text" name="email" value={usuario.email} onChange={handleChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>Confirmar e-mail</h2>
                        <input type="text" name="email" value={usuario.email} onChange={handleChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>Nome Usuário</h2>
                        <input type="text" name="userName" value={usuario.login} onChange={handleChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>Idade</h2>
                        <input type="text" name="idade" value={usuario.idade} onChange={handleChange} />
                    </div >
                    <div className='container-infos-registro'>
                        <h2>Senha</h2>
                        <input type="password" name="senha" value={usuario.senha} onChange={handleSenhaChange} />
                    </div>
                    <div className='container-infos-registro'>
                        <h2>Confirmar Senha</h2>
                        <input type="password" name="confirmarSenha" value={usuario.confirmarSenha} onChange={handleSenhaChange} />
                    </div >
                    </div>
                    <div className='container-botao-cadastrar'>
                        <button onClick={handleSubmit}>Cadastrar</button>
                    </div>
                </div>
            </div>
        </>
    )
}

export default TelaCadastro
