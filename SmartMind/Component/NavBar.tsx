import { Link } from 'react-router-dom'

const NavBar = () => {
  return (
    <nav>
        <Link to="/"></Link>
        <Link to="/login"></Link>
        <Link to="/fazerTeste/:id"></Link>
        <Link to="/Cadastro"></Link>
        <Link to="/Categoria/:id"></Link>
        <Link to="/User/:id"></Link>
    </nav>
  )
}

export default NavBar
