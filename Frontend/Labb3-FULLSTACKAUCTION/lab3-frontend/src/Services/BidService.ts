const API_URL = "https://localhost:7253/api/bids";

export async function placeBid(bid: any, token: string) {
  const res = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`
    },
    body: JSON.stringify(bid)
  });

  return res.json();
}

export async function getBidsForAuction(auctionId: number) {
  const res = await fetch(`${API_URL}/auction/${auctionId}`);
  return res.json();
}