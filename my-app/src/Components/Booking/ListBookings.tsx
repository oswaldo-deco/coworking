import React, { useState, useEffect } from 'react';
import './ListBookings.css';

const ListBookings = () => {
  const [bookings, setBookings] = useState<any[]>([]); // Lista de reservas

  useEffect(() => {
    fetchBookings(); // Chama a função ao montar o componente
  }, []);

  // Função para buscar as reservas da API
  const fetchBookings = () => {
    fetch('http://localhost:5071/bookings')
      .then((response) => response.json())
      .then((data) => {
        setBookings(data); // Atualiza o estado com as reservas
      })
      .catch((error) => console.error('Erro ao buscar reservas:', error));
  };

  return (
    <div className="list-bookings">
      <h2 className="title">Lista de Reservas</h2>
      <table className="table" cellPadding="10">
        <thead className="thead">
          <tr>
            <th>ID</th>
            <th>Data de Início</th>
            <th>Data de Término</th>
            <th>Usuário</th>
          </tr>
        </thead>
        <tbody className="tbody">
          {bookings.map((booking) => (
            <tr key={booking.id} className="row">
              <td>{booking.id}</td>
              <td>{new Date(booking.startDate).toLocaleString()}</td>
              <td>{new Date(booking.endDate).toLocaleString()}</td>
              <td>{booking.userName}</td> {/* Ajuste conforme seus dados */}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListBookings;
