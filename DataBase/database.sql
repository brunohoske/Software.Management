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

-- Copiando dados para a tabela tablefy.categories: ~0 rows (aproximadamente)
INSERT INTO `categories` (`Id`, `CompanyId`, `Name`, `Description`, `DisplayMainPage`) VALUES
	(1, 1, 'Todos os Produtos', ' ', 1);

-- Copiando dados para a tabela tablefy.checks: ~1 rows (aproximadamente)
INSERT INTO `checks` (`Id`, `CompanyId`) VALUES
	(1, 1);

-- Copiando dados para a tabela tablefy.comboproducts: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.companies: ~1 rows (aproximadamente)
INSERT INTO `companies` (`Id`, `Cnpj`, `CompanyName`, `Image`, `Banner`, `CompaniesGroupId`) VALUES
	(1, '42591651000143', 'McDonald\'s', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThQAqgv62aJ4t7KStCfhhootuw1XlN9VY9FdXN0VXS2ljU8Pn3pW8IyzBI6Dsso5xj85k&usqp=CAU', 'https://media.confetti.ac.uk/joebrill/files/2020/11/McDonalds-Retro.jpg', 1);

-- Copiando dados para a tabela tablefy.companiesgroups: ~0 rows (aproximadamente)
INSERT INTO `companiesgroups` (`Id`, `Nome`, `UserId`) VALUES
	(1, 'McDonald\'s', 1);

-- Copiando dados para a tabela tablefy.coupons: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.employeecompanyentity: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.employees: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.ingredients: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.orderproducts: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.orders: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.productcategories: ~0 rows (aproximadamente)
INSERT INTO `productcategories` (`CategoryId`, `ProductId`) VALUES
	(1, 1),
	(1, 2);

-- Copiando dados para a tabela tablefy.productingredients: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.productrecommendations: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.products: ~0 rows (aproximadamente)
INSERT INTO `products` (`Id`, `ProductName`, `CompaniesGroupId`, `Description`, `Kcal`, `Image`, `Barcode`, `IsCombo`) VALUES
	(1, 'McChicken', 1, 'Hambuerguer de frango', 54, 'https://cache-mcd-middleware.mcdonaldscupones.com/media/image/product$keX4W7gr/200/200/original?country=br', '00000000', 0),
	(2, 'Combo McChicken + Refri + Batata', 1, 'McChicken + refri lata 350 ml + Batata Frita', 90, 'https://www.otempo.com.br/content/dam/otempo/editorias/economia/2023/3/economia-preco-do-big-mac-minas-gerais-big-mac-mais-barato-big-mac-qual-big-mac-mais-barato-do-brasil-big-mac-mais-barato-do-mundo-1708498837.jpeg', '00000000', 1),
	(3, 'Batata Frita Pequena', 1, 'Batata 20g', 18, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000', 0),
	(4, 'Batata Frita Média', 1, 'Batata 50g', 22, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000', 0),
	(5, 'Batata Frita Grande', 1, 'Batata 70g', 25, 'https://png.pngtree.com/png-vector/20240130/ourmid/pngtree-french-fried-chips-isolated-png-png-image_11572782.png', '00000000', 0);

-- Copiando dados para a tabela tablefy.productscompany: ~0 rows (aproximadamente)
INSERT INTO `productscompany` (`CompanyId`, `ProductId`, `Price`, `Active`, `SaleProduct`, `PercentageDiscount`, `ValueDiscount`) VALUES
	(1, 1, 20.00, 1, 1, 0.00, 0.00),
	(1, 2, 45.00, 1, 1, 0.00, 0.00);

-- Copiando dados para a tabela tablefy.productsides: ~0 rows (aproximadamente)

-- Copiando dados para a tabela tablefy.selectiongroupproducts: ~0 rows (aproximadamente)
INSERT INTO `selectiongroupproducts` (`ProductId`, `SelectionGroupId`, `Price`) VALUES
	(3, 1, 7.00),
	(4, 1, 10.00),
	(5, 1, 12.00);

-- Copiando dados para a tabela tablefy.selectiongroups: ~0 rows (aproximadamente)
INSERT INTO `selectiongroups` (`Id`, `GroupName`, `ViewName`, `GroupDescription`, `CompanyId`) VALUES
	(1, 'Batatas', 'Batata Frita', 'Refrigerantes', 1);

-- Copiando dados para a tabela tablefy.users: ~0 rows (aproximadamente)
INSERT INTO `users` (`Id`, `Email`, `Password`) VALUES
	(1, 'mcdonalds@gmail.com', '1234');

-- Copiando dados para a tabela tablefy.__efmigrationshistory: ~1 rows (aproximadamente)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250311201139_Initial', '8.0.13'),
	('20250311211152_Initial2', '8.0.13'),
	('20250312043944_initial3', '8.0.13'),
	('20250313013108_Initial4', '8.0.13'),
	('20250313031555_Initial4', '8.0.13'),
	('20250313035719_Initial5', '8.0.13'),
	('20250313040709_Initial6', '8.0.13'),
	('20250313043631_Initial7', '8.0.13'),
	('20250314033442_Initial', '8.0.13');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
