import React from "react";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import UserList from "./Components/Usuario/UserList";
import RegisterUser from "./Components/Usuario/RegisterUser";
import DeleteUser from "./Components/Usuario/DeletUser";
import EditUser from "./Components/Usuario/EditUser";
import UserSearch from "./Components/Usuario/UserSearch";
import UserPage from "./Components/Usuario/UserPage";
import './Web.css';
import PaymentPage from "./Components/Payments/PaymentPage";
import SearchPayment from "./Components/Payments/SearchPayment";
import RegisterPayment from "./Components/Payments/RegisterPayment";
import DeletePayment from "./Components/Payments/DeletPayment";
import EditPayment from "./Components/Payments/EditPayment";
import BookingPage from "./Components/Booking/Bookingpage";
import SearchBooking from "./Components/Booking/SearchBooking";
import RegisterBooking from "./Components/Booking/RegisterBooking";
import EditBooking from "./Components/Booking/EditBooking";
import DeleteBooking from "./Components/Booking/DeleteBooking";
import ListBookings from "./Components/Booking/ListBookings";
import SpacePage from "./Components/Spaces/SpacePage";
import RegisterSpace from "./Components/Spaces/RegisterSpace";
import EditSpace from "./Components/Spaces/EditSpace";
import DeleteSpace from "./Components/Spaces/DeleteSpace";
import ListSpaces from "./Components/Spaces/ListSpaces";


function App() {
  return (
    <div id="web-app" className="web-app">
      <BrowserRouter>
        <nav className="nav">
          <ul className="nav-list">
            <li className="nav-item">
              <Link to="/components/Usuários/UserPage" className="nav-link">Usuários</Link>
            </li>
            <li className="nav-item">
              <Link to="/components/payments/PaymentPage" className="nav-link">Pagamentos</Link>
            </li>
            <li className="nav-item">
              <Link to="/components/bookings/BookingPage" className="nav-link">Booking</Link>
            </li>
            <li className="nav-item">
              <Link to="/components/spaces/SpacePage" className="nav-link">Espaços</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          {/* Rotas de Usuários */}
          <Route path="/components/Usuários/UserPage" element={<UserPage />} />
          <Route path="/components/Usuários/UserList" element={<UserList />} />
          <Route path="/components/Usuários/UserSearch" element={<UserSearch />} />
          <Route path="/components/Usuários/RegisterUser" element={<RegisterUser />} />
          <Route path="/components/Usuários/DeletUser" element={<DeleteUser />} />
          <Route path="/components/Usuários/EditUser" element={<EditUser />} />
          
          {/* Rotas de Pagamentos */}
          <Route path="/components/payments/PaymentPage" element={<PaymentPage />} />
          <Route path="/components/payments/SearchPayment" element={<SearchPayment />} />
          <Route path="/components/payments/RegisterPayment" element={<RegisterPayment />} />
          <Route path="/components/payments/DeletPayment" element={<DeletePayment />} />
          <Route path="/components/payments/EditPayment" element={<EditPayment />} />

          {/* Rotas de Bookings */}
          <Route path="/components/bookings/BookingPage" element={<BookingPage />} />
          <Route path="/components/bookings/SearchBooking" element={<SearchBooking />} />
          <Route path="/components/bookings/RegisterBooking" element={<RegisterBooking />} />
          <Route path="/components/bookings/EditBooking" element={<EditBooking />} />
          <Route path="/components/bookings/DeleteBooking" element={<DeleteBooking />} />
          <Route path="/components/bookings/ListBookings" element={<ListBookings />} />

          {/* Rotas de Espaços */}
          <Route path="/components/spaces/SpacePage" element={<SpacePage />} />
          <Route path="/components/spaces/RegisterSpace" element={<RegisterSpace />} />
          <Route path="/components/spaces/EditSpace" element={<EditSpace />} />
          <Route path="/components/spaces/DeleteSpace" element={<DeleteSpace />} />
          <Route path="/components/spaces/SpaceList" element={<ListSpaces />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
