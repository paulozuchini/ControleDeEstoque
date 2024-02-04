USE [controledeestoque]
GO
-- Inserindo dados de Clientes
INSERT INTO Clientes (ClienteID, Nome, Email, Telefone)
VALUES
    (1, 'João Silva', 'joao@example.com', '123456789'),
    (2, 'Maria Souza', 'maria@example.com', '987654321'),
    (3, 'Carlos Oliveira', 'carlos@example.com', '111222333');
GO

-- Inserindo dados de Itens no Estoque
INSERT INTO Estoque (ItemID, NomeProduto, Quantidade)
VALUES
    (1, 'TV LED 50 polegadas', 20),
    (2, 'Notebook Dell Inspiron 15', 15),
    (3, 'PlayStation 5', 10),
    (4, 'iPhone 13 Pro', 25),
    (5, 'Samsung Galaxy S21', 30),
    (6, 'Xbox Series X', 12),
    (7, 'MacBook Air', 8),
    (8, 'Smartwatch Apple Watch', 20),
    (9, 'Câmera Digital Canon EOS', 18),
    (10, 'Fone de Ouvido Bluetooth Sony', 35);
GO

-- Inserindo dados de Pedidos
INSERT INTO Pedidos (PedidoID, ClienteID, DataPedido, StatusPedido)
VALUES
    (1, 1, '2024-01-15', 'Faturado'),
    (2, 1, '2024-01-20', 'Em andamento'),
    (3, 1, '2024-01-25', 'Cancelado'),
    (4, 2, '2024-01-18', 'Faturado'),
    (5, 2, '2024-01-22', 'Faturado'),
    (6, 3, '2024-01-20', 'Em andamento');
GO

-- Inserindo dados de Itens do Pedido
INSERT INTO ItensPedido (ItemPedidoID, PedidoID, ItemID, Quantidade)
VALUES
    (1, 1, 1, 2),
    (2, 1, 2, 1),
    (3, 2, 4, 1),
    (4, 2, 5, 2),
    (5, 3, 3, 1),
    (6, 3, 6, 1),
    (7, 4, 8, 1),
    (8, 4, 9, 2),
    (9, 5, 7, 1),
    (10, 5, 10, 1),
    (11, 6, 2, 1),
    (12, 6, 3, 1);
GO

-- Inserindo dados de Faturamento apenas para pedidos faturados
INSERT INTO Faturamento (PedidoID, DataFaturamento, Observacao, ValorTotal)
VALUES
    (1, '2024-01-15', 'Pedido faturado com sucesso.', 5000.00),
    (4, '2024-01-18', 'Pedido faturado com sucesso.', 1500.00),
    (5, '2024-01-22', 'Pedido faturado com sucesso.', 1200.00);
GO
