import axios from 'axios'
import { useEffect, useState } from 'react'
import { useLocation, useNavigate, useParams } from 'react-router-dom'
import "./Css/TelaCategoria.css"
import BarraDePesquisa from '../Component/BarraDePesquisa'
import MenuAppBar from '../Component/headers/MenuAppBar'

interface Assunto {
    id: number
    nome: string
    videoAulaUrl: string
    materiaId: number
}

const TelaCategoria = () => {
    const { id } = useParams()
    const navigate = useNavigate();
    const location = useLocation()
    const user =  location.state ? location.state.user : null

    const [assuntos, setAssuntos] = useState<Assunto[]>([])

    const getAssuntos = async () => {
        try {
            const response = await axios.get(`https://localhost:7019/api/Materia/${id}`)
            setAssuntos(response.data.assuntos)
        } catch (error) {
            console.error("Erro ao obter os assuntos:", error)
        }
    }

    useEffect(() => {
        getAssuntos()
    }, [])

    const handleAssuntoCLICK = (assuntoId: number) => {
        navigate(`/fazerTeste/${assuntoId}`); // Navega para a página da matéria com o ID da matéria
    }

    return (
        <div>
            <MenuAppBar />
        <div className='container-tela-categorias'>
            
            <h1>Assuntos</h1>
            <ul>
                {assuntos.map(assunto => (
                    <div key={assunto.id} className='container-assunto' onClick={() => handleAssuntoCLICK(assunto.id)}>
                        <p>{assunto.nome}</p>
                    </div>
                    
                ))}
            </ul>
            </div>
        </div>
    )
}

export default TelaCategoria
