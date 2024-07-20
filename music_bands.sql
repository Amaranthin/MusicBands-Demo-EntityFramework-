-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Време на генериране:  6 юли 2024 в 21:08
-- Версия на сървъра: 10.4.27-MariaDB
-- Версия на PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;


-- Създаване на базата данни 'music_bands'
CREATE DATABASE music_bands;
USE music_bands;
-- --------------------------------------------------------

--
-- Структура на таблица `bands`
--

CREATE TABLE `bands` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `formed_year` int(4) NOT NULL,
  `country_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `bands`
--

INSERT INTO `bands` (`id`, `name`, `formed_year`, `country_id`) VALUES
(1, 'Ace Of Base', 1987, 15),
(2, 'The Prodigy', 1990, 2),
(3, 'Nightwish', 1996, 21),
(7, 'Maniaci', 2012, 5);

-- --------------------------------------------------------

--
-- Структура на таблица `cities`
--

CREATE TABLE `cities` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `country_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `cities`
--

INSERT INTO `cities` (`id`, `name`, `country_id`) VALUES
(1, 'София', 1),
(2, 'Варна', 1),
(3, 'Пловдив', 1),
(4, 'Бургас', 1),
(5, 'Разград', 1),
(6, 'Лондон', 2),
(7, 'Бирмингам', 2),
(8, 'Лийдс', 2),
(9, 'Манчестър', 2),
(10, 'Берлин', 3),
(11, 'Мюнхен', 3),
(12, 'Кьолн', 3),
(13, 'Дортмунд', 3),
(14, 'Милано', 4),
(15, 'Рим', 4),
(16, 'Венеция', 4),
(17, 'Болоня', 4),
(18, 'Торино', 4),
(19, 'Барселона', 5),
(20, 'Мадрид', 5),
(21, 'Валенсия', 5),
(22, 'Севилия', 5),
(23, 'Москва', 6),
(24, 'Казан', 6),
(25, 'Краснодар', 6),
(26, 'Ню Йорк', 7),
(27, 'Чикаго', 7),
(28, 'Маями', 7),
(29, 'Далас', 7),
(30, 'Детройт', 7),
(31, 'Пекин', 8),
(32, 'Шънджън', 8),
(33, 'Шанхай', 8),
(34, 'Гуанджоу', 8),
(35, 'Сеул', 9),
(36, 'Бусан', 9),
(37, 'Инчеон', 9),
(38, 'Токио', 10),
(39, 'Киото', 10),
(40, 'Осака', 10),
(41, 'Йокохама', 10),
(42, 'Сидни', 11),
(43, 'Мелбърн', 11),
(44, 'Мануш', 12),
(45, 'Рио де Жанейро', 12),
(46, 'Буенос Айрес', 13),
(47, 'Мендоса', 13),
(48, 'Копенхаген', 14),
(49, 'Орхус', 14),
(50, 'Стокхолм', 15),
(51, 'Малмьо', 15),
(52, 'Амстердам', 16),
(53, 'Айндховен', 16),
(54, 'Валета', 17),
(55, 'Сингапур', 18);

-- --------------------------------------------------------

--
-- Структура на таблица `concerts`
--

CREATE TABLE `concerts` (
  `id` int(11) NOT NULL,
  `band_id` int(11) NOT NULL,
  `city_id` int(11) NOT NULL,
  `date_time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `concerts`
--

INSERT INTO `concerts` (`id`, `band_id`, `city_id`, `date_time`) VALUES
(1, 1, 12, '2024-11-05 22:00:00'),
(2, 2, 7, '2024-09-06 19:00:00'),
(3, 2, 36, '2024-07-06 13:29:26'),
(6, 3, 37, '2025-02-05 12:10:00');

-- --------------------------------------------------------

--
-- Структура на таблица `countries`
--

CREATE TABLE `countries` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `countries`
--

INSERT INTO `countries` (`id`, `name`) VALUES
(1, 'България'),
(2, 'Англия'),
(3, 'Германия'),
(4, 'Италия'),
(5, 'Испания'),
(6, 'Русия'),
(7, 'САЩ'),
(8, 'Китай'),
(9, 'Южна Корея'),
(10, 'Япония'),
(11, 'Австралия'),
(12, 'Бразилия'),
(13, 'Аржентина'),
(14, 'Дания'),
(15, 'Швеция'),
(16, 'Нидерландия'),
(17, 'Малта'),
(18, 'Сингапур'),
(19, 'Шотландия'),
(20, 'Ирландия'),
(21, 'Финландия');

-- --------------------------------------------------------

--
-- Структура на таблица `musicians`
--

CREATE TABLE `musicians` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `band_id` int(11) NOT NULL,
  `date_joined` datetime DEFAULT NULL COMMENT 'дата на влизане в бандата\r\n',
  `date_left` datetime DEFAULT NULL COMMENT 'дата на напускане'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `musicians`
--

INSERT INTO `musicians` (`id`, `person_id`, `band_id`, `date_joined`, `date_left`) VALUES
(1, 1, 1, '1990-01-01 00:31:17', '2007-07-07 00:31:17'),
(2, 2, 1, '1990-01-01 00:32:54', NULL),
(3, 3, 1, '1990-01-01 00:33:15', NULL),
(4, 4, 1, '1990-01-01 00:33:29', NULL),
(5, 5, 2, NULL, NULL),
(6, 6, 2, NULL, NULL),
(7, 7, 2, NULL, NULL),
(8, 8, 2, NULL, NULL),
(9, 9, 2, NULL, NULL),
(10, 10, 3, NULL, NULL),
(11, 11, 3, NULL, NULL),
(12, 12, 3, NULL, NULL),
(13, 13, 3, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура на таблица `people`
--

CREATE TABLE `people` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `family` varchar(32) NOT NULL,
  `age` int(2) DEFAULT NULL,
  `gender` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `people`
--

INSERT INTO `people` (`id`, `name`, `family`, `age`, `gender`) VALUES
(1, 'Лин', 'Бергрен', 53, 'ж'),
(2, 'Улф', 'Екберг', 53, 'м'),
(3, 'Йени', 'Бергрен', 52, 'ж'),
(4, 'Йонас', 'Бергрен', 57, 'м'),
(5, 'Кит', 'Флинт', NULL, 'м'),
(6, 'Лиъм', 'Халует', 52, 'м'),
(7, 'Лийрой', 'Торнхил', NULL, 'м'),
(8, 'Роб', 'Холидей', NULL, 'м'),
(9, 'Бен', 'Уайнман', NULL, 'м'),
(10, 'Таря', 'Турунен', NULL, 'ж'),
(11, 'Анет', 'Олсон', NULL, 'ж'),
(12, 'Марко', 'Хиетала', NULL, 'м'),
(13, 'Туомас', 'Холопайнен', NULL, 'м'),
(14, 'Григор', 'Димитров', 33, 'м'),
(18, 'Марко', 'Метъла', 15, 'м');

--
-- Indexes for dumped tables
--

--
-- Индекси за таблица `bands`
--
ALTER TABLE `bands`
  ADD PRIMARY KEY (`id`);

--
-- Индекси за таблица `cities`
--
ALTER TABLE `cities`
  ADD PRIMARY KEY (`id`),
  ADD KEY `country_id` (`country_id`);

--
-- Индекси за таблица `concerts`
--
ALTER TABLE `concerts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `band_id` (`band_id`),
  ADD KEY `city_id` (`city_id`);

--
-- Индекси за таблица `countries`
--
ALTER TABLE `countries`
  ADD PRIMARY KEY (`id`);

--
-- Индекси за таблица `musicians`
--
ALTER TABLE `musicians`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`),
  ADD KEY `band_id` (`band_id`);

--
-- Индекси за таблица `people`
--
ALTER TABLE `people`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bands`
--
ALTER TABLE `bands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `cities`
--
ALTER TABLE `cities`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;

--
-- AUTO_INCREMENT for table `concerts`
--
ALTER TABLE `concerts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `countries`
--
ALTER TABLE `countries`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `musicians`
--
ALTER TABLE `musicians`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `people`
--
ALTER TABLE `people`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `cities`
--
ALTER TABLE `cities`
  ADD CONSTRAINT `cities_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения за таблица `concerts`
--
ALTER TABLE `concerts`
  ADD CONSTRAINT `concerts_ibfk_2` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `concerts_ibfk_3` FOREIGN KEY (`band_id`) REFERENCES `bands` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения за таблица `musicians`
--
ALTER TABLE `musicians`
  ADD CONSTRAINT `musicians_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `people` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `musicians_ibfk_2` FOREIGN KEY (`band_id`) REFERENCES `bands` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
