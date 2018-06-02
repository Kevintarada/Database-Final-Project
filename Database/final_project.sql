-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 02, 2018 at 10:43 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `final_project`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `tel_no` int(11) NOT NULL,
  `email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`id`, `name`, `address`, `tel_no`, `email`) VALUES
(1, 'Jack', 'Gajah Mada', 2147483647, 'longlongtjandra@gmail.com'),
(2, 'Bill', 'Hang Lengkir', 2147483647, 'arvavuvu@gmail.com'),
(3, 'Boboboi', 'Pluit', 2147483647, 'vuvukevin@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `emp_id` int(10) UNSIGNED NOT NULL,
  `emp_name` varchar(50) NOT NULL,
  `branch_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`emp_id`, `emp_name`, `branch_name`) VALUES
(1, 'Asoka', 'JKT'),
(2, 'Longlong', 'JKT'),
(3, 'Kevin', 'BDG'),
(4, 'Stefan', 'BDG'),
(5, 'Arva', 'SBY');

-- --------------------------------------------------------

--
-- Table structure for table `laptop`
--

CREATE TABLE `laptop` (
  `unit_id` int(10) UNSIGNED NOT NULL,
  `unit_name` varchar(50) NOT NULL,
  `price` int(11) NOT NULL,
  `stock` int(10) UNSIGNED NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `laptop`
--

INSERT INTO `laptop` (`unit_id`, `unit_name`, `price`, `stock`) VALUES
(1, 'ROG', 2200, 10),
(2, 'Lenovo', 1500, 10),
(3, 'MSI', 2000, 10),
(4, 'Alienware', 2500, 10),
(5, 'DELL', 1300, 8),
(6, 'Acer', 1300, 8),
(7, 'Asus', 1700, 5);

-- --------------------------------------------------------

--
-- Table structure for table `sparepart`
--

CREATE TABLE `sparepart` (
  `sp_id` int(10) UNSIGNED NOT NULL,
  `price` int(11) NOT NULL,
  `unit_id` int(10) UNSIGNED NOT NULL,
  `sp_name` varchar(50) NOT NULL,
  `spt_id` int(10) UNSIGNED NOT NULL,
  `stock` int(10) UNSIGNED NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sparepart`
--

INSERT INTO `sparepart` (`sp_id`, `price`, `unit_id`, `sp_name`, `spt_id`, `stock`) VALUES
(1, 500, 1, 'ROG I8P0', 1, 8),
(2, 600, 1, 'ROG F6Y5', 2, 7),
(3, 300, 1, 'ROG H9JK', 3, 3),
(4, 150, 1, 'ROG U7I9', 4, 5),
(5, 450, 2, 'MSI LLL9', 1, 9),
(6, 300, 2, 'MSI ONY0', 2, 1),
(7, 550, 3, 'ALIENWARE SK9W', 1, 4),
(8, 550, 3, 'ALIENWARE U8T6', 2, 2),
(9, 200, 3, 'ALIENWARE HB50', 4, 7),
(10, 350, 4, 'DELL RGB1', 2, 5),
(11, 450, 5, 'ASUS HJB8', 2, 3),
(12, 300, 5, 'ASUS YUT6', 3, 7),
(13, 350, 6, 'ACER TY9J', 1, 7),
(14, 200, 6, 'ACER WEW0', 3, 8);

-- --------------------------------------------------------

--
-- Table structure for table `sparepart_type`
--

CREATE TABLE `sparepart_type` (
  `spt_id` int(10) UNSIGNED NOT NULL,
  `spt_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sparepart_type`
--

INSERT INTO `sparepart_type` (`spt_id`, `spt_name`) VALUES
(1, 'Random Access Memory'),
(2, 'Graphic Card'),
(3, 'Motherboard'),
(4, 'Fan');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `trans_id` int(10) UNSIGNED NOT NULL,
  `unit_id` int(10) UNSIGNED DEFAULT NULL,
  `sp_id` int(10) UNSIGNED DEFAULT NULL,
  `price` int(11) NOT NULL,
  `cust_id` int(10) UNSIGNED NOT NULL,
  `emp_id` int(10) UNSIGNED NOT NULL,
  `trans_date` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`trans_id`, `unit_id`, `sp_id`, `price`, `cust_id`, `emp_id`, `trans_date`) VALUES
(1, 1, NULL, 2200, 2, 3, '06-01-2018'),
(2, NULL, 2, 600, 3, 1, '06-02-2018');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`emp_id`);

--
-- Indexes for table `laptop`
--
ALTER TABLE `laptop`
  ADD PRIMARY KEY (`unit_id`);

--
-- Indexes for table `sparepart`
--
ALTER TABLE `sparepart`
  ADD PRIMARY KEY (`sp_id`),
  ADD KEY `unit_id` (`unit_id`),
  ADD KEY `spt_id` (`spt_id`);

--
-- Indexes for table `sparepart_type`
--
ALTER TABLE `sparepart_type`
  ADD PRIMARY KEY (`spt_id`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`trans_id`),
  ADD KEY `unit_id` (`unit_id`),
  ADD KEY `sp_id` (`sp_id`),
  ADD KEY `cust_id` (`cust_id`),
  ADD KEY `emp_id` (`emp_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `emp_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `laptop`
--
ALTER TABLE `laptop`
  MODIFY `unit_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `sparepart`
--
ALTER TABLE `sparepart`
  MODIFY `sp_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `sparepart_type`
--
ALTER TABLE `sparepart_type`
  MODIFY `spt_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `trans_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `sparepart`
--
ALTER TABLE `sparepart`
  ADD CONSTRAINT `sparepart_ibfk_1` FOREIGN KEY (`unit_id`) REFERENCES `laptop` (`unit_id`),
  ADD CONSTRAINT `sparepart_ibfk_2` FOREIGN KEY (`spt_id`) REFERENCES `sparepart_type` (`spt_id`);

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`unit_id`) REFERENCES `laptop` (`unit_id`),
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`sp_id`) REFERENCES `sparepart` (`sp_id`),
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`cust_id`) REFERENCES `customer` (`id`),
  ADD CONSTRAINT `transaction_ibfk_4` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
