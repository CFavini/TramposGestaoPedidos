USE GestaoDePedidos;

CREATE TABLE OrderStatus (
    Id INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL UNIQUE
);

-- Inserindo os valores possíveis para o status do pedido
INSERT INTO OrderStatus (Id, Name) VALUES
(1, 'Pendente'),
(2, 'Processando'),
(3, 'Enviado'),
(4, 'Entregue'),
(5, 'Cancelado');