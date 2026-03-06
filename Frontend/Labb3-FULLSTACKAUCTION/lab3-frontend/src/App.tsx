import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Navbar from "./Components/Navbar";

import AuctionPage from "./Pages/AuctionPage/AuctionPage";
import AuctionDetailsPage from "./Pages/AuctionDetailsPage/AuctionDetailsPage";
import RegisterPage from "./Pages/RegisterPage/RegisterPage";
import LoginPage from "./Pages/LoginPage/LoginPage";
import CreateAuctionPage from "./Pages/CreateAuctionPage/CreateAuctionPage";
function App() {

  return (
    <Router>

      <Navbar />

      <Routes>

        {/* Home / Auctions */}
        <Route path="/" element={<AuctionPage />} />

        {/* Auction details */}
        <Route path="/auction/:id" element={<AuctionDetailsPage />} />

        {/* Register */}
        <Route path="/register" element={<RegisterPage />} />

        {/* Login */}
        <Route path="/login" element={<LoginPage />} />

        {/* Create Auction */}
        <Route path="/create-auction" element={<CreateAuctionPage />} />

      </Routes>

    </Router>
  );

}

export default App;