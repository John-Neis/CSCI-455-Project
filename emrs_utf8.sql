-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: emrs
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `financial_record`
--

DROP TABLE IF EXISTS `financial_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `financial_record` (
  `FID` int NOT NULL,
  `Inst_Type` enum('CU','Bank','CC') NOT NULL,
  `Acct_Num` int NOT NULL,
  `Rout_Num` int DEFAULT NULL,
  `Acct_Type` enum('CHECKING','SAVINGS','OTHER') DEFAULT NULL,
  PRIMARY KEY (`FID`),
  CONSTRAINT `financial_record_ibfk_1` FOREIGN KEY (`FID`) REFERENCES `patients` (`FinancialID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `financial_record`
--

LOCK TABLES `financial_record` WRITE;
/*!40000 ALTER TABLE `financial_record` DISABLE KEYS */;
INSERT INTO `financial_record` VALUES (1,'CU',66966,29164589,'CHECKING');
/*!40000 ALTER TABLE `financial_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insurance_record`
--

DROP TABLE IF EXISTS `insurance_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `insurance_record` (
  `IID` int NOT NULL,
  `Company_Code` int NOT NULL,
  `Agent_Num` int NOT NULL,
  PRIMARY KEY (`IID`),
  CONSTRAINT `insurance_record_ibfk_1` FOREIGN KEY (`IID`) REFERENCES `patients` (`InsuranceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insurance_record`
--

LOCK TABLES `insurance_record` WRITE;
/*!40000 ALTER TABLE `insurance_record` DISABLE KEYS */;
/*!40000 ALTER TABLE `insurance_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medical_record`
--

DROP TABLE IF EXISTS `medical_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medical_record` (
  `RecID` int NOT NULL AUTO_INCREMENT,
  `PatientID` varchar(50) NOT NULL,
  `PhysID` varchar(50) NOT NULL,
  `Treatment` text,
  `Prescription` text,
  `Appt_Date` date DEFAULT NULL,
  `Bill_Amt` float NOT NULL,
  `symptoms` text,
  `archive_flag` enum('0','1') DEFAULT NULL,
  PRIMARY KEY (`RecID`),
  KEY `PatientID` (`PatientID`),
  KEY `PhysID` (`PhysID`),
  CONSTRAINT `medical_record_ibfk_1` FOREIGN KEY (`PatientID`) REFERENCES `patients` (`UserID`),
  CONSTRAINT `medical_record_ibfk_2` FOREIGN KEY (`PhysID`) REFERENCES `physicians` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medical_record`
--

LOCK TABLES `medical_record` WRITE;
/*!40000 ALTER TABLE `medical_record` DISABLE KEYS */;
INSERT INTO `medical_record` VALUES (1,'JNeis','TanakaBam','Hello','Hello','2020-05-06',12.12,'Hello','0'),(4,'JNeis','TanakaBam','Hello','Hello','2020-05-06',420.69,'Hello','0'),(5,'JNeis','TanakaBam','Goodbye','DrugDrugDrug','2020-05-06',420.69,'Goodbye','0'),(6,'JNeis','TanakaBam',';laskdjfg;alkj`','a;lskjdfadf','2020-05-06',420.69,';alkisjdf;lkj','0'),(7,'KJameson','TanakaBam','Broken Femur. Ordered bone resetting and cast.','Painkillers and rest','2020-05-06',420.69,'Broken bone - Femur','0'),(8,'JNeis','TanakaBam','Test','Testerton','2020-05-06',420.69,'Testy','0');
/*!40000 ALTER TABLE `medical_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `UserID` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `FName` varchar(20) NOT NULL,
  `LName` varchar(20) NOT NULL,
  `Age` int NOT NULL,
  `Sex` char(1) NOT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `SSN` char(11) NOT NULL,
  `FinancialID` int DEFAULT NULL,
  `InsuranceID` int DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `FinancialID` (`FinancialID`),
  UNIQUE KEY `InsuranceID` (`InsuranceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES ('JNeis','hello','John','Neis',21,'M','111 Example St.','123-45-6789',1,1),('KJameson','Mullberry','Kyle','Winthrop',37,'M','10 Maple Rd','999-88-7777',NULL,3),('KSmith','Pass','Kim','Smith',24,'F','123 Oak Lane','111-22-3333',2,2);
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physicians`
--

DROP TABLE IF EXISTS `physicians`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `physicians` (
  `UserID` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `FName` varchar(50) NOT NULL,
  `LName` varchar(50) NOT NULL,
  `SSN` char(11) NOT NULL,
  `Title` varchar(50) NOT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physicians`
--

LOCK TABLES `physicians` WRITE;
/*!40000 ALTER TABLE `physicians` DISABLE KEYS */;
INSERT INTO `physicians` VALUES ('TanakaBam','Bonjour','Aihedo','Tanaka','111-22-3333','Medical Doctor');
/*!40000 ALTER TABLE `physicians` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-06 17:04:21
