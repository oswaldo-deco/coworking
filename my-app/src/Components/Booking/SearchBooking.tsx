import React, { useState } from 'react';
import './SearchBooking.css';

function SearchBooking() {
  const [bookingId, setBookingId] = useState('');
  const [bookingData, setBookingData] = useState<any>(null);
  const [message, setMessage] = useState('');

  const handleSearch = () => {
    fetch(`http://localhost:5071/bookings/${bookingId}`, {
      method: 'GET',
    })
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Falha ao encontrar reserva.');
        }
      })
      .then((data) => {
        setBookingData(data);
        setMessage('Reserva Encontrada!');
      })
      .catch((error) => {
        setMessage(error.message);
        setBookingData(null);
      });
  };

  return (
    <div className="booking-container">
      <h2 className="title">Buscar Reserva</h2>
      <form className="form">
        <input
          type="text"
          placeholder="ID da Reserva"
          value={bookingId}
          onChange={(e) => setBookingId(e.target.value)}
          className="input"
        />
        <button type="button" onClick={handleSearch} className="button">Buscar</button>
      </form>
      {message && <p className="message">{message}</p>}
      {bookingData && (
        <div className="booking-details">
          <p><strong>ID:</strong> {bookingData.id}</p>
          <p><strong>Usuário ID:</strong> {bookingData.userId}</p>
          <p><strong>Data de Início:</strong> {new Date(bookingData.startDate).toLocaleDateString()}</p>
          <p><strong>Data de Fim:</strong> {new Date(bookingData.endDate).toLocaleDateString()}</p>
        </div>
      )}
    </div>
  );
}

export default SearchBooking;