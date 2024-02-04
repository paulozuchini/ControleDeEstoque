USE [controledeestoque]
GO
-- Inserindo dados de Clientes
INSERT INTO Clientes (Nome, Email, Telefone)
VALUES
    ('João Silva', 'joao@example.com', '123456789'),
    ('Maria Souza', 'maria@example.com', '987654321'),
    ( 'Carlos Oliveira', 'carlos@example.com', '111222333');
GO

-- Inserindo dados de Itens no Estoque
INSERT INTO Estoque (NomeProduto, Quantidade)
VALUES
    ('TV LED 50 polegadas', 20),
    ('Notebook Dell Inspiron 15', 15),
    ('PlayStation 5', 10),
    ('iPhone 13 Pro', 25),
    ('Samsung Galaxy S21', 30),
    ('Xbox Series X', 12),
    ('MacBook Air', 8),
    ('Smartwatch Apple Watch', 20),
    ('Câmera Digital Canon EOS', 18),
    ('Fone de Ouvido Bluetooth Sony', 35);
GO

-- Inserindo dados de Pedidos
INSERT INTO Pedidos (ClienteID, DataPedido, StatusPedido)
VALUES
    (1, '2024-01-15', 'Faturado'),
    (1, '2024-01-20', 'Em andamento'),
    (1, '2024-01-25', 'Cancelado'),
    (2, '2024-01-18', 'Faturado'),
    (2, '2024-01-22', 'Faturado'),
    (3, '2024-01-20', 'Em andamento');
GO

-- Inserindo dados de Itens do Pedido
INSERT INTO ItensPedido (PedidoID, ItemID, Quantidade)
VALUES
    (1, 1, 2),
    (1, 2, 1),
    (2, 4, 1),
    (2, 5, 2),
    (3, 3, 1),
    (3, 6, 1),
    (4, 8, 1),
    (4, 9, 2),
    (5, 7, 1),
    (5, 10, 1),
    (6, 2, 1),
    (6, 3, 1);
GO

-- Inserindo dados de Faturamento apenas para pedidos faturados
INSERT INTO Faturamento (PedidoID, DataFaturamento, Observacao, ValorTotal)
VALUES
    (1, '2024-01-15', 'Pedido faturado com sucesso.', 5000.00),
    (4, '2024-01-18', 'Pedido faturado com sucesso.', 1500.00),
    (5, '2024-01-22', 'Pedido faturado com sucesso.', 1200.00);
GO
