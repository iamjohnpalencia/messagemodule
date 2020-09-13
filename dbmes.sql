-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2020 at 01:37 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbmes`
--
CREATE DATABASE IF NOT EXISTS `dbmes` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `dbmes`;

-- --------------------------------------------------------

--
-- Table structure for table `tbmessage`
--

DROP TABLE IF EXISTS `tbmessage`;
CREATE TABLE IF NOT EXISTS `tbmessage` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_` datetime NOT NULL DEFAULT current_timestamp(),
  `message_` text NOT NULL,
  `from_` text NOT NULL,
  `status_` text NOT NULL DEFAULT 'Unread',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

--
-- Truncate table before insert `tbmessage`
--

TRUNCATE TABLE `tbmessage`;
--
-- Dumping data for table `tbmessage`
--

INSERT INTO `tbmessage` (`id`, `date_`, `message_`, `from_`, `status_`) VALUES
(1, '2020-09-12 13:02:56', 'test message from admin,\r\n\r\nWELCOME and THANK YOU FOR CHOOSING US, \r\nWe want to bring you the best service as much as possible for that we would like to inform you that their might be a interval update to make things better.\r\n\r\nThank you for your understanding and hoping for a blessed business with you.', 'SYSTEM ADMINISTRATOR', 'Unread'),
(2, '2020-09-12 13:03:01', 'test message from admin,\r\n\r\nWELCOME and THANK YOU FOR CHOOSING US, \r\nWe want to bring you the best service as much as possible for that we would like to inform you that their might be a interval update to make things better.\r\n\r\nThank you for your understanding and hoping for a blessed business with you.', 'SYSTEM ADMINISTRATOR', 'Unread'),
(3, '2020-09-13 19:36:02', 'asdasdadasdadsasdad', 'Systema Moka', 'Unread'),
(4, '2020-09-13 19:36:02', 'asdasdadasdadsasdad', 'Systema Moka', 'Unread'),
(5, '2020-09-13 19:36:06', 'asdasdadasdadsasdad', 'Systema Moka', 'Unread'),
(6, '2020-09-13 19:36:06', 'asdasdadasdadsasdad', 'Systema Moka', 'Unread');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
