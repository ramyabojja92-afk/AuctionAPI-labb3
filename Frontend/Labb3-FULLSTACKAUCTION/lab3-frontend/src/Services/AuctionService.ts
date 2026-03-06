export async function getAllAuctions() {
  const res = await fetch("https://localhost:7253/api/auctions");
  return res.json();
}

export async function getAuctionById(id: number) {
  const res = await fetch(`https://localhost:7253/api/auctions/${id}`);
  return res.json();
}

export async function createAuction(auction: any) {
  const res = await fetch("https://localhost:7253/api/auctions", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(auction)
  });

  return res.json();
}