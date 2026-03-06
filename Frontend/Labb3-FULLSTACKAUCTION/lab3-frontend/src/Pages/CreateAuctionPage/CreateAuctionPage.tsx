import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "./CreateAuctionPage.css";
import { useAuth } from "../../Context/AuthContext";

export default function CreateAuctionPage() {

  const navigate = useNavigate();
  const { user } = useAuth();

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [startPrice, setStartPrice] = useState("");

  const [startDate] = useState(new Date());

  const [endDate] = useState(
    new Date(Date.now() + 7 * 24 * 60 * 60 * 1000)
  );

  // Check login when page loads
  useEffect(() => {

    if (!user) {
      alert("You must login to create an auction");
      navigate("/login");
    }

  }, [user, navigate]);

  const handleCreate = async (e: React.FormEvent) => {

    e.preventDefault();

    if (!user) {
      alert("You must login first");
      navigate("/login");
      return;
    }

    const res = await fetch("https://localhost:7253/api/auctions", {

      method: "POST",

      headers: {
        "Content-Type": "application/json"
      },

      body: JSON.stringify({
        title: title,
        description: description,
        startPrice: Number(startPrice),
        startDate: startDate,
        endDate: endDate,
        userId: user.userId
      })

    });

    if (!res.ok) {
      alert("Failed to create auction");
      return;
    }

    alert("Auction created successfully!");

    navigate("/");
  };

  return (

    <div className="create-auction">

      <h2>Create Auction</h2>

      <form onSubmit={handleCreate}>

        <input
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
        />

        <textarea
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
        />

        <input
          type="number"
          placeholder="Start price"
          value={startPrice}
          onChange={(e) => setStartPrice(e.target.value)}
          required
        />

        <button type="submit">Create Auction</button>

      </form>

    </div>
  );
}