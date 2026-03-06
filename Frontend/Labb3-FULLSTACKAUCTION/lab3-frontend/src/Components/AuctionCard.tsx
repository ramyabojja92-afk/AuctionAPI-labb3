import { useNavigate } from "react-router-dom";
import "./AuctionCard.css";

interface AuctionCardProps {
  auctionId: number
  title: string
  price: number
  endDate: string
}

export default function AuctionCard({
  auctionId,
  title,
  price,
  endDate
}: AuctionCardProps) {

  const navigate = useNavigate();

  return (

    <div className="auction-card">

      <h3>{title}</h3>

      <p>Price: {price} SEK</p>

      <p>Ends: {new Date(endDate).toLocaleDateString()}</p>

       <button
      className="view-btn"
      onClick={() => navigate(`/auction/${auctionId}`)}
    >
      View Details
    </button>

    </div>

  );
}