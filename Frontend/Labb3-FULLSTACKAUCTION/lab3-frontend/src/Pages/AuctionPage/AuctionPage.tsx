import { useEffect, useState } from "react";
import AuctionList from "../../Components/AuctionList";
import "./AuctionPage.css";

import { getAllAuctions } from "../../Services/AuctionService";
import type { Auction } from "../../Types/Auction";

export default function AuctionPage() {

  const [auctions, setAuctions] = useState<Auction[]>([]);

  useEffect(() => {
    getAllAuctions().then(data => setAuctions(data));
  }, []);

  return (
    <div className="auction-page">
      <h1>TV Auctions</h1>

      <AuctionList auctions={auctions} />
    </div>
  );
}