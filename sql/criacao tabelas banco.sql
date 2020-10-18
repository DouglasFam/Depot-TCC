CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Colaboradores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) NOT NULL,
    `Login` varchar(8) NOT NULL,
    `Senha` varchar(100) NULL,
    CONSTRAINT `PK_Colaboradores` PRIMARY KEY (`Id`)
);

CREATE TABLE `Estoques` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `produtoId` int NOT NULL,
    `NomeEstoque` varchar(100) NOT NULL,
    `DataCadastro` datetime(6) NOT NULL,
    `Regiao` varchar(2) NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Estoques` PRIMARY KEY (`Id`)
);

CREATE TABLE `Fornecedores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(200) NOT NULL,
    `Documento` varchar(14) NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Fornecedores` PRIMARY KEY (`Id`)
);

CREATE TABLE `Grupos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Grupo` varchar(200) NOT NULL,
    CONSTRAINT `PK_Grupos` PRIMARY KEY (`Id`)
);

CREATE TABLE `Historicos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TipoMovimento` int NOT NULL,
    `DataMovimento` datetime NOT NULL,
    `ColaboradorId` int NOT NULL,
    `AutorizadorId` int NOT NULL,
    `RetiranteId` int NULL,
    `DepositanteId` int NULL,
    CONSTRAINT `PK_Historicos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Historicos_Colaboradores_ColaboradorId` FOREIGN KEY (`ColaboradorId`) REFERENCES `Colaboradores` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Perfis` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ColaboradorId` int NOT NULL,
    `NomePerfil` varchar(100) NOT NULL,
    CONSTRAINT `PK_Perfis` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Perfis_Colaboradores_ColaboradorId` FOREIGN KEY (`ColaboradorId`) REFERENCES `Colaboradores` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Enderecos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FornecedorId` int NOT NULL,
    `Logradouro` varchar(200) NOT NULL,
    `Numero` varchar(50) NOT NULL,
    `Complemento` varchar(100) NULL,
    `Cep` varchar(8) NOT NULL,
    `Bairro` varchar(100) NULL,
    `Cidade` varchar(100) NULL,
    `Estado` varchar(100) NULL,
    CONSTRAINT `PK_Enderecos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Enderecos_Fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `Fornecedores` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Produtos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FornecedorId` int NOT NULL,
    `EstoqueId` int NOT NULL,
    `GrupoId` int NOT NULL,
    `Nome` varchar(200) NOT NULL,
    `Descricao` varchar(1000) NOT NULL,
    `DataCadastro` datetime NOT NULL,
    `Ativo` bit NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Produtos_Estoques_EstoqueId` FOREIGN KEY (`EstoqueId`) REFERENCES `Estoques` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Produtos_Fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `Fornecedores` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Produtos_Grupos_GrupoId` FOREIGN KEY (`GrupoId`) REFERENCES `Grupos` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `HistoricoProdutos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProdutoId` int NOT NULL,
    `HistoricoId` int NOT NULL,
    CONSTRAINT `PK_HistoricoProdutos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_HistoricoProdutos_Historicos_HistoricoId` FOREIGN KEY (`HistoricoId`) REFERENCES `Historicos` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_HistoricoProdutos_Produtos_ProdutoId` FOREIGN KEY (`ProdutoId`) REFERENCES `Produtos` (`Id`) ON DELETE RESTRICT
);

CREATE UNIQUE INDEX `IX_Enderecos_FornecedorId` ON `Enderecos` (`FornecedorId`);

CREATE INDEX `IX_HistoricoProdutos_HistoricoId` ON `HistoricoProdutos` (`HistoricoId`);

CREATE INDEX `IX_HistoricoProdutos_ProdutoId` ON `HistoricoProdutos` (`ProdutoId`);

CREATE INDEX `IX_Historicos_ColaboradorId` ON `Historicos` (`ColaboradorId`);

CREATE UNIQUE INDEX `IX_Perfis_ColaboradorId` ON `Perfis` (`ColaboradorId`);

CREATE INDEX `IX_Produtos_EstoqueId` ON `Produtos` (`EstoqueId`);

CREATE INDEX `IX_Produtos_FornecedorId` ON `Produtos` (`FornecedorId`);

CREATE INDEX `IX_Produtos_GrupoId` ON `Produtos` (`GrupoId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200422145530_Initial', '3.1.3');

