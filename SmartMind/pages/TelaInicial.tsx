import { useEffect, useState } from "react"
import BarraDePesquisa from "../Component/BarraDePesquisa.tsx"
import "./Css/TelaInicial.css"
import axios from "axios"
import { useNavigate } from "react-router-dom"

interface Materia {
    materiaId: number
    nome : string
    imagemUrl : string
}

interface Categoria {
    categoriaId: number
    nome : string
    materias : Materia[]
}

const TelaInicial = () => {
    const [categorias, setCategorias] = useState<Categoria[]>([])
    const navigate = useNavigate();

    const urlCategoria = "http://localhost:5087/api/Categoria/CategoriaComMateria";

    const getMaterias = async () => {
        try {
            const response = await axios.get(urlCategoria);
            
            //Seta as categorias
            setCategorias(response.data);
            console.log(response.data)

        } catch (error) {
            console.error("Erro ao obter as categorias e matérias:", error)
        }
    }

    useEffect(() => {
        getMaterias()
      }, [])
      
      const handleMateriaClick = (materiaId: number) => {
        navigate(`/Categoria/${materiaId}`); // Navega para a página da matéria com o ID da matéria
    }

      return (
        <div>
            <div className='barra-tela-inicial'>
                <BarraDePesquisa />
            </div>
            <div className="container-todas-materias">
                {categorias.map(categoria => (
                    <div key={categoria.categoriaId} className="categoria-container">
                        <h2>{categoria.nome}</h2>
                        <div className="materias-container">
                            {categoria.materias.map(materia => (
                                <div key={materia.materiaId} className="container-materia-inicial" onClick={() => handleMateriaClick(materia.materiaId)}>
                                    <img src={materia.imagemUrl} alt={materia.nome} />
                                    <p>{materia.nome}</p>
                                </div>
                            ))}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    )
}
    
export default TelaInicial
