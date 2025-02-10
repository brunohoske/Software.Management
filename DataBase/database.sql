-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.2.0 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para menusystem
CREATE DATABASE IF NOT EXISTS `menusystem` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `menusystem`;

-- Copiando estrutura para tabela menusystem.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `IDCATEGORY` int NOT NULL AUTO_INCREMENT,
  `NAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DESCRIPTION` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CNPJ` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDCATEGORY`) USING BTREE,
  KEY `companys_fk` (`CNPJ`),
  CONSTRAINT `companys_fk` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.categories: ~2 rows (aproximadamente)
INSERT INTO `categories` (`IDCATEGORY`, `NAME`, `DESCRIPTION`, `CNPJ`) VALUES
	(1, 'Carne', 'Hamburguers de carne', '42591651000143'),
	(2, 'Frango', 'Hamburguers de Frango', '42591651000143');

-- Copiando estrutura para tabela menusystem.checks
CREATE TABLE IF NOT EXISTS `checks` (
  `CHECK_NUMBER` int NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`CHECK_NUMBER`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `checks_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.checks: ~6 rows (aproximadamente)
INSERT INTO `checks` (`CHECK_NUMBER`, `CNPJ`) VALUES
	(1, '42591651000143'),
	(2, '42591651000143'),
	(3, '42591651000143'),
	(4, '42591651000143'),
	(5, '42591651000143'),
	(6, '42591651000143');

-- Copiando estrutura para tabela menusystem.companys
CREATE TABLE IF NOT EXISTS `companys` (
  `CNPJ` varchar(20) NOT NULL,
  `COMPANY_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.companys: ~2 rows (aproximadamente)
INSERT INTO `companys` (`CNPJ`, `COMPANY_NAME`) VALUES
	('42591651000143', 'MCDONALDS'),
	('53060216000109', 'BURGUERKING');

-- Copiando estrutura para tabela menusystem.coupon
CREATE TABLE IF NOT EXISTS `coupon` (
  `COUPONID` int NOT NULL AUTO_INCREMENT,
  `CODE` varchar(12) NOT NULL DEFAULT '0',
  `DISCOUNT` int NOT NULL DEFAULT (0),
  `ACTIVE` smallint DEFAULT '1',
  `CNPJ` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`COUPONID`),
  KEY `FK2_CNPJ` (`CNPJ`),
  CONSTRAINT `FK2_CNPJ` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.coupon: ~2 rows (aproximadamente)
INSERT INTO `coupon` (`COUPONID`, `CODE`, `DISCOUNT`, `ACTIVE`, `CNPJ`) VALUES
	(2, 'BRUNO50OFF', 50, 1, '42591651000143'),
	(3, '40OFF', 40, 1, '42591651000143');

-- Copiando estrutura para tabela menusystem.discount
CREATE TABLE IF NOT EXISTS `discount` (
  `ID_DISCOUNT` int NOT NULL AUTO_INCREMENT,
  `DISCOUNT_PERCENTAGE` float NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  `IDPRODUCT` int NOT NULL,
  PRIMARY KEY (`ID_DISCOUNT`),
  KEY `CNPJ` (`CNPJ`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  CONSTRAINT `discount_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`),
  CONSTRAINT `discount_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.discount: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela menusystem.ingredients
CREATE TABLE IF NOT EXISTS `ingredients` (
  `IdIngredient` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Description` varchar(250) DEFAULT NULL,
  `Cnpj` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`IdIngredient`) USING BTREE,
  KEY `FK_CNPJ` (`Cnpj`),
  CONSTRAINT `FK_CNPJ` FOREIGN KEY (`Cnpj`) REFERENCES `companys` (`CNPJ`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.ingredients: ~3 rows (aproximadamente)
INSERT INTO `ingredients` (`IdIngredient`, `Name`, `Description`, `Cnpj`) VALUES
	(1, 'Carne', '130g de hambúrguer', '42591651000143'),
	(2, 'Frango', '140g de Frango', '42591651000143'),
	(3, 'Picles', '4 fatias de picles', '42591651000143');

-- Copiando estrutura para tabela menusystem.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `IDORDER` int NOT NULL AUTO_INCREMENT,
  `CNPJ` varchar(20) NOT NULL,
  `TOTAL` float NOT NULL,
  `ORDER_DATE` datetime NOT NULL,
  `CHECK_NUMBER` int NOT NULL,
  `ORDER_ACTIVE` smallint DEFAULT NULL,
  `ORDER_STATUS` int DEFAULT NULL,
  PRIMARY KEY (`IDORDER`),
  KEY `CHECK_NUMBER` (`CHECK_NUMBER`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`),
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.orders: ~0 rows (aproximadamente)
INSERT INTO `orders` (`IDORDER`, `CNPJ`, `TOTAL`, `ORDER_DATE`, `CHECK_NUMBER`, `ORDER_ACTIVE`, `ORDER_STATUS`) VALUES
	(15, '42591651000143', 160, '2025-02-10 00:11:37', 1, 1, 1),
	(16, '42591651000143', 363, '2025-02-10 00:12:34', 1, 1, 1);

-- Copiando estrutura para tabela menusystem.order_details
CREATE TABLE IF NOT EXISTS `order_details` (
  `ID` int unsigned NOT NULL AUTO_INCREMENT,
  `IDORDER` int NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  `IDPRODUCT` int NOT NULL,
  `ITEM` int NOT NULL,
  `CHECK_NUMBER` int NOT NULL,
  `PRICE` float NOT NULL,
  `ORDER_DATE` datetime NOT NULL,
  `Note` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IDORDER` (`IDORDER`,`ITEM`),
  KEY `CNPJ` (`CNPJ`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `CHECK_NUMBER` (`CHECK_NUMBER`),
  CONSTRAINT `order_details_ibfk_2` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`),
  CONSTRAINT `order_details_ibfk_3` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `order_details_ibfk_4` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=218 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~11 rows (aproximadamente)
INSERT INTO `order_details` (`ID`, `IDORDER`, `CNPJ`, `IDPRODUCT`, `ITEM`, `CHECK_NUMBER`, `PRICE`, `ORDER_DATE`, `Note`) VALUES
	(207, 15, '42591651000143', 3, 1, 1, 40, '2025-02-10 00:11:37', ''),
	(208, 15, '42591651000143', 3, 2, 1, 40, '2025-02-10 00:11:37', ''),
	(209, 15, '42591651000143', 3, 3, 1, 40, '2025-02-10 00:11:37', ''),
	(210, 15, '42591651000143', 3, 4, 1, 40, '2025-02-10 00:11:37', ''),
	(211, 16, '42591651000143', 3, 1, 1, 40, '2025-02-10 00:12:34', ''),
	(212, 16, '42591651000143', 7, 2, 1, 123, '2025-02-10 00:12:34', ''),
	(213, 16, '42591651000143', 3, 3, 1, 40, '2025-02-10 00:12:34', 'Sem Picles\n\n'),
	(214, 16, '42591651000143', 3, 4, 1, 40, '2025-02-10 00:12:34', 'Sem Picles\n\n'),
	(215, 16, '42591651000143', 3, 5, 1, 40, '2025-02-10 00:12:34', 'Sem Picles\n\n'),
	(216, 16, '42591651000143', 3, 6, 1, 40, '2025-02-10 00:12:34', 'Sem Picles\n\n'),
	(217, 16, '42591651000143', 3, 7, 1, 40, '2025-02-10 00:12:34', 'Sem Picles\n\n');

-- Copiando estrutura para tabela menusystem.products
CREATE TABLE IF NOT EXISTS `products` (
  `IDPRODUCT` int NOT NULL AUTO_INCREMENT,
  `IDCATEGORY` int DEFAULT NULL,
  `CNPJ` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PRODUCT_NAME` varchar(40) NOT NULL,
  `DESCRIPTION` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PRICE` float NOT NULL,
  `ACTIVE` int NOT NULL,
  `KCAL` float DEFAULT (0),
  `IMAGE` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`IDPRODUCT`),
  KEY `CNPJ` (`CNPJ`),
  KEY `categories_fk` (`IDCATEGORY`),
  CONSTRAINT `categories_fk` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`) ON DELETE SET NULL,
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products: ~7 rows (aproximadamente)
INSERT INTO `products` (`IDPRODUCT`, `IDCATEGORY`, `CNPJ`, `PRODUCT_NAME`, `DESCRIPTION`, `PRICE`, `ACTIVE`, `KCAL`, `IMAGE`) VALUES
	(1, 2, '42591651000143', 'McOferta McChicken', 'Um delicioso hamburguer de frango', 30, 1, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(2, NULL, '53060216000109', 'BK Whopper', 'Um delicioso hamburguer', 40, 1, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(3, 1, '42591651000143', 'McOferta BigMac', 'Dois hambúrgueres (100% carne bovina), alface americana, queijo processado sabor cheddar, molho especial, cebola, picles e pão com gergelim.', 40, 0, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(4, 1, '42591651000143', 'McLancheFeliz', 'O melhor para criançada', 20.2, 1, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(5, NULL, '53060216000109', 'BK Whopper Plantas', 'Um delicioso hamburguer com o dobro de salada', 35.99, 1, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(7, 2, '42591651000143', 'teste', 'teste', 123, 1, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png'),
	(8, 1, '42591651000143', 'BK Whopper', 'Um delicioso hamburguer', 40, 0, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png');

-- Copiando estrutura para tabela menusystem.products_ingrdients
CREATE TABLE IF NOT EXISTS `products_ingrdients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idProduct` int NOT NULL,
  `idIngredient` int NOT NULL,
  `Cnpj` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idProduct` (`idProduct`),
  KEY `idIngredient` (`idIngredient`),
  KEY `FK3_CNPJ` (`Cnpj`),
  CONSTRAINT `FK3_CNPJ` FOREIGN KEY (`Cnpj`) REFERENCES `companys` (`CNPJ`) ON DELETE CASCADE,
  CONSTRAINT `products_ingrdients_ibfk_1` FOREIGN KEY (`idProduct`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_ingrdients_ibfk_2` FOREIGN KEY (`idIngredient`) REFERENCES `ingredients` (`IdIngredient`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_ingrdients: ~2 rows (aproximadamente)
INSERT INTO `products_ingrdients` (`id`, `idProduct`, `idIngredient`, `Cnpj`) VALUES
	(5, 1, 1, '42591651000143'),
	(6, 1, 2, '42591651000143'),
	(7, 3, 3, '42591651000143');

-- Copiando estrutura para tabela menusystem.users
CREATE TABLE IF NOT EXISTS `users` (
  `IDUSER` int NOT NULL AUTO_INCREMENT,
  `NAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SENHA` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  `ADMIN` smallint NOT NULL DEFAULT (0),
  `USER_ACTIVE` int DEFAULT NULL,
  PRIMARY KEY (`IDUSER`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.users: ~3 rows (aproximadamente)
INSERT INTO `users` (`IDUSER`, `NAME`, `SENHA`, `CNPJ`, `ADMIN`, `USER_ACTIVE`) VALUES
	(1, 'BRUNO', '1234', '42591651000143', 1, 1),
	(4, 'TETE5', '1234', '42591651000143', 1, 1),
	(5, 'TESTE', '12345', '42591651000143', 0, 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
