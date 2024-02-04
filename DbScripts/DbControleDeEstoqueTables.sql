USE [controledeestoque]
GO

-- Tabela de Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefone VARCHAR(15)
);
GO
-- Tabela de Itens no Estoque
CREATE TABLE Estoque (
    ItemID INT PRIMARY KEY,
    NomeProduto VARCHAR(100) NOT NULL,
    Quantidade INT NOT NULL
);
GO
-- Tabela de Pedidos
CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY,
    ClienteID INT REFERENCES Clientes(ClienteID) NOT NULL,
    DataPedido DATE NOT NULL,
    StatusPedido VARCHAR(20) NOT NULL, -- Pode ser 'Em andamento', 'Faturado' ou 'Cancelado'
    CONSTRAINT CHK_StatusPedido CHECK (StatusPedido IN ('Em andamento', 'Faturado', 'Cancelado'))
);
GO
-- Tabela de Itens do Pedido
CREATE TABLE ItensPedido (
    ItemPedidoID INT PRIMARY KEY,
    PedidoID INT REFERENCES Pedidos(PedidoID) NOT NULL,
    ItemID INT REFERENCES Estoque(ItemID) NOT NULL,
    Quantidade INT NOT NULL,
    CONSTRAINT CHK_QuantidadePositiva CHECK (Quantidade > 0)
);
GO
-- Tabela de Faturamento
CREATE TABLE Faturamento (
    FaturamentoID INT PRIMARY KEY IDENTITY,
    PedidoID INT REFERENCES Pedidos(PedidoID) NOT NULL,
    DataFaturamento DATE NOT NULL,
    Observacao VARCHAR(255),
    ValorTotal DECIMAL(10, 2) NOT NULL
);
GO
-- Tabela de Relatório de Pedidos por Dia
CREATE VIEW RelatorioPedidosPorDia AS
SELECT
    p.DataPedido,
    c.ClienteID,
    c.Nome AS NomeCliente,
    p.PedidoID,
    p.StatusPedido,
    ip.ItemID,
    e.NomeProduto,
    ip.Quantidade
FROM
    Pedidos p
    JOIN Clientes c ON p.ClienteID = c.ClienteID
    LEFT JOIN ItensPedido ip ON p.PedidoID = ip.PedidoID
    LEFT JOIN Estoque e ON ip.ItemID = e.ItemID;