import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../Context/AuthContext";
import "./LoginPage.css";

export default function LoginPage() {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();
  const { login } = useAuth();

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    try {

      const res = await fetch("https://localhost:7253/api/users/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          email,
          password
        })
      });

      if (!res.ok) {
        alert("Invalid login");
        return;
      }

      const data = await res.json();

      // store user in context
      login({
        userId: data.userId,
        userName: data.userName
      });

      navigate("/");

    } catch (error) {
      console.error("Login error:", error);
    }
  };

  return (
    <div className="login-page">

      <h1>Login</h1>

      <form onSubmit={handleLogin} className="login-form">

        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        <button type="submit">Login</button>

      </form>

    </div>
  );
}