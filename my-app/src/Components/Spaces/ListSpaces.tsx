import React, { useState, useEffect } from 'react';
import './ListSpaces.css';

function ListSpaces() {
  const [spaces, setSpaces] = useState<any[]>([]); // Lista de espaços
  const [message, setMessage] = useState('');

  // Função para buscar os espaços
  const fetchSpaces = () => {
    fetch('http://localhost:5071/spaces', {
      method: 'GET',
    })
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Falha ao buscar espaços.');
        }
      })
      .then((data) => {
        setSpaces(data); // Armazena os espaços no estado
        setMessage('');
      })
      .catch((error) => {
        setMessage(error.message);
      });
  };

  // Chama a função fetchSpaces quando o componente é montado
  useEffect(() => {
    fetchSpaces();
  }, []);

  return (
    <div className="list-spaces">
      <h2 className="title">Lista de Espaços</h2>
      {message && <p className="message">{message}</p>}
      <ul className="spaces-list">
        {spaces.map((space) => (
          <li key={space.id} className="space-item">
            {`Nome do Espaço: ${space.name}`}
            </li>
        ))}
      </ul>
    </div>
  );
}

export default ListSpaces;
