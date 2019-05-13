-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.3.14-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for chtr
CREATE DATABASE IF NOT EXISTS `chtr` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `chtr`;

-- Dumping structure for table chtr.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `Id` char(36) NOT NULL,
  `CreatedById` char(36) DEFAULT NULL,
  `CreatedInRoomId` char(36) DEFAULT NULL,
  `Content` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Messages_CreatedById` (`CreatedById`),
  KEY `IX_Messages_CreatedInRoomId` (`CreatedInRoomId`),
  CONSTRAINT `FK_Messages_Rooms_CreatedInRoomId` FOREIGN KEY (`CreatedInRoomId`) REFERENCES `rooms` (`Id`),
  CONSTRAINT `FK_Messages_Users_CreatedById` FOREIGN KEY (`CreatedById`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table chtr.rooms
CREATE TABLE IF NOT EXISTS `rooms` (
  `Id` char(36) NOT NULL,
  `Name` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table chtr.userroomrelation
CREATE TABLE IF NOT EXISTS `userroomrelation` (
  `UserId` char(36) NOT NULL,
  `RoomId` char(36) NOT NULL,
  PRIMARY KEY (`RoomId`,`UserId`),
  KEY `IX_UserRoomRelation_UserId` (`UserId`),
  CONSTRAINT `FK_UserRoomRelation_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `rooms` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRoomRelation_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table chtr.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` char(36) NOT NULL,
  `UserName` longtext DEFAULT NULL,
  `FullName` longtext DEFAULT NULL,
  `Avatar` longblob DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
