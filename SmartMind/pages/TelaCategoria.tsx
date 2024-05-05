import axios from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import "./Css/TelaCategoria.css"

interface Assunto {
    assuntoId: number
    nome: string
    videoAulaUrl: string
    materiaId: number
}

const TelaCategoria = () => {
    const { id } = useParams()
    const navigate = useNavigate();

    const [assuntos, setAssuntos] = useState<Assunto[]>([])

    const getAssuntos = async () => {
        try {
            const response = await axios.get(`http://localhost:5087/api/Materia/${id}`)
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
        <div className='container-tela-categorias'>
            <h1>Assuntos</h1>
            <ul>
                {assuntos.map(assunto => (
                    <div key={assunto.assuntoId} className='container-assunto' onClick={() => handleAssuntoCLICK(assunto.assuntoId)}>
                        <p>{assunto.nome}</p>
                    </div>
                    
                ))}
            </ul>
        </div>
    )
}

export default TelaCategoria
