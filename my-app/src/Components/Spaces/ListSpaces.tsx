import { useEffect, useState } from 'react';
import { Space } from '../../Models/Space'; // Supondo que o modelo Space esteja em Models
import './ListSpaces.css'; // Arquivo de estilo CSS

const ListSpaces = () => {
  const [spaces, setSpaces] = useState<Space[]>([]); // Lista de espaços

  useEffect(() => {
    fetchSpaces(); // Chama a função para buscar os espaços quando o componente monta
  }, []);

  // Função para buscar os espaços da API
  const fetchSpaces = () => {
    fetch("http://localhost:5071/spaces") // Endpoint para buscar os espaços
      .then((response) => response.json())
      .then((data) => {
        setSpaces(data); // Armazena os espaços no estado
      })
      .catch((error) => console.error("Erro ao buscar espaços:", error));
  };

  return (
    <div className="spaces-list">
      <h2 className="title">Lista de Espaços</h2>
      <table className="table" cellPadding="10">
        <thead className="thead">
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Capacidade</th>
            <th>Preço por Hora</th>
          </tr>
        </thead>
        <tbody className="tbody">
          {spaces.map((space) => (
            <tr key={space.id} className="row">
              <td>{space.id}</td>
              <td>{space.name}</td>
              <td>{space.capacity}</td>
              <td>{space.pricePerHour}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListSpaces;
