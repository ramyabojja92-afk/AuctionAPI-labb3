import { Link } from "react-router-dom";
import { useAuth } from "../Context/AuthContext";
import "./Navbar.css";

export default function Navbar() {

  const { user, logout } = useAuth();

  return (
    <nav className="navbar">

      <Link to="/">Home</Link>

      <Link to="/create-auction">Create Auction</Link>

      {user ? (
        <>
          <span>Welcome {user.userName}</span>
          <button onClick={logout}>Logout</button>
        </>
      ) : (
        <>
          <Link to="/login">Login</Link>
          <Link to="/register">Register</Link>
        </>
      )}

    </nav>
  );
}