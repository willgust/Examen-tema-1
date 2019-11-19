-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-10-2019 a las 21:40:52
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybetarchivo2`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuestas`
--

CREATE TABLE `apuestas` (
  `ID` int(15) NOT NULL,
  `tipo` varchar(25) DEFAULT NULL,
  `cuota` decimal(8,2) DEFAULT NULL,
  `apostado` decimal(8,2) DEFAULT NULL,
  `correo_usuario` varchar(25) DEFAULT NULL,
  `ID_mercados` int(15) DEFAULT NULL,
  `esOver` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `apuestas`
--

INSERT INTO `apuestas` (`ID`, `tipo`, `cuota`, `apostado`, `correo_usuario`, `ID_mercados`, `esOver`) VALUES
(1, '1.5', '1.36', '10.36', 'algo1@gmail.com', 1, b'1'),
(2, '2.5', '6.32', '5.23', 'algo2@gmail.com', 2, b'0'),
(13, '1.5', '1.00', '1000.00', 'algo1@gmail.com', 2, b'1'),
(14, '1.5', '0.00', '320.00', 'algo1@gmail.com', 2, b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `tarjeta` int(25) NOT NULL,
  `saldo` int(25) DEFAULT NULL,
  `banco` varchar(25) DEFAULT NULL,
  `correo_usuario` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`tarjeta`, `saldo`, `banco`, `correo_usuario`) VALUES
(4415121, 300, 'la caixa', 'algo2@gmail.com'),
(6523152, 50, 'sabadell', 'algo1@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE `eventos` (
  `ID` int(15) NOT NULL,
  `fecha` date DEFAULT NULL,
  `equipoLocal` varchar(25) DEFAULT NULL,
  `equipoVisitante` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`ID`, `fecha`, `equipoLocal`, `equipoVisitante`) VALUES
(1, '2019-09-11', 'valencia', 'madrid'),
(2, '2019-10-29', 'villareal', 'levante');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercados`
--

CREATE TABLE `mercados` (
  `ID` int(15) NOT NULL,
  `tipo` decimal(8,2) DEFAULT NULL,
  `cuotaOver` decimal(8,2) DEFAULT NULL,
  `cuotaUnder` decimal(8,2) DEFAULT NULL,
  `apostadoOver` decimal(8,2) DEFAULT NULL,
  `apostadoUnder` decimal(8,2) DEFAULT NULL,
  `ID_eventos` int(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mercados`
--

INSERT INTO `mercados` (`ID`, `tipo`, `cuotaOver`, `cuotaUnder`, `apostadoOver`, `apostadoUnder`, `ID_eventos`) VALUES
(1, '1.50', '4.23', '7.50', '0.00', '4.25', 1),
(2, '2.50', '3.12', '8.50', '0.00', '6.00', 2),
(3, '3.50', '2.00', '3.00', '10.00', '0.00', 1),
(4, '2.50', '2.00', '5.36', '0.00', '0.00', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `correo` varchar(50) NOT NULL,
  `edad` int(3) DEFAULT NULL,
  `nombre` varchar(25) DEFAULT NULL,
  `apellido` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`correo`, `edad`, `nombre`, `apellido`) VALUES
('algo1@gmail.com', 21, 'juanito', 'manco'),
('algo2@gmail.com', 25, 'pepe', 'navarro');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `correo_usuario` (`correo_usuario`),
  ADD KEY `ID_mercados` (`ID_mercados`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`tarjeta`),
  ADD KEY `correo_usuario` (`correo_usuario`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_eventos` (`ID_eventos`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`correo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  MODIFY `ID` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `ID` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `mercados`
--
ALTER TABLE `mercados`
  MODIFY `ID` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD CONSTRAINT `apuestas_fk1` FOREIGN KEY (`correo_usuario`) REFERENCES `usuarios` (`correo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `apuestas_fk2` FOREIGN KEY (`ID_mercados`) REFERENCES `mercados` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `cuentas_fk1` FOREIGN KEY (`correo_usuario`) REFERENCES `usuarios` (`correo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD CONSTRAINT `mercados_fk1` FOREIGN KEY (`ID_eventos`) REFERENCES `eventos` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
