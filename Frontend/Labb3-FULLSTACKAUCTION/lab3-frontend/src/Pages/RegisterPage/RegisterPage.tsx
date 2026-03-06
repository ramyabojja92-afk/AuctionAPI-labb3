import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./RegisterPage.css";

export default function RegisterPage(){

  const navigate = useNavigate();

  const [name,setName] = useState("");
  const [email,setEmail] = useState("");
  const [password,setPassword] = useState("");

  const handleRegister = async (e:any) => {

    e.preventDefault();

   const response = await fetch("https://localhost:7253/api/users/register",{
  method:"POST",
  headers:{
    "Content-Type":"application/json"
  },
  body:JSON.stringify({
    name:name,
    email:email,
    password:password
  })
});

if(response.ok){
  alert("User created");
  navigate("/login");
}else{
  alert("Register failed");
}

  }

  return(

    <div className="register-page">

      <h2>Create Account</h2>

      <form onSubmit={handleRegister}>

        <input placeholder="Name"
        value={name}
        onChange={(e)=>setName(e.target.value)} />

        <input placeholder="Email"
        value={email}
        onChange={(e)=>setEmail(e.target.value)} />

        <input type="password"
        placeholder="Password"
        value={password}
        onChange={(e)=>setPassword(e.target.value)} />

        <button type="submit">Register</button>

      </form>

    </div>

  )
}