-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июл 18 2021 г., 23:55
-- Версия сервера: 8.0.24
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bithday`
--

-- --------------------------------------------------------

--
-- Структура таблицы `bithday`
--

CREATE TABLE `bithday` (
  `Id` int NOT NULL,
  `Name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `number` int NOT NULL,
  `mouth` int NOT NULL,
  `class` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `bithday`
--

INSERT INTO `bithday` (`Id`, `Name`, `number`, `mouth`, `class`) VALUES
(2, 'Радченко Виктор Григорьевич ', 34, 9, '@class1'),
(33, 'ertwerwe', 3, 2, 'Friend'),
(34, 'fgdfgdfg', 4, 7, 'tyrtyr'),
(35, 'Max Best', 22, 7, 'Friend');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `bithday`
--
ALTER TABLE `bithday`
  ADD UNIQUE KEY `Id` (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `bithday`
--
ALTER TABLE `bithday`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
