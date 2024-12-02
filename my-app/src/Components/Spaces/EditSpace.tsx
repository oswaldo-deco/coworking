import React, { useState, useEffect } from 'react';
import './EditSpace.css';

function EditSpace() {
  const [spaceId, setSpaceId] = useState('');
  const [spaceName, setSpaceName] = useState('');
  const [capacity, setCapacity] = useState<number | ''>('');
  const [pricePerHour, setPricePerHour] = useState<number | ''>('');
  const [message, setMessage] = useState('');
  const [spaceFound, setSpaceFound] = useState(false);

  const handleSearch = () => {
    fetch(`http://localhost:5071/spaces/${spaceId}`, {
      method: 'GET',
    })
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Falha ao encontrar o espaço.');
        }
      })
      .then((data) => {
        setSpaceName(data.name);
        setCapacity(data.capacity);
        setPricePerHour(data.pricePerHour);
        setSpaceFound(true);
        setMessage('');
      })
      .catch((error) => {
        setMessage(error.message);
        setSpaceFound(false);
      });
  };

  const handleEdit = (e: React.FormEvent) => {
    e.preventDefault();

    const updatedSpace = {
      name: spaceName,
      capacity: capacity,
      pricePerHour: pricePerHour,
    };

    fetch(`http://localhost:5071/spaces/${spaceId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedSpace),
    })
      .then((response) => {
        if (response.ok) {
          setMessage('Espaço atualizado com sucesso!');
          setSpaceFound(false);
        } else {
          setMessage('Falha ao atualizar espaço.');
        }
      })
      .catch(() => {
        setMessage('Erro ao tentar se comunicar com a API.');
      });
  };

  return (
    <div className="edit-space">
      <h2 className="title">Editar Espaço</h2>
      <form className="form">
        <div className="form-group">
          <label htmlFor="spaceId">ID do Espaço</label>
          <input
            type="text"
            id="spaceId"
            value={spaceId}
            onChange={(e) => setSpaceId(e.target.value)}
            className="input"
          />
          <button type="button" onClick={handleSearch} className="button">
            Buscar
          </button>
        </div>
      </form>
      {message && <p className="message">{message}</p>}
      {spaceFound && (
        <form className="form" onSubmit={handleEdit}>
          <div className="form-group">
            <label htmlFor="spaceName">Nome do Espaço</label>
            <input
              type="text"
              id="spaceName"
              value={spaceName}
              onChange={(e) => setSpaceName(e.target.value)}
              required
              className="input"
            />
          </div>
          <div className="form-group">
            <label htmlFor="capacity">Capacidade</label>
            <input
              type="number"
              id="capacity"
              value={capacity}
              onChange={(e) => setCapacity(Number(e.target.value))}
              required
              className="input"
            />
          </div>
          <div className="form-group">
            <label htmlFor="pricePerHour">Preço por Hora (R$)</label>
            <input
              type="number"
              id="pricePerHour"
              step="0.01"
              value={pricePerHour}
              onChange={(e) => setPricePerHour(Number(e.target.value))}
              required
              className="input"
            />
          </div>
          <button type="submit" className="button">
            Atualizar
          </button>
        </form>
      )}
    </div>
  );
}

export default EditSpace;
