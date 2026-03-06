import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "./AuctionDetailsPage.css";
import { useAuth } from "../../Context/AuthContext";

export default function AuctionDetailsPage() {

  const { id } = useParams();

  const [auction, setAuction] = useState<any>(null);
  const [bids, setBids] = useState<any[]>([]);
  const [bidAmount, setBidAmount] = useState("");

  const { user } = useAuth();
  const userId = user?.userId;

  useEffect(() => {
    loadAuction();
    loadBids();
  }, [id]);

  const loadAuction = async () => {
    const res = await fetch(`https://localhost:7253/api/auctions/${id}`);
    const data = await res.json();
    setAuction(data);
  };

  const loadBids = async () => {
    const res = await fetch(`https://localhost:7253/api/bids/auction/${id}`);
    const data = await res.json();
    setBids(data);
  };

  const placeBid = async () => {

    const bidValue = Number(bidAmount);

    if (!bidValue) {
      alert("Enter a bid amount");
      return;
    }

    // prevent lower bids
    if (bidValue <= auction.currentPrice) {
      alert("Bid must be higher than the current price");
      return;
    }

    const res = await fetch("https://localhost:7253/api/bids", {

      method: "POST",

      headers: {
        "Content-Type": "application/json"
      },

      body: JSON.stringify({
       auctionId: Number(id),
       userId: user?.userId,
       amount: bidValue
      })

    });

    if (!res.ok) {
      alert("Failed to place bid");
      return;
    }

    alert("Bid placed successfully");

    // reload auction to update current price
    await loadAuction();

    // reload bids list
    await loadBids();

    setBidAmount("");
  };

  if (!auction) return <p>Loading...</p>;

  const isOwner = userId && auction.userId === userId;

  return (

    <div className="auction-details">

      <h1>{auction.title}</h1>

      <p>{auction.description}</p>

      <p>
        <strong>Current Price:</strong> {auction.currentPrice}
      </p>

      <p>
        <strong>Ends:</strong>{" "}
        {new Date(auction.endDate).toLocaleString()}
      </p>

      <h2>Place Bid</h2>

      {isOwner ? (

        <p className="bid-warning">
          You cannot bid on your own auction.
        </p>

      ) : (

        <>

          <input
            type="number"
            placeholder="Enter your bid"
            value={bidAmount}
            onChange={(e) => setBidAmount(e.target.value)}
          />

          <button onClick={placeBid}>
            Place Bid
          </button>

        </>

      )}

      <h2>Bids</h2>

      {bids.length === 0 && <p>No bids yet</p>}

      {bids.map((bid: any) => (

        <div key={bid.bidId} className="bid-item">

          <p><strong>User ID:</strong> {bid.userId}</p>
          <p><strong>Amount:</strong> {bid.amount}</p>

        </div>

      ))}

    </div>
  );
}