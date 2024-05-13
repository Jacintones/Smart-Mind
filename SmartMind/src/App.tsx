import {BrowserRouter, Routes, Route} from 'react-router-dom'
import NavBar from '../Component/NavBar.tsx';
import TelaLogin from '../pages/TelaLogin.tsx';
import TelaQuestoes from '../pages/TelaQuestoes.tsx';
import TelaCadastro from '../pages/TelaCadastro.tsx';
import TelaInicial from '../pages/TelaInicial.tsx';
import TelaCategoria from '../pages/TelaCategoria.tsx';
import TelaUsuario from '../pages/TelaUsuario.tsx';

function App() {

  return (
    <>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/login" element={<TelaLogin />}/>
          <Route path="/fazerTeste/:id" element={<TelaQuestoes />}/>
          <Route path='/Cadastro' element={<TelaCadastro />}/>
          <Route path="/" element={<TelaInicial />}/>
          <Route path='/categoria/:id' element={<TelaCategoria />} />
          <Route path='/User/:id' element={<TelaUsuario />} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
