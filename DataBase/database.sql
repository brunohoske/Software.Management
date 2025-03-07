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

-- Copiando dados para a tabela menusystem.combos_grupos: ~1 rows (aproximadamente)
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

-- Copiando dados para a tabela menusystem.combos_recommendations: ~0 rows (aproximadamente)
INSERT INTO `combos_recommendations` (`ID`, `IDCOMBO`, `IDCATEGORY`) VALUES
	(1, 1, 1);

-- Copiando estrutura para tabela menusystem.companys
CREATE TABLE IF NOT EXISTS `companys` (
  `IDCOMPANY` int NOT NULL AUTO_INCREMENT,
  `CNPJ` varchar(20) NOT NULL,
  `COMPANY_NAME` varchar(50) NOT NULL,
  `IMAGE` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`IDCOMPANY`),
  UNIQUE KEY `UNIQUE` (`CNPJ`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.companys: ~2 rows (aproximadamente)
INSERT INTO `companys` (`IDCOMPANY`, `CNPJ`, `COMPANY_NAME`, `IMAGE`) VALUES
	(1, '42591651000143', 'MCDONALDS', 'https://raichu-uploads.s3.amazonaws.com/logo_meatz-burger-n-beer_3NiBWD.png'),
	(2, '53060216000109', 'BURGUERKING', 'https://raichu-uploads.s3.amazonaws.com/logo_meatz-burger-n-beer_3NiBWD.png');

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
) ENGINE=InnoDB AUTO_INCREMENT=122 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.orders: ~14 rows (aproximadamente)

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
) ENGINE=InnoDB AUTO_INCREMENT=420 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~72 rows (aproximadamente)

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
