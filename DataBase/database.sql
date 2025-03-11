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
  `IDCOMPANY` int NOT NULL,
  `NAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DESCRIPTION` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DisplayMainPage` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`IDCATEGORY`) USING BTREE,
  KEY `fk_categories_company` (`IDCOMPANY`),
  CONSTRAINT `fk_categories_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.categories: ~3 rows (aproximadamente)
INSERT INTO `categories` (`IDCATEGORY`, `IDCOMPANY`, `NAME`, `DESCRIPTION`, `DisplayMainPage`) VALUES
	(1, 1, 'Carne', 'Hamburguers de carne', 1),
	(2, 1, 'Frango', 'Hamburguers de Frango', 1),
	(3, 1, 'Comprados com McChicken', 'Comprados com McChiken', 0);

-- Copiando estrutura para tabela menusystem.checks
CREATE TABLE IF NOT EXISTS `checks` (
  `CHECK_NUMBER` int NOT NULL,
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`CHECK_NUMBER`),
  KEY `fk_checks_company` (`IDCOMPANY`),
  CONSTRAINT `fk_checks_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.checks: ~6 rows (aproximadamente)
INSERT INTO `checks` (`CHECK_NUMBER`, `IDCOMPANY`) VALUES
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(6, 1);

-- Copiando estrutura para tabela menusystem.combos
CREATE TABLE IF NOT EXISTS `combos` (
  `IDCOMBO` int NOT NULL AUTO_INCREMENT,
  `IDCOMPANY` int NOT NULL,
  `COMBO_NAME` varchar(60) NOT NULL,
  `COMBO_DESCRIPTION` varchar(150) DEFAULT NULL,
  `PRICE` double NOT NULL,
  `KCAL` double NOT NULL,
  `IMAGE` varchar(300) NOT NULL,
  `BARCODE` smallint NOT NULL DEFAULT (0),
  `SALECOMBO` int NOT NULL DEFAULT (1),
  PRIMARY KEY (`IDCOMBO`),
  KEY `fk_combos_company` (`IDCOMPANY`),
  CONSTRAINT `fk_combos_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos: ~1 rows (aproximadamente)
INSERT INTO `combos` (`IDCOMBO`, `IDCOMPANY`, `COMBO_NAME`, `COMBO_DESCRIPTION`, `PRICE`, `KCAL`, `IMAGE`, `BARCODE`, `SALECOMBO`) VALUES
	(1, 1, 'Burguer+Refri 2L', 'Hamburguer de carne + um refrigerante de 2L', 35.99, 70, 'https://www.otempo.com.br/content/dam/otempo/editorias/economia/2023/3/economia-preco-do-big-mac-minas-gerais-big-mac-mais-barato-big-mac-qual-big-mac-mais-barato-do-brasil-big-mac-mais-barato-do-mundo-1708498837.jpeg', 0, 1);

-- Copiando estrutura para tabela menusystem.combos_categories
CREATE TABLE IF NOT EXISTS `combos_categories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDCOMBO` int NOT NULL,
  `IDCATEGORY` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCOMBO` (`IDCOMBO`),
  KEY `IDCATEGORY` (`IDCATEGORY`),
  CONSTRAINT `combos_categories_ibfk_1` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`),
  CONSTRAINT `combos_categories_ibfk_2` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos_categories: ~2 rows (aproximadamente)
INSERT INTO `combos_categories` (`ID`, `IDCOMBO`, `IDCATEGORY`) VALUES
	(1, 1, 1),
	(2, 1, 3);

-- Copiando estrutura para tabela menusystem.combos_grupos
CREATE TABLE IF NOT EXISTS `combos_grupos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDCOMBO` int NOT NULL,
  `IDGROUP` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCOMBO` (`IDCOMBO`),
  KEY `IDGRUPO` (`IDGROUP`) USING BTREE,
  CONSTRAINT `combos_grupos_ibfk_1` FOREIGN KEY (`IDGROUP`) REFERENCES `grupos` (`IDGROUP`),
  CONSTRAINT `combos_grupos_ibfk_2` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos_grupos: ~2 rows (aproximadamente)
INSERT INTO `combos_grupos` (`ID`, `IDCOMBO`, `IDGROUP`) VALUES
	(1, 1, 1),
	(2, 1, 2);

-- Copiando estrutura para tabela menusystem.combos_products
CREATE TABLE IF NOT EXISTS `combos_products` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDCOMBO` int NOT NULL,
  `IDPRODUCT` int NOT NULL,
  `PRICE` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCOMBO` (`IDCOMBO`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  CONSTRAINT `combos_products_ibfk_1` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`),
  CONSTRAINT `combos_products_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos_products: ~1 rows (aproximadamente)
INSERT INTO `combos_products` (`ID`, `IDCOMBO`, `IDPRODUCT`, `PRICE`) VALUES
	(1, 1, 3, 20.00);

-- Copiando estrutura para tabela menusystem.combos_recommendations
CREATE TABLE IF NOT EXISTS `combos_recommendations` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDCOMBO` int NOT NULL,
  `IDCATEGORY` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCOMBO` (`IDCOMBO`),
  KEY `IDCATEGORY` (`IDCATEGORY`),
  CONSTRAINT `combos_recommendations_ibfk_1` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`),
  CONSTRAINT `combos_recommendations_ibfk_2` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos_recommendations: ~1 rows (aproximadamente)
INSERT INTO `combos_recommendations` (`ID`, `IDCOMBO`, `IDCATEGORY`) VALUES
	(1, 1, 1);

-- Copiando estrutura para tabela menusystem.companys
CREATE TABLE IF NOT EXISTS `companys` (
  `IDCOMPANY` int NOT NULL AUTO_INCREMENT,
  `CNPJ` varchar(20) NOT NULL,
  `COMPANY_NAME` varchar(50) NOT NULL,
  `IMAGE` varchar(300) DEFAULT NULL,
  `BANNER` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`IDCOMPANY`),
  UNIQUE KEY `UNIQUE` (`CNPJ`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.companys: ~2 rows (aproximadamente)
INSERT INTO `companys` (`IDCOMPANY`, `CNPJ`, `COMPANY_NAME`, `IMAGE`, `BANNER`) VALUES
	(1, '42591651000143', 'McDonald\'s', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThQAqgv62aJ4t7KStCfhhootuw1XlN9VY9FdXN0VXS2ljU8Pn3pW8IyzBI6Dsso5xj85k&usqp=CAU', 'https://media.confetti.ac.uk/joebrill/files/2020/11/McDonalds-Retro.jpg'),
	(2, '53060216000109', 'BURGUERKING', 'https://raichu-uploads.s3.amazonaws.com/logo_meatz-burger-n-beer_3NiBWD.png', 'https://media.confetti.ac.uk/joebrill/files/2020/11/McDonalds-Retro.jpg');

-- Copiando estrutura para tabela menusystem.coupon
CREATE TABLE IF NOT EXISTS `coupon` (
  `COUPONID` int NOT NULL AUTO_INCREMENT,
  `CODE` varchar(12) NOT NULL DEFAULT '0',
  `DISCOUNT` int NOT NULL DEFAULT (0),
  `ACTIVE` smallint DEFAULT '1',
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`COUPONID`),
  KEY `fk_coupon_company` (`IDCOMPANY`),
  CONSTRAINT `fk_coupon_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.coupon: ~2 rows (aproximadamente)
INSERT INTO `coupon` (`COUPONID`, `CODE`, `DISCOUNT`, `ACTIVE`, `IDCOMPANY`) VALUES
	(2, 'BRUNO50OFF', 50, 1, 1),
	(3, '40OFF', 40, 1, 1);

-- Copiando estrutura para tabela menusystem.discount
CREATE TABLE IF NOT EXISTS `discount` (
  `ID_DISCOUNT` int NOT NULL AUTO_INCREMENT,
  `DISCOUNT_PERCENTAGE` float NOT NULL,
  `IDPRODUCT` int NOT NULL,
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`ID_DISCOUNT`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `fk_discount_company` (`IDCOMPANY`),
  CONSTRAINT `discount_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `fk_discount_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.discount: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela menusystem.grupos
CREATE TABLE IF NOT EXISTS `grupos` (
  `IDGROUP` int NOT NULL AUTO_INCREMENT,
  `IDCOMPANY` int NOT NULL,
  `GROUP_NAME` varchar(80) NOT NULL,
  `VIEWNAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `GROUP_DESCRIPTION` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`IDGROUP`) USING BTREE,
  KEY `fk_grupos_company` (`IDCOMPANY`),
  CONSTRAINT `fk_grupos_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.grupos: ~2 rows (aproximadamente)
INSERT INTO `grupos` (`IDGROUP`, `IDCOMPANY`, `GROUP_NAME`, `VIEWNAME`, `GROUP_DESCRIPTION`) VALUES
	(1, 1, 'Refrigerantes 2L', 'Refrigerante 2L', 'Refrigerantes 2L'),
	(2, 1, 'Batatas Fritas', 'McFritas', 'Fritas');

-- Copiando estrutura para tabela menusystem.grupos_combos
CREATE TABLE IF NOT EXISTS `grupos_combos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDGROUP` int NOT NULL,
  `IDCOMBO` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDGROUP` (`IDGROUP`),
  KEY `IDCOMBO` (`IDCOMBO`),
  CONSTRAINT `grupos_combos_ibfk_1` FOREIGN KEY (`IDGROUP`) REFERENCES `grupos` (`IDGROUP`),
  CONSTRAINT `grupos_combos_ibfk_2` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.grupos_combos: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela menusystem.grupos_products
CREATE TABLE IF NOT EXISTS `grupos_products` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDGROUP` int NOT NULL,
  `IDPRODUCT` int NOT NULL,
  `PRICE` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `IDGRUPO` (`IDGROUP`) USING BTREE,
  CONSTRAINT `grupos_products_ibfk_1` FOREIGN KEY (`IDGROUP`) REFERENCES `grupos` (`IDGROUP`),
  CONSTRAINT `grupos_products_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.grupos_products: ~6 rows (aproximadamente)
INSERT INTO `grupos_products` (`ID`, `IDGROUP`, `IDPRODUCT`, `PRICE`) VALUES
	(1, 1, 12, 11.00),
	(2, 1, 13, 10.00),
	(3, 1, 14, 10.00),
	(4, 2, 11, 6.00),
	(5, 2, 9, 8.00),
	(6, 2, 10, 10.00);

-- Copiando estrutura para tabela menusystem.ingredients
CREATE TABLE IF NOT EXISTS `ingredients` (
  `IdIngredient` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Description` varchar(250) DEFAULT NULL,
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`IdIngredient`) USING BTREE,
  KEY `fk_ingredients_company` (`IDCOMPANY`),
  CONSTRAINT `fk_ingredients_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.ingredients: ~6 rows (aproximadamente)
INSERT INTO `ingredients` (`IdIngredient`, `Name`, `Description`, `IDCOMPANY`) VALUES
	(1, 'Carne', '130g de hambúrguer', 1),
	(2, 'Frango', '140g de Frango', 1),
	(3, 'Picles', '4 fatias de picles', 1),
	(4, 'Alface', 'Alface', 1),
	(5, 'Bacon', '10g de Bacon', 1),
	(6, 'Molho Ketchup', 'Molho', 1);

-- Copiando estrutura para tabela menusystem.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `IDORDER` int NOT NULL AUTO_INCREMENT,
  `TOTAL` float NOT NULL,
  `ORDER_DATE` datetime NOT NULL,
  `CHECK_NUMBER` int NOT NULL,
  `ORDER_ACTIVE` smallint DEFAULT NULL,
  `ORDER_STATUS` int DEFAULT NULL,
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`IDORDER`),
  KEY `CHECK_NUMBER` (`CHECK_NUMBER`),
  KEY `fk_orders_company` (`IDCOMPANY`),
  CONSTRAINT `fk_orders_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`)
) ENGINE=InnoDB AUTO_INCREMENT=138 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.orders: ~16 rows (aproximadamente)
INSERT INTO `orders` (`IDORDER`, `TOTAL`, `ORDER_DATE`, `CHECK_NUMBER`, `ORDER_ACTIVE`, `ORDER_STATUS`, `IDCOMPANY`) VALUES
	(122, 152, '2025-03-07 23:19:26', 1, 1, 1, 1),
	(123, 65, '2025-03-07 23:23:25', 1, 1, 1, 1),
	(124, 1812.57, '2025-03-07 23:37:12', 1, 1, 1, 1),
	(125, 761.53, '2025-03-07 23:39:33', 1, 1, 1, 1),
	(126, 3415.6, '2025-03-07 23:49:53', 1, 1, 1, 1),
	(127, 8.99, '2025-03-07 23:50:47', 1, 1, 1, 1),
	(128, 7872.2, '2025-03-07 23:54:02', 1, 1, 1, 1),
	(129, 687.8, '2025-03-07 23:57:38', 1, 1, 1, 1),
	(130, 20.2, '2025-03-07 23:57:43', 1, 1, 1, 1),
	(131, 20.2, '2025-03-07 23:57:48', 1, 1, 1, 1),
	(132, 20.2, '2025-03-07 23:57:52', 1, 1, 1, 1),
	(133, 100.2, '2025-03-07 23:58:03', 1, 1, 1, 1),
	(134, 150, '2025-03-08 00:22:01', 1, 1, 1, 1),
	(135, 123, '2025-03-08 01:30:18', 1, 1, 1, 1),
	(136, 75.2, '2025-03-09 21:39:58', 2, 1, 1, 1),
	(137, 20.2, '2025-03-09 21:40:42', 2, 1, 1, 1);

-- Copiando estrutura para tabela menusystem.order_details
CREATE TABLE IF NOT EXISTS `order_details` (
  `ID` int unsigned NOT NULL AUTO_INCREMENT,
  `IDORDER` int NOT NULL,
  `IDPRODUCT` int NOT NULL,
  `ITEM` int NOT NULL,
  `CHECK_NUMBER` int NOT NULL,
  `PRICE` float NOT NULL,
  `ORDER_DATE` datetime NOT NULL,
  `Note` varchar(100) NOT NULL DEFAULT '',
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IDORDER` (`IDORDER`,`ITEM`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `CHECK_NUMBER` (`CHECK_NUMBER`),
  KEY `fk_orderdetails_company` (`IDCOMPANY`),
  CONSTRAINT `fk_orderdetails_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`),
  CONSTRAINT `order_details_ibfk_3` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `order_details_ibfk_4` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`),
  CONSTRAINT `order_details_ibfk_5` FOREIGN KEY (`IDORDER`) REFERENCES `orders` (`IDORDER`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=769 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~349 rows (aproximadamente)
INSERT INTO `order_details` (`ID`, `IDORDER`, `IDPRODUCT`, `ITEM`, `CHECK_NUMBER`, `PRICE`, `ORDER_DATE`, `Note`, `IDCOMPANY`) VALUES
	(420, 122, 3, 1, 1, 20, '2025-03-07 23:19:26', '', 1),
	(421, 122, 3, 2, 1, 20, '2025-03-07 23:19:26', '', 1),
	(422, 122, 3, 3, 1, 20, '2025-03-07 23:19:26', '', 1),
	(423, 122, 3, 4, 1, 20, '2025-03-07 23:19:26', '', 1),
	(424, 122, 9, 5, 1, 8, '2025-03-07 23:19:26', '', 1),
	(425, 122, 9, 6, 1, 8, '2025-03-07 23:19:26', '', 1),
	(426, 122, 9, 7, 1, 8, '2025-03-07 23:19:26', '', 1),
	(427, 122, 9, 8, 1, 8, '2025-03-07 23:19:26', '', 1),
	(428, 122, 14, 9, 1, 10, '2025-03-07 23:19:26', '', 1),
	(429, 122, 14, 10, 1, 10, '2025-03-07 23:19:26', '', 1),
	(430, 122, 14, 11, 1, 10, '2025-03-07 23:19:26', '', 1),
	(431, 122, 14, 12, 1, 10, '2025-03-07 23:19:26', '', 1),
	(432, 123, 3, 1, 1, 20, '2025-03-07 23:23:25', '', 1),
	(433, 123, 10, 2, 1, 10, '2025-03-07 23:23:25', '', 1),
	(434, 123, 13, 3, 1, 10, '2025-03-07 23:23:25', '', 1),
	(435, 123, 1, 4, 1, 25, '2025-03-07 23:23:25', '', 1),
	(436, 124, 7, 1, 1, 123, '2025-03-07 23:37:12', '', 1),
	(437, 124, 7, 2, 1, 123, '2025-03-07 23:37:12', '', 1),
	(438, 124, 7, 3, 1, 123, '2025-03-07 23:37:12', '', 1),
	(439, 124, 7, 4, 1, 123, '2025-03-07 23:37:12', '', 1),
	(440, 124, 7, 5, 1, 123, '2025-03-07 23:37:12', '', 1),
	(441, 124, 7, 6, 1, 123, '2025-03-07 23:37:12', '', 1),
	(442, 124, 7, 7, 1, 123, '2025-03-07 23:37:12', '', 1),
	(443, 124, 7, 8, 1, 123, '2025-03-07 23:37:12', '', 1),
	(444, 124, 7, 9, 1, 123, '2025-03-07 23:37:12', '', 1),
	(445, 124, 7, 10, 1, 123, '2025-03-07 23:37:12', '', 1),
	(446, 124, 12, 11, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(447, 124, 12, 12, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(448, 124, 12, 13, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(449, 124, 12, 14, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(450, 124, 12, 15, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(451, 124, 12, 16, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(452, 124, 12, 17, 1, 9.99, '2025-03-07 23:37:12', '', 1),
	(453, 124, 13, 18, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(454, 124, 13, 19, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(455, 124, 13, 20, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(456, 124, 13, 21, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(457, 124, 13, 22, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(458, 124, 13, 23, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(459, 124, 13, 24, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(460, 124, 13, 25, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(461, 124, 14, 26, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(462, 124, 14, 27, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(463, 124, 14, 28, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(464, 124, 14, 29, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(465, 124, 14, 30, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(466, 124, 14, 31, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(467, 124, 14, 32, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(468, 124, 14, 33, 1, 8.99, '2025-03-07 23:37:12', '', 1),
	(469, 124, 11, 34, 1, 7, '2025-03-07 23:37:12', '', 1),
	(470, 124, 11, 35, 1, 7, '2025-03-07 23:37:12', '', 1),
	(471, 124, 11, 36, 1, 7, '2025-03-07 23:37:12', '', 1),
	(472, 124, 11, 37, 1, 7, '2025-03-07 23:37:12', '', 1),
	(473, 124, 10, 38, 1, 13, '2025-03-07 23:37:12', '', 1),
	(474, 124, 10, 39, 1, 13, '2025-03-07 23:37:12', '', 1),
	(475, 124, 10, 40, 1, 13, '2025-03-07 23:37:12', '', 1),
	(476, 124, 10, 41, 1, 13, '2025-03-07 23:37:12', '', 1),
	(477, 124, 10, 42, 1, 13, '2025-03-07 23:37:12', '', 1),
	(478, 124, 9, 43, 1, 10, '2025-03-07 23:37:12', '', 1),
	(479, 124, 9, 44, 1, 10, '2025-03-07 23:37:12', '', 1),
	(480, 124, 9, 45, 1, 10, '2025-03-07 23:37:12', '', 1),
	(481, 124, 9, 46, 1, 10, '2025-03-07 23:37:12', '', 1),
	(482, 124, 9, 47, 1, 10, '2025-03-07 23:37:12', '', 1),
	(483, 124, 9, 48, 1, 10, '2025-03-07 23:37:12', '', 1),
	(484, 124, 9, 49, 1, 10, '2025-03-07 23:37:12', '', 1),
	(485, 124, 9, 50, 1, 10, '2025-03-07 23:37:12', '', 1),
	(486, 124, 9, 51, 1, 10, '2025-03-07 23:37:12', '', 1),
	(487, 124, 8, 52, 1, 40, '2025-03-07 23:37:12', '', 1),
	(488, 124, 1, 53, 1, 25, '2025-03-07 23:37:12', '', 1),
	(489, 124, 4, 54, 1, 20.2, '2025-03-07 23:37:12', '', 1),
	(490, 124, 4, 55, 1, 20.2, '2025-03-07 23:37:12', '', 1),
	(491, 124, 4, 56, 1, 20.2, '2025-03-07 23:37:12', '', 1),
	(492, 124, 4, 57, 1, 20.2, '2025-03-07 23:37:12', '', 1),
	(493, 124, 3, 58, 1, 20, '2025-03-07 23:37:12', '', 1),
	(494, 124, 10, 59, 1, 10, '2025-03-07 23:37:12', '', 1),
	(495, 124, 14, 60, 1, 10, '2025-03-07 23:37:12', '', 1),
	(496, 125, 4, 1, 1, 20.2, '2025-03-07 23:39:33', '', 1),
	(497, 125, 4, 2, 1, 20.2, '2025-03-07 23:39:33', '', 1),
	(498, 125, 7, 3, 1, 123, '2025-03-07 23:39:33', '', 1),
	(499, 125, 7, 4, 1, 123, '2025-03-07 23:39:33', '', 1),
	(500, 125, 7, 5, 1, 123, '2025-03-07 23:39:33', '', 1),
	(501, 125, 7, 6, 1, 123, '2025-03-07 23:39:33', '', 1),
	(502, 125, 1, 7, 1, 25, '2025-03-07 23:39:33', '', 1),
	(503, 125, 3, 8, 1, 39.2, '2025-03-07 23:39:33', '', 1),
	(504, 125, 12, 9, 1, 9.99, '2025-03-07 23:39:33', '', 1),
	(505, 125, 12, 10, 1, 9.99, '2025-03-07 23:39:33', '', 1),
	(506, 125, 13, 11, 1, 8.99, '2025-03-07 23:39:33', '', 1),
	(507, 125, 13, 12, 1, 8.99, '2025-03-07 23:39:33', '', 1),
	(508, 125, 13, 13, 1, 8.99, '2025-03-07 23:39:33', '', 1),
	(509, 125, 14, 14, 1, 8.99, '2025-03-07 23:39:33', '', 1),
	(510, 125, 14, 15, 1, 8.99, '2025-03-07 23:39:33', '', 1),
	(511, 125, 3, 16, 1, 20, '2025-03-07 23:39:33', '', 1),
	(512, 125, 10, 17, 1, 10, '2025-03-07 23:39:33', '', 1),
	(513, 125, 14, 18, 1, 10, '2025-03-07 23:39:33', '', 1),
	(514, 125, 11, 19, 1, 7, '2025-03-07 23:39:33', '', 1),
	(515, 125, 11, 20, 1, 7, '2025-03-07 23:39:33', '', 1),
	(516, 125, 10, 21, 1, 13, '2025-03-07 23:39:33', '', 1),
	(517, 125, 10, 22, 1, 13, '2025-03-07 23:39:33', '', 1),
	(518, 125, 9, 23, 1, 10, '2025-03-07 23:39:33', '', 1),
	(519, 125, 9, 24, 1, 10, '2025-03-07 23:39:33', '', 1),
	(520, 126, 4, 1, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(521, 126, 4, 2, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(522, 126, 4, 3, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(523, 126, 4, 4, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(524, 126, 4, 5, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(525, 126, 4, 6, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(526, 126, 4, 7, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(527, 126, 4, 8, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(528, 126, 4, 9, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(529, 126, 4, 10, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(530, 126, 4, 11, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(531, 126, 4, 12, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(532, 126, 4, 13, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(533, 126, 4, 14, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(534, 126, 4, 15, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(535, 126, 4, 16, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(536, 126, 4, 17, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(537, 126, 4, 18, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(538, 126, 4, 19, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(539, 126, 4, 20, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(540, 126, 4, 21, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(541, 126, 4, 22, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(542, 126, 4, 23, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(543, 126, 4, 24, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(544, 126, 4, 25, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(545, 126, 4, 26, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(546, 126, 4, 27, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(547, 126, 4, 28, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(548, 126, 4, 29, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(549, 126, 4, 30, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(550, 126, 4, 31, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(551, 126, 4, 32, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(552, 126, 4, 33, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(553, 126, 4, 34, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(554, 126, 4, 35, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(555, 126, 4, 36, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(556, 126, 4, 37, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(557, 126, 4, 38, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(558, 126, 4, 39, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(559, 126, 4, 40, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(560, 126, 4, 41, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(561, 126, 4, 42, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(562, 126, 4, 43, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(563, 126, 4, 44, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(564, 126, 4, 45, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(565, 126, 4, 46, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(566, 126, 4, 47, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(567, 126, 4, 48, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(568, 126, 4, 49, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(569, 126, 4, 50, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(570, 126, 4, 51, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(571, 126, 4, 52, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(572, 126, 4, 53, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(573, 126, 4, 54, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(574, 126, 4, 55, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(575, 126, 4, 56, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(576, 126, 4, 57, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(577, 126, 4, 58, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(578, 126, 4, 59, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(579, 126, 4, 60, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(580, 126, 4, 61, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(581, 126, 4, 62, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(582, 126, 4, 63, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(583, 126, 4, 64, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(584, 126, 4, 65, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(585, 126, 4, 66, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(586, 126, 4, 67, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(587, 126, 4, 68, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(588, 126, 4, 69, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(589, 126, 4, 70, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(590, 126, 4, 71, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(591, 126, 4, 72, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(592, 126, 4, 73, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(593, 126, 4, 74, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(594, 126, 4, 75, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(595, 126, 4, 76, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(596, 126, 4, 77, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(597, 126, 4, 78, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(598, 126, 4, 79, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(599, 126, 4, 80, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(600, 126, 4, 81, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(601, 126, 4, 82, 1, 20.2, '2025-03-07 23:49:53', '', 1),
	(602, 126, 3, 83, 1, 20, '2025-03-07 23:49:53', '', 1),
	(603, 126, 10, 84, 1, 10, '2025-03-07 23:49:53', '', 1),
	(604, 126, 12, 85, 1, 11, '2025-03-07 23:49:53', '', 1),
	(605, 126, 1, 86, 1, 25, '2025-03-07 23:49:53', '', 1),
	(606, 126, 1, 87, 1, 25, '2025-03-07 23:49:53', '', 1),
	(607, 126, 1, 88, 1, 25, '2025-03-07 23:49:53', '', 1),
	(608, 126, 1, 89, 1, 25, '2025-03-07 23:49:53', '', 1),
	(609, 126, 1, 90, 1, 25, '2025-03-07 23:49:53', '', 1),
	(610, 126, 1, 91, 1, 25, '2025-03-07 23:49:53', '', 1),
	(611, 126, 1, 92, 1, 25, '2025-03-07 23:49:53', '', 1),
	(612, 126, 1, 93, 1, 25, '2025-03-07 23:49:53', '', 1),
	(613, 126, 1, 94, 1, 25, '2025-03-07 23:49:53', '', 1),
	(614, 126, 1, 95, 1, 25, '2025-03-07 23:49:53', '', 1),
	(615, 126, 1, 96, 1, 25, '2025-03-07 23:49:53', '', 1),
	(616, 126, 1, 97, 1, 25, '2025-03-07 23:49:53', '', 1),
	(617, 126, 1, 98, 1, 25, '2025-03-07 23:49:53', '', 1),
	(618, 126, 1, 99, 1, 25, '2025-03-07 23:49:53', '', 1),
	(619, 126, 11, 100, 1, 7, '2025-03-07 23:49:53', '', 1),
	(620, 126, 11, 101, 1, 7, '2025-03-07 23:49:53', '', 1),
	(621, 126, 11, 102, 1, 7, '2025-03-07 23:49:53', '', 1),
	(622, 126, 11, 103, 1, 7, '2025-03-07 23:49:53', '', 1),
	(623, 126, 11, 104, 1, 7, '2025-03-07 23:49:53', '', 1),
	(624, 126, 11, 105, 1, 7, '2025-03-07 23:49:53', '', 1),
	(625, 126, 11, 106, 1, 7, '2025-03-07 23:49:53', '', 1),
	(626, 126, 11, 107, 1, 7, '2025-03-07 23:49:53', '', 1),
	(627, 126, 11, 108, 1, 7, '2025-03-07 23:49:53', '', 1),
	(628, 126, 7, 109, 1, 123, '2025-03-07 23:49:53', '', 1),
	(629, 126, 7, 110, 1, 123, '2025-03-07 23:49:53', '', 1),
	(630, 126, 8, 111, 1, 40, '2025-03-07 23:49:53', '', 1),
	(631, 126, 3, 112, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(632, 126, 3, 113, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(633, 126, 3, 114, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(634, 126, 3, 115, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(635, 126, 3, 116, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(636, 126, 3, 117, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(637, 126, 3, 118, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(638, 126, 3, 119, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(639, 126, 3, 120, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(640, 126, 3, 121, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(641, 126, 3, 122, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(642, 126, 3, 123, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(643, 126, 3, 124, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(644, 126, 3, 125, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(645, 126, 3, 126, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(646, 126, 3, 127, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(647, 126, 3, 128, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(648, 126, 3, 129, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(649, 126, 3, 130, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(650, 126, 3, 131, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(651, 126, 3, 132, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(652, 126, 3, 133, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(653, 126, 3, 134, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(654, 126, 3, 135, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(655, 126, 3, 136, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(656, 126, 3, 137, 1, 39.2, '2025-03-07 23:49:53', 'Sem Picles,\n\n', 1),
	(657, 127, 14, 1, 1, 8.99, '2025-03-07 23:50:47', '', 1),
	(658, 128, 1, 1, 1, 25, '2025-03-07 23:54:02', '', 1),
	(659, 128, 11, 2, 1, 7, '2025-03-07 23:54:02', '', 1),
	(660, 128, 9, 3, 1, 10, '2025-03-07 23:54:02', '', 1),
	(661, 128, 10, 4, 1, 13, '2025-03-07 23:54:02', '', 1),
	(662, 128, 10, 5, 1, 13, '2025-03-07 23:54:02', '', 1),
	(663, 128, 3, 6, 1, 39.2, '2025-03-07 23:54:02', '', 1),
	(664, 128, 3, 7, 1, 39.2, '2025-03-07 23:54:02', '', 1),
	(665, 128, 3, 8, 1, 39.2, '2025-03-07 23:54:02', '', 1),
	(666, 128, 4, 9, 1, 20.2, '2025-03-07 23:54:02', '', 1),
	(667, 128, 4, 10, 1, 20.2, '2025-03-07 23:54:02', '', 1),
	(668, 128, 4, 11, 1, 20.2, '2025-03-07 23:54:02', '', 1),
	(669, 128, 7, 12, 1, 123, '2025-03-07 23:54:02', '', 1),
	(670, 128, 7, 13, 1, 123, '2025-03-07 23:54:02', '', 1),
	(671, 128, 7, 14, 1, 123, '2025-03-07 23:54:02', '', 1),
	(672, 128, 7, 15, 1, 123, '2025-03-07 23:54:02', '', 1),
	(673, 128, 7, 16, 1, 123, '2025-03-07 23:54:02', '', 1),
	(674, 128, 7, 17, 1, 123, '2025-03-07 23:54:02', '', 1),
	(675, 128, 7, 18, 1, 123, '2025-03-07 23:54:02', '', 1),
	(676, 128, 7, 19, 1, 123, '2025-03-07 23:54:02', '', 1),
	(677, 128, 7, 20, 1, 123, '2025-03-07 23:54:02', '', 1),
	(678, 128, 7, 21, 1, 123, '2025-03-07 23:54:02', '', 1),
	(679, 128, 7, 22, 1, 123, '2025-03-07 23:54:02', '', 1),
	(680, 128, 7, 23, 1, 123, '2025-03-07 23:54:02', '', 1),
	(681, 128, 7, 24, 1, 123, '2025-03-07 23:54:02', '', 1),
	(682, 128, 7, 25, 1, 123, '2025-03-07 23:54:02', '', 1),
	(683, 128, 7, 26, 1, 123, '2025-03-07 23:54:02', '', 1),
	(684, 128, 7, 27, 1, 123, '2025-03-07 23:54:02', '', 1),
	(685, 128, 7, 28, 1, 123, '2025-03-07 23:54:02', '', 1),
	(686, 128, 7, 29, 1, 123, '2025-03-07 23:54:02', '', 1),
	(687, 128, 7, 30, 1, 123, '2025-03-07 23:54:02', '', 1),
	(688, 128, 7, 31, 1, 123, '2025-03-07 23:54:02', '', 1),
	(689, 128, 7, 32, 1, 123, '2025-03-07 23:54:02', '', 1),
	(690, 128, 7, 33, 1, 123, '2025-03-07 23:54:02', '', 1),
	(691, 128, 7, 34, 1, 123, '2025-03-07 23:54:02', '', 1),
	(692, 128, 7, 35, 1, 123, '2025-03-07 23:54:02', '', 1),
	(693, 128, 7, 36, 1, 123, '2025-03-07 23:54:02', '', 1),
	(694, 128, 7, 37, 1, 123, '2025-03-07 23:54:02', '', 1),
	(695, 128, 7, 38, 1, 123, '2025-03-07 23:54:02', '', 1),
	(696, 128, 7, 39, 1, 123, '2025-03-07 23:54:02', '', 1),
	(697, 128, 7, 40, 1, 123, '2025-03-07 23:54:02', '', 1),
	(698, 128, 7, 41, 1, 123, '2025-03-07 23:54:02', '', 1),
	(699, 128, 7, 42, 1, 123, '2025-03-07 23:54:02', '', 1),
	(700, 128, 7, 43, 1, 123, '2025-03-07 23:54:02', '', 1),
	(701, 128, 7, 44, 1, 123, '2025-03-07 23:54:02', '', 1),
	(702, 128, 7, 45, 1, 123, '2025-03-07 23:54:02', '', 1),
	(703, 128, 7, 46, 1, 123, '2025-03-07 23:54:02', '', 1),
	(704, 128, 7, 47, 1, 123, '2025-03-07 23:54:02', '', 1),
	(705, 128, 7, 48, 1, 123, '2025-03-07 23:54:02', '', 1),
	(706, 128, 7, 49, 1, 123, '2025-03-07 23:54:02', '', 1),
	(707, 128, 7, 50, 1, 123, '2025-03-07 23:54:02', '', 1),
	(708, 128, 7, 51, 1, 123, '2025-03-07 23:54:02', '', 1),
	(709, 128, 7, 52, 1, 123, '2025-03-07 23:54:02', '', 1),
	(710, 128, 7, 53, 1, 123, '2025-03-07 23:54:02', '', 1),
	(711, 128, 7, 54, 1, 123, '2025-03-07 23:54:02', '', 1),
	(712, 128, 7, 55, 1, 123, '2025-03-07 23:54:02', '', 1),
	(713, 128, 7, 56, 1, 123, '2025-03-07 23:54:02', '', 1),
	(714, 128, 7, 57, 1, 123, '2025-03-07 23:54:02', '', 1),
	(715, 128, 7, 58, 1, 123, '2025-03-07 23:54:02', '', 1),
	(716, 128, 7, 59, 1, 123, '2025-03-07 23:54:02', '', 1),
	(717, 128, 7, 60, 1, 123, '2025-03-07 23:54:02', '', 1),
	(718, 128, 7, 61, 1, 123, '2025-03-07 23:54:02', '', 1),
	(719, 128, 7, 62, 1, 123, '2025-03-07 23:54:02', '', 1),
	(720, 128, 7, 63, 1, 123, '2025-03-07 23:54:02', '', 1),
	(721, 128, 7, 64, 1, 123, '2025-03-07 23:54:02', '', 1),
	(722, 128, 7, 65, 1, 123, '2025-03-07 23:54:02', '', 1),
	(723, 128, 7, 66, 1, 123, '2025-03-07 23:54:02', '', 1),
	(724, 128, 7, 67, 1, 123, '2025-03-07 23:54:02', '', 1),
	(725, 128, 7, 68, 1, 123, '2025-03-07 23:54:02', '', 1),
	(726, 128, 7, 69, 1, 123, '2025-03-07 23:54:02', '', 1),
	(727, 128, 7, 70, 1, 123, '2025-03-07 23:54:02', '', 1),
	(728, 128, 7, 71, 1, 123, '2025-03-07 23:54:02', '', 1),
	(729, 128, 7, 72, 1, 123, '2025-03-07 23:54:02', '', 1),
	(730, 128, 7, 73, 1, 123, '2025-03-07 23:54:02', '', 1),
	(731, 129, 3, 1, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(732, 129, 3, 2, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(733, 129, 3, 3, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(734, 129, 3, 4, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(735, 129, 3, 5, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(736, 129, 3, 6, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(737, 129, 3, 7, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(738, 129, 3, 8, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(739, 129, 3, 9, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(740, 129, 3, 10, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(741, 129, 3, 11, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(742, 129, 3, 12, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(743, 129, 3, 13, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(744, 129, 3, 14, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(745, 129, 3, 15, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(746, 129, 3, 16, 1, 39.2, '2025-03-07 23:57:38', '', 1),
	(747, 129, 4, 17, 1, 20.2, '2025-03-07 23:57:38', '', 1),
	(748, 129, 4, 18, 1, 20.2, '2025-03-07 23:57:38', '', 1),
	(749, 129, 4, 19, 1, 20.2, '2025-03-07 23:57:38', '', 1),
	(750, 130, 4, 1, 1, 20.2, '2025-03-07 23:57:43', '', 1),
	(751, 131, 4, 1, 1, 20.2, '2025-03-07 23:57:48', '', 1),
	(752, 132, 4, 1, 1, 20.2, '2025-03-07 23:57:52', '', 1),
	(753, 133, 4, 1, 1, 20.2, '2025-03-07 23:58:03', '', 1),
	(754, 133, 8, 2, 1, 40, '2025-03-07 23:58:03', '', 1),
	(755, 133, 8, 3, 1, 40, '2025-03-07 23:58:03', '', 1),
	(756, 134, 1, 1, 1, 25, '2025-03-08 00:22:01', '', 1),
	(757, 134, 1, 2, 1, 25, '2025-03-08 00:22:01', '', 1),
	(758, 134, 1, 3, 1, 25, '2025-03-08 00:22:01', '', 1),
	(759, 134, 1, 4, 1, 25, '2025-03-08 00:22:01', '', 1),
	(760, 134, 1, 5, 1, 25, '2025-03-08 00:22:01', '', 1),
	(761, 134, 1, 6, 1, 25, '2025-03-08 00:22:01', '', 1),
	(762, 135, 7, 1, 1, 123, '2025-03-08 01:30:18', '', 1),
	(763, 136, 4, 1, 2, 20.2, '2025-03-09 21:39:58', '', 1),
	(764, 136, 1, 2, 2, 25, '2025-03-09 21:39:58', '', 1),
	(765, 136, 11, 3, 2, 7, '2025-03-09 21:39:58', '', 1),
	(766, 136, 9, 4, 2, 10, '2025-03-09 21:39:58', '', 1),
	(767, 136, 10, 5, 2, 13, '2025-03-09 21:39:58', '', 1),
	(768, 137, 4, 1, 2, 20.2, '2025-03-09 21:40:42', '', 1);

-- Copiando estrutura para tabela menusystem.products
CREATE TABLE IF NOT EXISTS `products` (
  `IDPRODUCT` int NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IDCATEGORY` int DEFAULT (0),
  `IDCOMPANY` int NOT NULL,
  `DESCRIPTION` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PRICE` float NOT NULL,
  `KCAL` float DEFAULT (0),
  `IMAGE` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `BARCODE` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '00000000000000000000',
  `ACTIVE` smallint NOT NULL DEFAULT (0),
  `SALEPRODUCT` smallint NOT NULL DEFAULT (1),
  `DISCOUNT_PERCENTUAL` decimal(10,2) NOT NULL DEFAULT (0.00),
  `DISCOUNT_PRICE` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`IDPRODUCT`),
  KEY `categories_fk` (`IDCATEGORY`),
  KEY `fk_products_company` (`IDCOMPANY`),
  CONSTRAINT `categories_fk` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`) ON DELETE SET NULL,
  CONSTRAINT `fk_products_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products: ~13 rows (aproximadamente)
INSERT INTO `products` (`IDPRODUCT`, `PRODUCT_NAME`, `IDCATEGORY`, `IDCOMPANY`, `DESCRIPTION`, `PRICE`, `KCAL`, `IMAGE`, `BARCODE`, `ACTIVE`, `SALEPRODUCT`, `DISCOUNT_PERCENTUAL`, `DISCOUNT_PRICE`) VALUES
	(1, 'McOferta McChicken', 1, 1, 'Um delicioso hamburguer de frango', 30, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$keX4W7gr/200/200/original?country=br', '00000000000000000000', 1, 0, 0.00, 5.00),
	(2, 'BK Whopper', 1, 2, 'Um delicioso hamburguer', 40, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png', '00000000000000000000', 1, 0, 0.00, 0.00),
	(3, 'McOferta BigMac', 2, 1, 'Dois hambúrgueres (100% carne bovina), alface americana, queijo processado sabor cheddar, molho especial, cebola, picles e pão com gergelim.', 40, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$kzXCTbnv/200/200/original?country=br', '00000000000000000000', 1, 0, 2.00, 0.00),
	(4, 'McLancheFeliz', 1, 1, 'O melhor para criançada', 20.2, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$kJXZljtR/200/200/original?country=br', '00000000000000000000', 1, 0, 0.00, 0.00),
	(5, 'BK Whopper Plantas', 1, 2, 'Um delicioso hamburguer com o dobro de salada', 35.99, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png', '00000000000000000000', 1, 0, 0.00, 0.00),
	(7, 'teste', 1, 1, 'teste', 123, 0, 'https://mcdonalds.bg/wp-content/uploads/2023/01/BG_CSO_9108.png', '00000000000000000000', 1, 0, 0.00, 0.00),
	(8, 'BK Whopper', 1, 1, 'Um delicioso hamburguer', 40, 0, 'https://d3sn2rlrwxy0ce.cloudfront.net/_800x600_crop_center-center_none/whopper-thumb_2021-09-16-125319_mppe.png?mtime=20210916125320&focal=none&tmtime=20241024164409', '00000000000000000000', 1, 0, 0.00, 0.00),
	(9, 'McFritas - Média', 1, 1, '50g de Fritas', 10, 0, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1, 0.00, 0.00),
	(10, 'McFritas - Grande', 1, 1, '70g de Fritas', 13, 20, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1, 0.00, 0.00),
	(11, 'McFritas - Pequena', 1, 1, '30g de Fritas', 7, 10, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1, 0.00, 0.00),
	(12, 'Refrigerante Coca-Cola 2L', 1, 1, 'Refrigerante de 2L', 9.99, 10, 'https://ibassets.com.br/ib.item.image.large/l-6914a2bb4f5945e096287835120c831e.png', '00000000000000000000', 1, 1, 0.00, 0.00),
	(13, 'Refrigerante Guarana 2L', 1, 1, 'Refrigerante de 2L', 8.99, 10, 'https://choppbrahmaexpress.vtexassets.com/arquivos/ids/155720/guaran_2.png?v=637353454730230000', '00000000000000000000', 1, 1, 0.00, 0.00),
	(14, 'Refrigerante Pepsi 2L', 1, 1, 'Refrigerante de 2L', 8.99, 10, 'https://thepetitpizzaria.com.br/parobe/wp-content/uploads/2021/06/foto_original.png', '00000000000000000000', 1, 1, 0.00, 0.00);

-- Copiando estrutura para tabela menusystem.products_acompanhamentos
CREATE TABLE IF NOT EXISTS `products_acompanhamentos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PRODUCT` int NOT NULL,
  `ACOMPANHAMENTO` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `PRODUCT` (`PRODUCT`),
  KEY `ACOMPANHAMENTO` (`ACOMPANHAMENTO`),
  CONSTRAINT `products_acompanhamentos_ibfk_1` FOREIGN KEY (`PRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_acompanhamentos_ibfk_2` FOREIGN KEY (`ACOMPANHAMENTO`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_acompanhamentos: ~4 rows (aproximadamente)
INSERT INTO `products_acompanhamentos` (`ID`, `PRODUCT`, `ACOMPANHAMENTO`) VALUES
	(3, 1, 11),
	(4, 1, 9),
	(5, 1, 10),
	(6, 3, 4);

-- Copiando estrutura para tabela menusystem.products_categories
CREATE TABLE IF NOT EXISTS `products_categories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PRODUCT` int NOT NULL,
  `CATEGORY` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `PRODUCT` (`PRODUCT`),
  KEY `CATEGORY` (`CATEGORY`),
  CONSTRAINT `products_categories_ibfk_1` FOREIGN KEY (`PRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_categories_ibfk_2` FOREIGN KEY (`CATEGORY`) REFERENCES `categories` (`IDCATEGORY`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_categories: ~7 rows (aproximadamente)
INSERT INTO `products_categories` (`ID`, `PRODUCT`, `CATEGORY`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 4, 1),
	(5, 3, 2),
	(6, 2, 3),
	(7, 4, 3),
	(8, 3, 3);

-- Copiando estrutura para tabela menusystem.products_ingrdients
CREATE TABLE IF NOT EXISTS `products_ingrdients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idProduct` int NOT NULL,
  `idIngredient` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idProduct` (`idProduct`),
  KEY `idIngredient` (`idIngredient`),
  CONSTRAINT `products_ingrdients_ibfk_1` FOREIGN KEY (`idProduct`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_ingrdients_ibfk_2` FOREIGN KEY (`idIngredient`) REFERENCES `ingredients` (`IdIngredient`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_ingrdients: ~5 rows (aproximadamente)
INSERT INTO `products_ingrdients` (`id`, `idProduct`, `idIngredient`) VALUES
	(6, 1, 2),
	(7, 3, 3),
	(8, 1, 5),
	(9, 1, 6),
	(10, 1, 4);

-- Copiando estrutura para tabela menusystem.products_recommendations
CREATE TABLE IF NOT EXISTS `products_recommendations` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDPRODUCT` int NOT NULL,
  `IDCATEGORY` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `IDCATEGORY` (`IDCATEGORY`),
  CONSTRAINT `products_recommendations_ibfk_1` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_recommendations_ibfk_2` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_recommendations: ~3 rows (aproximadamente)
INSERT INTO `products_recommendations` (`ID`, `IDPRODUCT`, `IDCATEGORY`) VALUES
	(1, 1, 3),
	(4, 1, 2),
	(5, 1, 1);

-- Copiando estrutura para tabela menusystem.users
CREATE TABLE IF NOT EXISTS `users` (
  `IDUSER` int NOT NULL AUTO_INCREMENT,
  `NAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SENHA` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ADMIN` smallint NOT NULL DEFAULT (0),
  `USER_ACTIVE` int DEFAULT NULL,
  `IDCOMPANY` int NOT NULL,
  PRIMARY KEY (`IDUSER`),
  KEY `fk_users_company` (`IDCOMPANY`),
  CONSTRAINT `fk_users_company` FOREIGN KEY (`IDCOMPANY`) REFERENCES `companys` (`IDCOMPANY`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.users: ~3 rows (aproximadamente)
INSERT INTO `users` (`IDUSER`, `NAME`, `SENHA`, `ADMIN`, `USER_ACTIVE`, `IDCOMPANY`) VALUES
	(1, 'BRUNO', '1234', 1, 1, 1),
	(4, 'TETE5', '1234', 1, 1, 1),
	(5, 'TESTE', '12345', 0, 0, 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
