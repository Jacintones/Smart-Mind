import { useEffect, useState } from "react"
import MenuAppBar from "../Component/headers/MenuAppBar"
import "./Css/TelaInicial.css"
import axios from "axios"
import { useLocation, useNavigate } from "react-router-dom"

interface Materia {
    id: number
    nome : string
    imagemUrl : string
}

interface Categoria {
    id: number
    nome : string
    materias : Materia[]
}

const TelaInicial = () => {
    const location = useLocation()
    const [categorias, setCategorias] = useState<Categoria[]>([])
    const navigate = useNavigate();
    const user =  location.state ? location.state.user : null
    const token =  location.state ? location.state.token : null

    const urlCategoria = "https://localhost:7019/api/Categoria/CategoriaComMateria";

    const getMaterias = async () => {
        try {
            const response = await axios.get(urlCategoria);
            
            //Seta as categorias
            setCategorias(response.data);

        } catch (error) {
            console.error("Erro ao obter as categorias e matérias:", error)
        }
    }

    useEffect(() => {
        getMaterias()
      }, [])
      
      const handleMateriaClick = (materiaId: number) => {
        navigate(`/Categoria/${materiaId}`, {
            state: {
                token : token,
                user: user
              }
        })
    }

    const handleAreaUsuario = () => {
        navigate(`/User/${user.id}`, {
            state: {
                token : token,
                user: user
              }
        })
    }

      return (
        <div>
            <MenuAppBar />
            <div className="container-todas-materias">
                {categorias.map(categoria => (
                    <div key={categoria.id} className="categoria-container">
                        <h1 className="h1-categoria">{categoria.nome}</h1>
                        <div className="materias-container">
                            {categoria.materias.map(materia => (
                                <div key={materia.id} className="container-materia-inicial" onClick={() => handleMateriaClick(materia.id)}>
                                    <img src={materia.imagemUrl} alt={materia.nome} />
                                    <h2>{materia.nome}</h2>
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
