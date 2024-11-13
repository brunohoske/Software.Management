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
  `LOGO` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.companys: ~2 rows (aproximadamente)
INSERT INTO `companys` (`CNPJ`, `COMPANY_NAME`, `LOGO`) VALUES
	('42591651000143', 'MEATZ BURGUER\'N CIA', 'https://images.vexels.com/media/users/3/129607/isolated/preview/f526eafda1a791f4a93b1ad7c62161e5-logotipo-1-da-burgers.png?w=360'),
	('53060216000109', 'BURGUERKING', 'https://images.vexels.com/content/129606/preview/burger-logo-00d0ae.png');

-- Copiando estrutura para tabela menusystem.coupon
CREATE TABLE IF NOT EXISTS `coupon` (
  `COUPONID` int NOT NULL AUTO_INCREMENT,
  `CODE` varchar(12) NOT NULL DEFAULT '0',
  `DISCOUNT` int NOT NULL DEFAULT (0),
  `ACTIVE` smallint DEFAULT '1',
  PRIMARY KEY (`COUPONID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.coupon: ~2 rows (aproximadamente)
INSERT INTO `coupon` (`COUPONID`, `CODE`, `DISCOUNT`, `ACTIVE`) VALUES
	(2, 'BRUNO50OFF', 50, 1),
	(3, '40OFF', 40, 1),
	(4, '100OFF', 100, 0);

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.discount: ~0 rows (aproximadamente)
INSERT INTO `discount` (`ID_DISCOUNT`, `DISCOUNT_PERCENTAGE`, `CNPJ`, `IDPRODUCT`) VALUES
	(4, 10, '42591651000143', 5);

-- Copiando estrutura para tabela menusystem.feedbacks
CREATE TABLE IF NOT EXISTS `feedbacks` (
  `FEEDBACK_ID` int NOT NULL AUTO_INCREMENT,
  `IDORDER` int NOT NULL,
  `DESCRIPTION` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`FEEDBACK_ID`),
  KEY `IDORDER` (`IDORDER`),
  CONSTRAINT `feedbacks_ibfk_1` FOREIGN KEY (`IDORDER`) REFERENCES `orders` (`IDORDER`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.feedbacks: ~1 rows (aproximadamente)
INSERT INTO `feedbacks` (`FEEDBACK_ID`, `IDORDER`, `DESCRIPTION`) VALUES
	(1, 40, 'Ótima comida!!'),
	(2, 10, 'Gostei!');

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

-- Copiando dados para a tabela menusystem.orders: ~27 rows (aproximadamente)
INSERT INTO `orders` (`IDORDER`, `CNPJ`, `TOTAL`, `ORDER_DATE`, `CHECK_NUMBER`, `ORDER_ACTIVE`, `ORDER_STATUS`) VALUES
	(10, '42591651000143', 30, '2024-07-09 22:27:31', 1, 0, 3),
	(30, '42591651000143', 143, '2024-08-09 11:44:03', 1, 0, 3),
	(40, '42591651000143', 143, '2024-08-09 11:45:33', 1, 0, 3),
	(50, '42591651000143', 40, '2024-08-23 11:07:48', 1, 0, 3),
	(60, '42591651000143', 40, '2024-10-04 19:47:20', 1, 0, 3),
	(70, '42591651000143', 40, '2024-10-04 19:50:11', 1, 0, 3),
	(80, '42591651000143', 20, '2024-10-04 19:54:50', 1, 0, 3),
	(90, '42591651000143', 40, '2024-10-04 19:55:00', 1, 0, 3),
	(100, '42591651000143', 40, '2024-10-04 19:57:12', 1, 0, 3),
	(110, '42591651000143', 123, '2024-10-11 23:58:02', 1, 0, 1),
	(120, '42591651000143', 40, '2024-10-12 00:31:22', 1, 0, 1),
	(130, '42591651000143', 130, '2024-10-13 02:30:57', 1, 0, 1),
	(140, '42591651000143', 80, '2024-10-13 02:31:08', 1, 0, 1),
	(150, '42591651000143', 223, '2024-10-13 02:31:20', 1, 0, 1),
	(160, '42591651000143', 90, '2024-10-13 02:31:37', 1, 0, 1),
	(170, '42591651000143', 60, '2024-10-13 02:31:53', 1, 0, 1),
	(180, '42591651000143', 40, '2024-10-18 19:49:08', 1, 0, 1),
	(190, '42591651000143', 30, '2024-10-18 19:49:31', 1, 0, 1),
	(200, '42591651000143', 320, '2024-11-09 22:08:56', 1, 0, 1),
	(210, '42591651000143', 30, '2024-11-09 22:11:27', 1, 0, 1),
	(220, '42591651000143', 40, '2024-11-09 22:58:07', 1, 0, 1),
	(230, '42591651000143', 120, '2024-11-09 23:10:55', 1, 0, 1),
	(240, '42591651000143', 40, '2024-11-09 23:18:54', 1, 0, 1),
	(250, '42591651000143', 40, '2024-11-10 01:44:21', 1, 0, 1),
	(260, '42591651000143', 20, '2024-11-10 01:44:23', 1, 0, 1),
	(270, '42591651000143', 110, '2024-11-10 01:44:27', 1, 0, 1),
	(280, '42591651000143', 163, '2024-11-10 01:44:30', 1, 0, 1),
	(290, '42591651000143', 100, '2024-11-10 01:44:35', 1, 0, 1),
	(300, '42591651000143', 40, '2024-11-12 21:11:39', 1, 0, 1),
	(310, '42591651000143', 40, '2024-11-12 21:15:56', 1, 1, 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~54 rows (aproximadamente)
INSERT INTO `order_details` (`ID`, `IDORDER`, `CNPJ`, `IDPRODUCT`, `ITEM`, `CHECK_NUMBER`, `PRICE`, `ORDER_DATE`) VALUES
	(45, 10, '42591651000143', 1, 1, 1, 30, '2024-07-09 22:27:31'),
	(46, 30, '42591651000143', 7, 1, 1, 123, '2024-08-09 11:44:03'),
	(47, 30, '42591651000143', 4, 2, 1, 20, '2024-08-09 11:44:03'),
	(48, 40, '42591651000143', 7, 1, 1, 123, '2024-08-09 11:45:33'),
	(49, 40, '42591651000143', 4, 2, 1, 20, '2024-08-09 11:45:33'),
	(50, 50, '42591651000143', 3, 1, 1, 40, '2024-08-23 11:07:48'),
	(51, 60, '42591651000143', 8, 1, 1, 40, '2024-10-04 19:47:20'),
	(52, 70, '42591651000143', 8, 1, 1, 40, '2024-10-04 19:50:11'),
	(53, 80, '42591651000143', 4, 1, 1, 20, '2024-10-04 19:54:50'),
	(54, 90, '42591651000143', 8, 1, 1, 40, '2024-10-04 19:55:00'),
	(55, 100, '42591651000143', 8, 1, 1, 40, '2024-10-04 19:57:12'),
	(56, 110, '42591651000143', 7, 1, 1, 123, '2024-10-11 23:58:02'),
	(57, 120, '42591651000143', 8, 1, 1, 40, '2024-10-12 00:31:22'),
	(58, 130, '42591651000143', 4, 1, 1, 20, '2024-10-13 02:30:57'),
	(59, 130, '42591651000143', 3, 2, 1, 40, '2024-10-13 02:30:57'),
	(60, 130, '42591651000143', 3, 3, 1, 40, '2024-10-13 02:30:57'),
	(61, 130, '42591651000143', 1, 4, 1, 30, '2024-10-13 02:30:57'),
	(62, 140, '42591651000143', 4, 1, 1, 20, '2024-10-13 02:31:08'),
	(63, 140, '42591651000143', 3, 2, 1, 40, '2024-10-13 02:31:08'),
	(64, 140, '42591651000143', 4, 3, 1, 20, '2024-10-13 02:31:08'),
	(65, 150, '42591651000143', 4, 1, 1, 20, '2024-10-13 02:31:20'),
	(66, 150, '42591651000143', 3, 2, 1, 40, '2024-10-13 02:31:20'),
	(67, 150, '42591651000143', 7, 3, 1, 123, '2024-10-13 02:31:20'),
	(68, 150, '42591651000143', 8, 4, 1, 40, '2024-10-13 02:31:20'),
	(69, 160, '42591651000143', 3, 1, 1, 40, '2024-10-13 02:31:37'),
	(70, 160, '42591651000143', 1, 2, 1, 30, '2024-10-13 02:31:37'),
	(71, 160, '42591651000143', 4, 3, 1, 20, '2024-10-13 02:31:37'),
	(72, 170, '42591651000143', 4, 1, 1, 20, '2024-10-13 02:31:53'),
	(73, 170, '42591651000143', 3, 2, 1, 40, '2024-10-13 02:31:53'),
	(74, 180, '42591651000143', 3, 1, 1, 40, '2024-10-18 19:49:08'),
	(75, 190, '42591651000143', 1, 1, 1, 30, '2024-10-18 19:49:31'),
	(76, 200, '42591651000143', 3, 1, 1, 40, '2024-11-09 22:08:56'),
	(77, 200, '42591651000143', 3, 2, 1, 40, '2024-11-09 22:08:56'),
	(78, 200, '42591651000143', 3, 3, 1, 40, '2024-11-09 22:08:56'),
	(79, 200, '42591651000143', 3, 4, 1, 40, '2024-11-09 22:08:56'),
	(80, 200, '42591651000143', 3, 5, 1, 40, '2024-11-09 22:08:56'),
	(81, 200, '42591651000143', 3, 6, 1, 40, '2024-11-09 22:08:56'),
	(82, 200, '42591651000143', 3, 7, 1, 40, '2024-11-09 22:08:56'),
	(83, 200, '42591651000143', 3, 8, 1, 40, '2024-11-09 22:08:56'),
	(84, 210, '42591651000143', 1, 1, 1, 30, '2024-11-09 22:11:27'),
	(85, 220, '42591651000143', 4, 1, 1, 20, '2024-11-09 22:58:07'),
	(86, 220, '42591651000143', 4, 2, 1, 20, '2024-11-09 22:58:07'),
	(87, 230, '42591651000143', 3, 1, 1, 40, '2024-11-09 23:10:55'),
	(88, 230, '42591651000143', 3, 2, 1, 40, '2024-11-09 23:10:55'),
	(89, 230, '42591651000143', 3, 3, 1, 40, '2024-11-09 23:10:55'),
	(90, 240, '42591651000143', 3, 1, 1, 40, '2024-11-09 23:18:54'),
	(91, 250, '42591651000143', 3, 1, 1, 40, '2024-11-10 01:44:21'),
	(92, 260, '42591651000143', 4, 1, 1, 20, '2024-11-10 01:44:23'),
	(93, 270, '42591651000143', 3, 1, 1, 40, '2024-11-10 01:44:27'),
	(94, 270, '42591651000143', 4, 2, 1, 20, '2024-11-10 01:44:27'),
	(95, 270, '42591651000143', 1, 3, 1, 30, '2024-11-10 01:44:27'),
	(96, 270, '42591651000143', 4, 4, 1, 20, '2024-11-10 01:44:27'),
	(97, 280, '42591651000143', 8, 1, 1, 40, '2024-11-10 01:44:30'),
	(98, 280, '42591651000143', 7, 2, 1, 123, '2024-11-10 01:44:30'),
	(99, 290, '42591651000143', 3, 1, 1, 40, '2024-11-10 01:44:35'),
	(100, 290, '42591651000143', 3, 2, 1, 40, '2024-11-10 01:44:35'),
	(101, 290, '42591651000143', 4, 3, 1, 20, '2024-11-10 01:44:35'),
	(102, 300, '42591651000143', 3, 1, 1, 40, '2024-11-12 21:11:39'),
	(103, 310, '42591651000143', 3, 1, 1, 40, '2024-11-12 21:15:56');

-- Copiando estrutura para tabela menusystem.products
CREATE TABLE IF NOT EXISTS `products` (
  `IDPRODUCT` int NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(40) NOT NULL,
  `DESCRIPTION` varchar(50) DEFAULT NULL,
  `PRICE` float NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  `ACTIVE` int DEFAULT NULL,
  PRIMARY KEY (`IDPRODUCT`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products: ~7 rows (aproximadamente)
INSERT INTO `products` (`IDPRODUCT`, `PRODUCT_NAME`, `DESCRIPTION`, `PRICE`, `CNPJ`, `ACTIVE`) VALUES
	(1, 'McOferta McChicken', 'Um delicioso hamburguer de frango', 30, '42591651000143', 1),
	(2, 'BK Whopper', 'Um delicioso hamburguer', 40, '53060216000109', 1),
	(3, 'McOferta BigMac', 'Um delicioso hamburguer', 40, '42591651000143', 0),
	(4, 'McLancheFeliz', 'O melhor para criançada', 20.2, '42591651000143', 1),
	(5, 'BK Whopper Plantas', 'Um delicioso hamburguer com o dobro de salada', 35.99, '53060216000109', 1),
	(7, 'teste', 'teste', 123, '42591651000143', 0),
	(8, 'BK Whopper', 'Um delicioso hamburguer', 40, '42591651000143', 1);

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
