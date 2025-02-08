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
  `IDORDER` int NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.orders: ~13 rows (aproximadamente)
INSERT INTO `orders` (`IDORDER`, `CNPJ`, `TOTAL`, `ORDER_DATE`, `CHECK_NUMBER`, `ORDER_ACTIVE`, `ORDER_STATUS`) VALUES
	(10, '42591651000143', 30, '2024-07-09 22:27:31', 1, 1, 1),
	(30, '42591651000143', 143, '2024-08-09 11:44:03', 1, 1, 2),
	(40, '42591651000143', 143, '2024-08-09 11:45:33', 1, 1, 3),
	(50, '42591651000143', 40, '2024-08-23 11:07:48', 1, 1, 1),
	(60, '42591651000143', 123, '2025-02-05 23:34:29', 5, 1, 1),
	(70, '42591651000143', 306, '2025-02-05 23:36:40', 3, 1, 1),
	(80, '42591651000143', 246, '2025-02-05 23:37:04', 3, 1, 1),
	(90, '42591651000143', 80, '2025-02-05 23:37:30', 5, 1, 1),
	(100, '42591651000143', 30, '2025-02-05 23:37:45', 5, 1, 1),
	(110, '42591651000143', 40, '2025-02-05 23:38:05', 5, 1, 1),
	(120, '42591651000143', 70, '2025-02-05 23:54:35', 2, 1, 1),
	(130, '42591651000143', 123, '2025-02-05 23:55:28', 5, 1, 1),
	(140, '42591651000143', 123, '2025-02-05 23:55:34', 5, 1, 1),
	(150, '42591651000143', 719, '2025-02-08 02:08:51', 1, 1, 1);

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
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IDORDER` (`IDORDER`,`ITEM`),
  KEY `CNPJ` (`CNPJ`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `CHECK_NUMBER` (`CHECK_NUMBER`),
  CONSTRAINT `order_details_ibfk_2` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`),
  CONSTRAINT `order_details_ibfk_3` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `order_details_ibfk_4` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`),
  CONSTRAINT `order_details_ibfk_5` FOREIGN KEY (`IDORDER`) REFERENCES `orders` (`IDORDER`)
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~19 rows (aproximadamente)
INSERT INTO `order_details` (`ID`, `IDORDER`, `CNPJ`, `IDPRODUCT`, `ITEM`, `CHECK_NUMBER`, `PRICE`, `ORDER_DATE`) VALUES
	(45, 10, '42591651000143', 1, 1, 1, 30, '2024-07-09 22:27:31'),
	(46, 30, '42591651000143', 7, 1, 1, 123, '2024-08-09 11:44:03'),
	(47, 30, '42591651000143', 4, 2, 1, 20, '2024-08-09 11:44:03'),
	(48, 40, '42591651000143', 7, 1, 1, 123, '2024-08-09 11:45:33'),
	(49, 40, '42591651000143', 4, 2, 1, 20, '2024-08-09 11:45:33'),
	(50, 50, '42591651000143', 3, 1, 1, 40, '2024-08-23 11:07:48'),
	(51, 60, '42591651000143', 7, 1, 5, 123, '2025-02-05 23:34:29'),
	(52, 70, '42591651000143', 1, 1, 3, 30, '2025-02-05 23:36:40'),
	(53, 70, '42591651000143', 7, 2, 3, 123, '2025-02-05 23:36:40'),
	(54, 70, '42591651000143', 1, 3, 3, 30, '2025-02-05 23:36:40'),
	(55, 70, '42591651000143', 7, 4, 3, 123, '2025-02-05 23:36:40'),
	(56, 80, '42591651000143', 7, 1, 3, 123, '2025-02-05 23:37:04'),
	(57, 80, '42591651000143', 7, 2, 3, 123, '2025-02-05 23:37:04'),
	(58, 90, '42591651000143', 8, 1, 5, 40, '2025-02-05 23:37:30'),
	(59, 90, '42591651000143', 8, 2, 5, 40, '2025-02-05 23:37:30'),
	(60, 100, '42591651000143', 1, 1, 5, 30, '2025-02-05 23:37:45'),
	(61, 110, '42591651000143', 3, 1, 5, 40, '2025-02-05 23:38:05'),
	(62, 120, '42591651000143', 3, 1, 2, 40, '2025-02-05 23:54:35'),
	(63, 120, '42591651000143', 1, 2, 2, 30, '2025-02-05 23:54:35'),
	(64, 130, '42591651000143', 7, 1, 5, 123, '2025-02-05 23:55:28'),
	(65, 140, '42591651000143', 7, 1, 5, 123, '2025-02-05 23:55:34'),
	(66, 150, '42591651000143', 7, 1, 1, 123, '2025-02-08 02:08:51'),
	(67, 150, '42591651000143', 7, 2, 1, 123, '2025-02-08 02:08:51'),
	(68, 150, '42591651000143', 3, 3, 1, 40, '2025-02-08 02:08:51'),
	(69, 150, '42591651000143', 8, 4, 1, 40, '2025-02-08 02:08:51'),
	(70, 150, '42591651000143', 1, 5, 1, 30, '2025-02-08 02:08:51'),
	(71, 150, '42591651000143', 1, 6, 1, 30, '2025-02-08 02:08:51'),
	(72, 150, '42591651000143', 1, 7, 1, 30, '2025-02-08 02:08:51'),
	(73, 150, '42591651000143', 1, 8, 1, 30, '2025-02-08 02:08:51'),
	(74, 150, '42591651000143', 1, 9, 1, 30, '2025-02-08 02:08:51'),
	(75, 150, '42591651000143', 1, 10, 1, 30, '2025-02-08 02:08:51'),
	(76, 150, '42591651000143', 1, 11, 1, 30, '2025-02-08 02:08:51'),
	(77, 150, '42591651000143', 1, 12, 1, 30, '2025-02-08 02:08:51'),
	(78, 150, '42591651000143', 1, 13, 1, 30, '2025-02-08 02:08:51'),
	(79, 150, '42591651000143', 7, 14, 1, 123, '2025-02-08 02:08:51');

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

-- Copiando dados para a tabela menusystem.products_ingrdients: ~3 rows (aproximadamente)
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
