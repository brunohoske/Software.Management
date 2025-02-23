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
  `DisplayMainPage` smallint NOT NULL DEFAULT '1',
  `CNPJ` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDCATEGORY`) USING BTREE,
  KEY `companys_fk` (`CNPJ`),
  CONSTRAINT `companys_fk` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.categories: ~3 rows (aproximadamente)
INSERT INTO `categories` (`IDCATEGORY`, `NAME`, `DESCRIPTION`, `DisplayMainPage`, `CNPJ`) VALUES
	(1, 'Carne', 'Hamburguers de carne', 1, '42591651000143'),
	(2, 'Frango', 'Hamburguers de Frango', 1, '42591651000143'),
	(3, 'Comprados com McChicken', 'Comprados com McChiken', 0, '42591651000143');

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

-- Copiando estrutura para tabela menusystem.combos
CREATE TABLE IF NOT EXISTS `combos` (
  `IDCOMBO` int NOT NULL AUTO_INCREMENT,
  `COMBO_NAME` varchar(60) NOT NULL,
  `COMBO_DESCRIPTION` varchar(150) DEFAULT NULL,
  `PRICE` double NOT NULL,
  `KCAL` double NOT NULL,
  `IMAGE` varchar(300) NOT NULL,
  `BARCODE` varchar(20) NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`IDCOMBO`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `combos_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos: ~0 rows (aproximadamente)
INSERT INTO `combos` (`IDCOMBO`, `COMBO_NAME`, `COMBO_DESCRIPTION`, `PRICE`, `KCAL`, `IMAGE`, `BARCODE`, `CNPJ`) VALUES
	(1, 'Burguer+Refri 2L', 'Hamburguer de carne + um refrigerante de 2L', 35.99, 70, 'https://www.otempo.com.br/content/dam/otempo/editorias/economia/2023/3/economia-preco-do-big-mac-minas-gerais-big-mac-mais-barato-big-mac-qual-big-mac-mais-barato-do-brasil-big-mac-mais-barato-do-mundo-1708498837.jpeg', '000000000000', '42591651000143');

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
  PRIMARY KEY (`ID`),
  KEY `IDCOMBO` (`IDCOMBO`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  CONSTRAINT `combos_products_ibfk_1` FOREIGN KEY (`IDCOMBO`) REFERENCES `combos` (`IDCOMBO`),
  CONSTRAINT `combos_products_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.combos_products: ~1 rows (aproximadamente)
INSERT INTO `combos_products` (`ID`, `IDCOMBO`, `IDPRODUCT`) VALUES
	(1, 1, 3);

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
  `CNPJ` varchar(20) NOT NULL,
  `COMPANY_NAME` varchar(50) NOT NULL,
  `IMAGE` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.companys: ~2 rows (aproximadamente)
INSERT INTO `companys` (`CNPJ`, `COMPANY_NAME`, `IMAGE`) VALUES
	('42591651000143', 'MCDONALDS', 'https://raichu-uploads.s3.amazonaws.com/logo_meatz-burger-n-beer_3NiBWD.png'),
	('53060216000109', 'BURGUERKING', 'https://raichu-uploads.s3.amazonaws.com/logo_meatz-burger-n-beer_3NiBWD.png');

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

-- Copiando estrutura para tabela menusystem.grupos
CREATE TABLE IF NOT EXISTS `grupos` (
  `IDGROUP` int NOT NULL AUTO_INCREMENT,
  `GROUP_NAME` varchar(80) NOT NULL,
  `VIEWNAME` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `GROUP_DESCRIPTION` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`IDGROUP`) USING BTREE,
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `grupos_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.grupos: ~2 rows (aproximadamente)
INSERT INTO `grupos` (`IDGROUP`, `GROUP_NAME`, `VIEWNAME`, `GROUP_DESCRIPTION`, `CNPJ`) VALUES
	(1, 'Refrigerantes 2L', 'Refrigerante 2L', 'Refrigerantes 2L', '42591651000143'),
	(2, 'Batatas Fritas', 'McFritas', 'Fritas', '42591651000143');

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
  PRIMARY KEY (`ID`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `IDGRUPO` (`IDGROUP`) USING BTREE,
  CONSTRAINT `grupos_products_ibfk_1` FOREIGN KEY (`IDGROUP`) REFERENCES `grupos` (`IDGROUP`),
  CONSTRAINT `grupos_products_ibfk_2` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.grupos_products: ~6 rows (aproximadamente)
INSERT INTO `grupos_products` (`ID`, `IDGROUP`, `IDPRODUCT`) VALUES
	(1, 1, 12),
	(2, 1, 13),
	(3, 1, 14),
	(4, 2, 11),
	(5, 2, 9),
	(6, 2, 10);

-- Copiando estrutura para tabela menusystem.ingredients
CREATE TABLE IF NOT EXISTS `ingredients` (
  `IdIngredient` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Description` varchar(250) DEFAULT NULL,
  `Cnpj` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`IdIngredient`) USING BTREE,
  KEY `FK_CNPJ` (`Cnpj`),
  CONSTRAINT `FK_CNPJ` FOREIGN KEY (`Cnpj`) REFERENCES `companys` (`CNPJ`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.ingredients: ~6 rows (aproximadamente)
INSERT INTO `ingredients` (`IdIngredient`, `Name`, `Description`, `Cnpj`) VALUES
	(1, 'Carne', '130g de hambúrguer', '42591651000143'),
	(2, 'Frango', '140g de Frango', '42591651000143'),
	(3, 'Picles', '4 fatias de picles', '42591651000143'),
	(4, 'Alface', 'Alface', '42591651000143'),
	(5, 'Bacon', '10g de Bacon', '42591651000143'),
	(6, 'Molho Ketchup', 'Molho', '42591651000143');

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
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.orders: ~10 rows (aproximadamente)
INSERT INTO `orders` (`IDORDER`, `CNPJ`, `TOTAL`, `ORDER_DATE`, `CHECK_NUMBER`, `ORDER_ACTIVE`, `ORDER_STATUS`) VALUES
	(56, '42591651000143', 40, '2025-02-23 03:55:25', 1, 1, 1),
	(57, '42591651000143', 76, '2025-02-23 14:25:27', 1, 1, 1);

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
  CONSTRAINT `order_details_ibfk_4` FOREIGN KEY (`CHECK_NUMBER`) REFERENCES `checks` (`CHECK_NUMBER`),
  CONSTRAINT `order_details_ibfk_5` FOREIGN KEY (`IDORDER`) REFERENCES `orders` (`IDORDER`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1612 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.order_details: ~35 rows (aproximadamente)
INSERT INTO `order_details` (`ID`, `IDORDER`, `CNPJ`, `IDPRODUCT`, `ITEM`, `CHECK_NUMBER`, `PRICE`, `ORDER_DATE`, `Note`) VALUES
	(1607, 56, '42591651000143', 3, 1, 1, 40, '2025-02-23 03:55:25', ''),
	(1608, 57, '42591651000143', 3, 1, 1, 40, '2025-02-23 14:25:27', ''),
	(1609, 57, '42591651000143', 3, 2, 1, 40, '2025-02-23 14:25:27', ''),
	(1610, 57, '42591651000143', 13, 3, 1, 9, '2025-02-23 14:25:27', ''),
	(1611, 57, '42591651000143', 11, 4, 1, 7, '2025-02-23 14:25:27', '');

-- Copiando estrutura para tabela menusystem.products
CREATE TABLE IF NOT EXISTS `products` (
  `IDPRODUCT` int NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IDCATEGORY` int DEFAULT (0),
  `CNPJ` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DESCRIPTION` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PRICE` float NOT NULL,
  `KCAL` float DEFAULT (0),
  `IMAGE` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `BARCODE` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '00000000000000000000',
  `ACTIVE` smallint NOT NULL DEFAULT (0),
  `SALEPRODUCT` smallint NOT NULL DEFAULT (1),
  PRIMARY KEY (`IDPRODUCT`),
  KEY `CNPJ` (`CNPJ`),
  KEY `categories_fk` (`IDCATEGORY`),
  CONSTRAINT `categories_fk` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`) ON DELETE SET NULL,
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products: ~13 rows (aproximadamente)
INSERT INTO `products` (`IDPRODUCT`, `PRODUCT_NAME`, `IDCATEGORY`, `CNPJ`, `DESCRIPTION`, `PRICE`, `KCAL`, `IMAGE`, `BARCODE`, `ACTIVE`, `SALEPRODUCT`) VALUES
	(1, 'McOferta McChicken', 1, '42591651000143', 'Um delicioso hamburguer de frango', 30, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$keX4W7gr/200/200/original?country=br', '00000000000000000000', 1, 0),
	(2, 'BK Whopper', 1, '53060216000109', 'Um delicioso hamburguer', 40, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png', '00000000000000000000', 1, 0),
	(3, 'McOferta BigMac', 2, '42591651000143', 'Dois hambúrgueres (100% carne bovina), alface americana, queijo processado sabor cheddar, molho especial, cebola, picles e pão com gergelim.', 40, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$kzXCTbnv/200/200/original?country=br', '00000000000000000000', 1, 0),
	(4, 'McLancheFeliz', 1, '42591651000143', 'O melhor para criançada', 20.2, 0, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$kJXZljtR/200/200/original?country=br', '00000000000000000000', 1, 0),
	(5, 'BK Whopper Plantas', 1, '53060216000109', 'Um delicioso hamburguer com o dobro de salada', 35.99, 0, 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png', '00000000000000000000', 1, 0),
	(7, 'teste', 1, '42591651000143', 'teste', 123, 0, 'https://mcdonalds.bg/wp-content/uploads/2023/01/BG_CSO_9108.png', '00000000000000000000', 1, 0),
	(8, 'BK Whopper', 1, '42591651000143', 'Um delicioso hamburguer', 40, 0, 'https://d3sn2rlrwxy0ce.cloudfront.net/_800x600_crop_center-center_none/whopper-thumb_2021-09-16-125319_mppe.png?mtime=20210916125320&focal=none&tmtime=20241024164409', '00000000000000000000', 1, 0),
	(9, 'McFritas - Média', 1, '42591651000143', '50g de Fritas', 10, 0, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1),
	(10, 'McFritas - Grande', 1, '42591651000143', '70g de Fritas', 13, 20, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1),
	(11, 'McFritas - Pequena', 1, '42591651000143', '30g de Fritas', 7, 10, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000000000000000', 1, 1),
	(12, 'Refrigerante Coca-Cola 2L', 1, '42591651000143', 'Refrigerante de 2L', 9.99, 10, 'https://ibassets.com.br/ib.item.image.large/l-6914a2bb4f5945e096287835120c831e.png', '00000000000000000000', 1, 1),
	(13, 'Refrigerante Guarana 2L', 1, '42591651000143', 'Refrigerante de 2L', 8.99, 10, 'https://choppbrahmaexpress.vtexassets.com/arquivos/ids/155720/guaran_2.png?v=637353454730230000', '00000000000000000000', 1, 1),
	(14, 'Refrigerante Pepsi 2L', 1, '42591651000143', 'Refrigerante de 2L', 8.99, 10, 'https://thepetitpizzaria.com.br/parobe/wp-content/uploads/2021/06/foto_original.png', '00000000000000000000', 1, 1);

-- Copiando estrutura para tabela menusystem.products_acompanhamentos
CREATE TABLE IF NOT EXISTS `products_acompanhamentos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PRODUCT` int NOT NULL,
  `ACOMPANHAMENTO` int NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `PRODUCT` (`PRODUCT`),
  KEY `ACOMPANHAMENTO` (`ACOMPANHAMENTO`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `products_acompanhamentos_ibfk_1` FOREIGN KEY (`PRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_acompanhamentos_ibfk_2` FOREIGN KEY (`ACOMPANHAMENTO`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_acompanhamentos_ibfk_3` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_acompanhamentos: ~3 rows (aproximadamente)
INSERT INTO `products_acompanhamentos` (`ID`, `PRODUCT`, `ACOMPANHAMENTO`, `CNPJ`) VALUES
	(3, 1, 11, '42591651000143'),
	(4, 1, 9, '42591651000143'),
	(5, 1, 10, '42591651000143'),
	(6, 3, 4, '42591651000143');

-- Copiando estrutura para tabela menusystem.products_categories
CREATE TABLE IF NOT EXISTS `products_categories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PRODUCT` int NOT NULL,
  `CATEGORY` int NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `PRODUCT` (`PRODUCT`),
  KEY `CATEGORY` (`CATEGORY`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `products_categories_ibfk_1` FOREIGN KEY (`PRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_categories_ibfk_2` FOREIGN KEY (`CATEGORY`) REFERENCES `categories` (`IDCATEGORY`),
  CONSTRAINT `products_categories_ibfk_3` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_categories: ~7 rows (aproximadamente)
INSERT INTO `products_categories` (`ID`, `PRODUCT`, `CATEGORY`, `CNPJ`) VALUES
	(1, 1, 1, '42591651000143'),
	(2, 1, 2, '42591651000143'),
	(3, 4, 1, '42591651000143'),
	(5, 3, 2, '42591651000143'),
	(6, 2, 3, '42591651000143'),
	(7, 4, 3, '42591651000143'),
	(8, 3, 3, '42591651000143');

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_ingrdients: ~5 rows (aproximadamente)
INSERT INTO `products_ingrdients` (`id`, `idProduct`, `idIngredient`, `Cnpj`) VALUES
	(6, 1, 2, '42591651000143'),
	(7, 3, 3, '42591651000143'),
	(8, 1, 5, '42591651000143'),
	(9, 1, 6, '42591651000143'),
	(10, 1, 4, '42591651000143');

-- Copiando estrutura para tabela menusystem.products_recommendations
CREATE TABLE IF NOT EXISTS `products_recommendations` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDPRODUCT` int NOT NULL,
  `IDCATEGORY` int NOT NULL,
  `CNPJ` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDPRODUCT` (`IDPRODUCT`),
  KEY `IDCATEGORY` (`IDCATEGORY`),
  KEY `CNPJ` (`CNPJ`),
  CONSTRAINT `products_recommendations_ibfk_1` FOREIGN KEY (`IDPRODUCT`) REFERENCES `products` (`IDPRODUCT`),
  CONSTRAINT `products_recommendations_ibfk_2` FOREIGN KEY (`IDCATEGORY`) REFERENCES `categories` (`IDCATEGORY`),
  CONSTRAINT `products_recommendations_ibfk_3` FOREIGN KEY (`CNPJ`) REFERENCES `companys` (`CNPJ`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela menusystem.products_recommendations: ~3 rows (aproximadamente)
INSERT INTO `products_recommendations` (`ID`, `IDPRODUCT`, `IDCATEGORY`, `CNPJ`) VALUES
	(1, 1, 3, '42591651000143'),
	(4, 1, 2, '42591651000143'),
	(5, 1, 1, '42591651000143');

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
