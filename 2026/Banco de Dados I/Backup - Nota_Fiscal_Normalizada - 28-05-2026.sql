CREATE DATABASE  IF NOT EXISTS `nota_fiscal_normalizada` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `nota_fiscal_normalizada`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nota_fiscal_normalizada
-- ------------------------------------------------------
-- Server version	9.6.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '5c3f1841-0867-11f1-a085-0ccc47e1e675:1-261';

--
-- Table structure for table `item_nota_fiscal`
--

DROP TABLE IF EXISTS `item_nota_fiscal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item_nota_fiscal` (
  `NRO_NOTA` int NOT NULL,
  `COD_PRODUTO` int NOT NULL,
  `QTD_PRODUTO` int NOT NULL,
  `VL_PRECO` float NOT NULL,
  `VL_TOTAL` float NOT NULL,
  PRIMARY KEY (`NRO_NOTA`,`COD_PRODUTO`),
  KEY `FK_COD_PRODUTO_PRODUTO` (`COD_PRODUTO`),
  CONSTRAINT `FK_COD_PRODUTO_PRODUTO` FOREIGN KEY (`COD_PRODUTO`) REFERENCES `produto` (`COD_PRODUTO`),
  CONSTRAINT `FK_NRO_NOTA_FISCAL` FOREIGN KEY (`NRO_NOTA`) REFERENCES `nota_fiscal` (`NRO_NOTA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_nota_fiscal`
--

LOCK TABLES `item_nota_fiscal` WRITE;
/*!40000 ALTER TABLE `item_nota_fiscal` DISABLE KEYS */;
INSERT INTO `item_nota_fiscal` VALUES (1,1,1,4.5,4.5),(1,2,2,40,80),(1,3,10,100,1000),(2,1,1,100,100),(2,2,1,40,40),(2,3,2,100,200),(3,1,10,100,1000),(3,2,10,100,1000),(3,3,10,100,1000),(4,1,1,4.5,4.5),(4,2,2,40,80),(4,3,3,100,300);
/*!40000 ALTER TABLE `item_nota_fiscal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `nf_by_client`
--

DROP TABLE IF EXISTS `nf_by_client`;
/*!50001 DROP VIEW IF EXISTS `nf_by_client`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nf_by_client` AS SELECT 
 1 AS `CLIENTE`,
 1 AS `VALOR`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `nota_fiscal`
--

DROP TABLE IF EXISTS `nota_fiscal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nota_fiscal` (
  `NRO_NOTA` int NOT NULL AUTO_INCREMENT,
  `NM_CLIENTE` varchar(256) NOT NULL,
  `END_CLIENTE` varchar(256) NOT NULL,
  `NM_VENDEDOR` varchar(256) NOT NULL,
  `DT_EMISSAO` datetime DEFAULT CURRENT_TIMESTAMP,
  `VL_TOTAL` float NOT NULL,
  PRIMARY KEY (`NRO_NOTA`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nota_fiscal`
--

LOCK TABLES `nota_fiscal` WRITE;
/*!40000 ALTER TABLE `nota_fiscal` DISABLE KEYS */;
INSERT INTO `nota_fiscal` VALUES (1,'Aragon','Terra Média','Bilso','2026-05-29 00:04:48',100),(2,'Gandalf','Terra Média','Frodo','2026-05-29 00:04:48',100),(3,'Boromir','Mordor','Sam','2026-05-29 00:04:48',100),(4,'Galadriel','Valinor','Saruman','2026-05-29 00:04:48',100);
/*!40000 ALTER TABLE `nota_fiscal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produto` (
  `COD_PRODUTO` int NOT NULL AUTO_INCREMENT,
  `DESC_PRODUTO` varchar(256) NOT NULL,
  `UN_MED` char(2) NOT NULL,
  `VL_PRODUTO` float NOT NULL,
  PRIMARY KEY (`COD_PRODUTO`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES (1,'Leite','LT',4.5),(2,'Desodorante','UN',8),(4,'Teste Delete','LT',5.5);
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'nota_fiscal_normalizada'
--

--
-- Dumping routines for database 'nota_fiscal_normalizada'
--

--
-- Final view structure for view `nf_by_client`
--

/*!50001 DROP VIEW IF EXISTS `nf_by_client`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb3 */;
/*!50001 SET character_set_results     = utf8mb3 */;
/*!50001 SET collation_connection      = utf8mb3_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nf_by_client` AS select `nf`.`NM_CLIENTE` AS `CLIENTE`,sum(`inf`.`VL_TOTAL`) AS `VALOR` from (`nota_fiscal` `nf` join `item_nota_fiscal` `inf`) where (`nf`.`NRO_NOTA` = `inf`.`NRO_NOTA`) group by `nf`.`NM_CLIENTE` order by `VALOR` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-28 21:07:53
