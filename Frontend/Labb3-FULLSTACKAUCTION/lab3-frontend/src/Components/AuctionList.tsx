import AuctionCard from "./AuctionCard";
import "./AuctionList.css";

interface Auction {
  auctionId: number
  title: string
  currentPrice: number
  endDate: string
}

interface AuctionListProps {
  auctions: Auction[]
}

const AuctionList = ({ auctions }: AuctionListProps) => {

  return (

    <div className="auction-list">

      {auctions.map((auction) => (

        <AuctionCard
          key={auction.auctionId}
          auctionId={auction.auctionId}
          title={auction.title}
          price={auction.currentPrice}
          endDate={auction.endDate}
        />

      ))}

    </div>

  );
}

export default AuctionList;