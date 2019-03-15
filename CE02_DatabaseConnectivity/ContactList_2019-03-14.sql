# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.23)
# Database: ContactList
# Generation Time: 2019-03-15 02:13:06 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table MyContacts
# ------------------------------------------------------------

DROP TABLE IF EXISTS `MyContacts`;

CREATE TABLE `MyContacts` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `PhoneNumber` varchar(50) DEFAULT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `Relation` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `MyContacts` WRITE;
/*!40000 ALTER TABLE `MyContacts` DISABLE KEYS */;

INSERT INTO `MyContacts` (`ID`, `FirstName`, `LastName`, `PhoneNumber`, `Email`, `Relation`)
VALUES
	(1,'Clark','Kent','2342342424','superman@gmail.com','Other'),
	(2,'Martha','Kent','2734848723','supermom@yahoo.com','Family'),
	(3,'John','Kent','2342342344','farmguy@msn.com','Family'),
	(4,'Lex','Luther','2434242356','lex@luthercorp.com','Business'),
	(5,'Lois','Lane','2435435355','llane@dailyplanet.com','Friend'),
	(6,'Pete','Ross','3565473453','peteross@gmail.com','Friend'),
	(7,'Lionel','Luther','4353653464','lionel@luthercorp.com','Business'),
	(8,'Dooms','Day','3564645234','destroyer@hotmail.com','Other'),
	(9,'Lana','Lang','3456543276','Lanalang@gmail.com','Friend');

/*!40000 ALTER TABLE `MyContacts` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
