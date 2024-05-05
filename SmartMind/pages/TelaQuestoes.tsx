import { useEffect, useState } from "react";
import "./Css/TelaQuestoes.css";
import axios from "axios";
import { useParams } from "react-router-dom";

interface Questao {
  questaoId: number
  enunciado: string
  alternativaCorreta: string
  alternativaErrada1: string
  alternativaErrada2: string
  alternativaErrada3: string
  alternativaErrada4: string
  dificuldade: number
  alternativasEmbaralhadas: string[]
}

const TelaQuestoes = () => {
  const [questoes, setQuestoes] = useState<Questao[]>([])
  const [respostas, setRespostas] = useState<{ [key: number]: string | null }>({})
  const { id } = useParams()
  const [nota, setNota] = useState(0)

  const url = `http://localhost:5087/api/Assunto/${id}`

  const getQuestoes = async () => {
    const response = await axios.get(url)
    
    const questoesEmbaralhadas = response.data.questoes.map((questao: Questao) => ({
      ...questao,
      alternativasEmbaralhadas: shuffleArray([
        questao.alternativaCorreta,
        questao.alternativaErrada1,
        questao.alternativaErrada2,
        questao.alternativaErrada3,
        questao.alternativaErrada4
      ])
    }))
    
    setQuestoes(questoesEmbaralhadas);
  }

  useEffect(() => {
    getQuestoes()
  }, [])

  const handleSelecaoAlternativa = (questaoId: number, alternativa: string) => {
    setRespostas(prevState => ({
      ...prevState,
      [questaoId]: alternativa
    }))
  }

  const shuffleArray = (array: string[]) => {
    const shuffledArray = [...array]
    for (let i = shuffledArray.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [shuffledArray[i], shuffledArray[j]] = [shuffledArray[j], shuffledArray[i]]
    }
    return shuffledArray
  }

  const calcularNota = () => {
    let notaAluno = 0

    questoes.forEach(questao => {
      const respostaSelecionada = respostas[questao.questaoId]
      if (respostaSelecionada === questao.alternativaCorreta) {
        notaAluno += 1
      }
    })

    const quantidadeQuestoes = questoes.length;
    const notaFinal = (notaAluno / quantidadeQuestoes) * 10;
    setNota(notaFinal)
  }

  return (
    <div className="container-fazer-questoes">
      <h1>AVALIAÇÃO</h1>
      <ul>
        {questoes.map((questao: Questao) => (
          <div className="container-questoes" key={questao.questaoId}>
            <li>
              <h3>{questao.enunciado}</h3>
              <div className="alternativas-container">
                {questao.alternativasEmbaralhadas.map((alternativa, index) => (
                  <label key={index}>
                    <input
                      type="radio"
                      value={alternativa}
                      checked={respostas[questao.questaoId] === alternativa}
                      onChange={() => handleSelecaoAlternativa(questao.questaoId, alternativa)}
                    />
                    {String.fromCharCode(65 + index)}) {alternativa}
                  </label>
                ))}
              </div>
            </li>
          </div>
        ))}
      </ul>
      <button onClick={calcularNota}>Enviar</button>
      <p>{nota}</p>
    </div>
  )
}

export default TelaQuestoes
