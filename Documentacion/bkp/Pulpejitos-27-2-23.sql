-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: pulpejitos_desarrollo
-- ------------------------------------------------------
-- Server version	8.0.22-13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
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


--
-- Table structure for table `categoriaproductos`
--

DROP TABLE IF EXISTS `categoriaproductos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoriaproductos` (
  `idCategoriaProducto` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idCategoriaProducto`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoriaproductos`
--

LOCK TABLES `categoriaproductos` WRITE;
/*!40000 ALTER TABLE `categoriaproductos` DISABLE KEYS */;
INSERT INTO `categoriaproductos` VALUES (1,'Balanceados','2023-01-27 00:00:00',1),(2,'Clínica','2023-01-27 00:00:00',1),(3,'Farmacia','2023-01-27 00:00:00',1),(4,'Pet','2023-01-27 00:00:00',1),(5,'Proveedores','2023-01-27 00:00:00',1),(6,'Terceros','2023-01-27 00:00:00',1);
/*!40000 ALTER TABLE `categoriaproductos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cirugia`
--

DROP TABLE IF EXISTS `cirugia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cirugia` (
  `idCirugia` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `DiagnosticoInicial` varchar(400) DEFAULT NULL,
  `DiasDeInternacion` int DEFAULT NULL,
  `FechaProximoControl` datetime DEFAULT NULL,
  `Descripcion` varchar(400) DEFAULT NULL,
  `idMascota` int NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idCirugia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cirugia`
--

LOCK TABLES `cirugia` WRITE;
/*!40000 ALTER TABLE `cirugia` DISABLE KEYS */;
/*!40000 ALTER TABLE `cirugia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `Dni` varchar(200) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Telefono` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'10','Maradona','Diego','221563952','diego@gol.com.ar','2023-02-16 13:37:51',1),(2,'11','Di Maria','Angel','22152369','fideoGol@gmail.com','2023-02-16 13:39:26',1),(3,'2036','Imoli','Luca','22147896325','','2023-02-17 11:11:43',1),(4,'2037','Imoli','Joaquin','234324234234','','2023-02-17 11:13:45',1),(5,'33254789','Perez','Clavo','','','2023-02-17 12:11:40',1);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuentacorriente`
--

DROP TABLE IF EXISTS `cuentacorriente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuentacorriente` (
  `idCuentaCorriente` int NOT NULL AUTO_INCREMENT,
  `Monto` decimal(10,2) NOT NULL,
  `Fecha` datetime NOT NULL,
  `MontoAdeudado` decimal(10,2) NOT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idCuentaCorriente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuentacorriente`
--

LOCK TABLES `cuentacorriente` WRITE;
/*!40000 ALTER TABLE `cuentacorriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuentacorriente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleventas`
--

DROP TABLE IF EXISTS `detalleventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalleventas` (
  `idDetalleVentas` int NOT NULL AUTO_INCREMENT,
  `idProducto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `PrecioUnitario` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idDetalleVentas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventas`
--

LOCK TABLES `detalleventas` WRITE;
/*!40000 ALTER TABLE `detalleventas` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalleventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especies`
--

DROP TABLE IF EXISTS `especies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especies` (
  `idEspecie` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idEspecie`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especies`
--

LOCK TABLES `especies` WRITE;
/*!40000 ALTER TABLE `especies` DISABLE KEYS */;
INSERT INTO `especies` VALUES (1,'Canino','2023-01-27 00:00:00',1),(2,'Felino','2023-01-27 00:00:00',1),(3,'Animales domésticos no tradicionales','2023-01-27 00:00:00',1);
/*!40000 ALTER TABLE `especies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fichamedica`
--

DROP TABLE IF EXISTS `fichamedica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fichamedica` (
  `idFichaMedica` int NOT NULL AUTO_INCREMENT,
  `idMascota` int NOT NULL,
  `idTipoAtencion` int NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idFichaMedica`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fichamedica`
--

LOCK TABLES `fichamedica` WRITE;
/*!40000 ALTER TABLE `fichamedica` DISABLE KEYS */;
/*!40000 ALTER TABLE `fichamedica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historialStockPorProducto`
--

DROP TABLE IF EXISTS `historialStockPorProducto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historialStockPorProducto` (
  `idHistorialStockPorProducto` int NOT NULL AUTO_INCREMENT,
  `idProducto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `ValorUnitario` decimal(10,2) NOT NULL,
  `ValorTotal` decimal(10,2) NOT NULL,
  `idIngresoStock` int NOT NULL,
  `idSucursal` int NOT NULL,
  PRIMARY KEY (`idHistorialStockPorProducto`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historialStockPorProducto`
--

LOCK TABLES `historialStockPorProducto` WRITE;
/*!40000 ALTER TABLE `historialStockPorProducto` DISABLE KEYS */;
INSERT INTO `historialStockPorProducto` VALUES (11,2,100,260.00,26000.00,11,1);
/*!40000 ALTER TABLE `historialStockPorProducto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresodestock`
--

DROP TABLE IF EXISTS `ingresodestock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingresodestock` (
  `idIngresoDeStock` int NOT NULL AUTO_INCREMENT,
  `idProveedor` int NOT NULL,
  `FechaFactura` datetime DEFAULT NULL,
  `Remito` varchar(200) DEFAULT NULL,
  `MontoTotal` decimal(10,2) NOT NULL,
  `FechaRegistro` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idIngresoDeStock`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresodestock`
--

LOCK TABLES `ingresodestock` WRITE;
/*!40000 ALTER TABLE `ingresodestock` DISABLE KEYS */;
INSERT INTO `ingresodestock` VALUES (11,1,'2023-02-13 00:00:00','12598746',26000.00,'2023-02-13 12:30:04',1);
/*!40000 ALTER TABLE `ingresodestock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `marcas` (
  `idMarca` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idMarca`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marcas`
--

LOCK TABLES `marcas` WRITE;
/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES (1,'No Especifica','2023-02-07 00:00:00',1);
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mascotas`
--

DROP TABLE IF EXISTS `mascotas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mascotas` (
  `idMascota` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaNacimiento` datetime DEFAULT NULL,
  `idEspecie` int NOT NULL,
  `idRaza` int NOT NULL,
  `idCliente` int NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idMascota`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mascotas`
--

LOCK TABLES `mascotas` WRITE;
/*!40000 ALTER TABLE `mascotas` DISABLE KEYS */;
INSERT INTO `mascotas` VALUES (1,'PICHICHO goleador','2020-02-16 00:00:00',1,1,1,'2023-02-27 15:35:55',1),(2,'FATIGA','2018-07-01 00:00:00',1,5,1,'2023-02-16 13:37:51',1),(3,'CACAO','2021-02-01 00:00:00',2,61,2,'2023-02-27 12:34:44',1),(4,'TACHUELA','1986-06-01 00:00:00',3,76,5,'2023-02-27 13:05:04',1),(5,'PUFLITO','2021-01-01 00:00:00',3,67,3,'2023-02-27 13:07:19',1);
/*!40000 ALTER TABLE `mascotas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menuporperfil`
--

DROP TABLE IF EXISTS `menuporperfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menuporperfil` (
  `idMenuPorPerfil` int NOT NULL AUTO_INCREMENT,
  `idPerfil` int NOT NULL,
  `NombreMenu` varchar(200) NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idMenuPorPerfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menuporperfil`
--

LOCK TABLES `menuporperfil` WRITE;
/*!40000 ALTER TABLE `menuporperfil` DISABLE KEYS */;
/*!40000 ALTER TABLE `menuporperfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagoaproveedores`
--

DROP TABLE IF EXISTS `pagoaproveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagoaproveedores` (
  `idPagoAProveedores` int NOT NULL AUTO_INCREMENT,
  `Monto` decimal(10,2) NOT NULL,
  `FechaPago` datetime NOT NULL,
  `MontoAdeudado` decimal(10,2) NOT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idPagoAProveedores`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagoaproveedores`
--

LOCK TABLES `pagoaproveedores` WRITE;
/*!40000 ALTER TABLE `pagoaproveedores` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagoaproveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfiles`
--

DROP TABLE IF EXISTS `perfiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `perfiles` (
  `idPerfil` int NOT NULL AUTO_INCREMENT,
  `NombrePerfil` varchar(200) NOT NULL,
  `Estado` int NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idPerfil`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfiles`
--

LOCK TABLES `perfiles` WRITE;
/*!40000 ALTER TABLE `perfiles` DISABLE KEYS */;
INSERT INTO `perfiles` VALUES (1,'Administrador',1,1),(2,'Ventas',1,1),(3,'Veterinaria',1,1);
/*!40000 ALTER TABLE `perfiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preciodeventa`
--

DROP TABLE IF EXISTS `preciodeventa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preciodeventa` (
  `idPrecioDeVenta` int NOT NULL AUTO_INCREMENT,
  `idProducto` int NOT NULL,
  `Precio` decimal(10,2) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idPrecioDeVenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preciodeventa`
--

LOCK TABLES `preciodeventa` WRITE;
/*!40000 ALTER TABLE `preciodeventa` DISABLE KEYS */;
/*!40000 ALTER TABLE `preciodeventa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productos` (
  `idproducto` int NOT NULL AUTO_INCREMENT,
  `CodigoProducto` varchar(200) NOT NULL,
  `idCategoriaProducto` int NOT NULL,
  `Descripcion` varchar(200) NOT NULL,
  `idMarca` varchar(200) DEFAULT NULL,
  `idUnidadDeMedicion` int DEFAULT NULL,
  `PrecioDeVenta` decimal(10,2) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idproducto`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (2,'123456',1,'Dog Chaw 10Kilos','1',1,0.00,'2023-02-08 10:33:21',1),(4,'23456',1,'Pastilla de carbon','1',1,0.00,'2023-02-08 15:50:05',1),(5,'999311132202315410',1,'Pastilla para el dolor de cabeza Perros','1',1,0.00,'2023-02-13 15:04:40',1),(6,'999212132202315736',1,'Pinzas para oídos','1',1,0.00,'2023-02-13 15:08:08',1),(7,'9991121322023151032',1,'Comida para gatos','1',1,0.00,'2023-02-13 15:10:46',1);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedores` (
  `idproveedor` int NOT NULL AUTO_INCREMENT,
  `NombreEmpresa` varchar(200) NOT NULL,
  `NombreContacto` varchar(200) DEFAULT NULL,
  `Calle` varchar(200) DEFAULT NULL,
  `Altura` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Telefono` varchar(200) DEFAULT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idproveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'Hola Mundo','Leonel Jopo','47','5235','','2213698745',1),(2,'Andrulo SA','Andres Silvestri','','','','221-526314',1),(3,'Luca SA','Luca Imoli','213','569','','221526398',1);
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raza`
--

DROP TABLE IF EXISTS `raza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `raza` (
  `idRaza` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `idEspecie` int DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idRaza`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raza`
--

LOCK TABLES `raza` WRITE;
/*!40000 ALTER TABLE `raza` DISABLE KEYS */;
INSERT INTO `raza` VALUES (1,'Airedale Terrier',1,'2023-01-27 00:00:00',1),(2,'Akita Inu',1,'2023-01-27 00:00:00',1),(3,'Alaskan Malamute',1,'2023-01-27 00:00:00',1),(4,'Basset Hound',1,'2023-01-27 00:00:00',1),(5,'Beagle',1,'2023-01-27 00:00:00',1),(6,'Bichón Frisé',1,'2023-01-27 00:00:00',1),(7,'Bichón Maltés',1,'2023-01-27 00:00:00',1),(8,'Bloodhound',1,'2023-01-27 00:00:00',1),(9,'Border Collie',1,'2023-01-27 00:00:00',1),(10,'Bóxer',1,'2023-01-27 00:00:00',1),(11,'Boyero de Berna',1,'2023-01-27 00:00:00',1),(12,'Braco',1,'2023-01-27 00:00:00',1),(13,'Bretón',1,'2023-01-27 00:00:00',1),(14,'Bull Terrier',1,'2023-01-27 00:00:00',1),(15,'Bulldog Francés',1,'2023-01-27 00:00:00',1),(16,'Bulldog Inglés',1,'2023-01-27 00:00:00',1),(17,'Bullmastiff ',1,'2023-01-27 00:00:00',1),(18,'Caniche',1,'2023-01-27 00:00:00',1),(19,'Chihuahua',1,'2023-01-27 00:00:00',1),(20,'Chow',1,'2023-01-27 00:00:00',1),(21,'Cocker',1,'2023-01-27 00:00:00',1),(22,'Dachshund ',1,'2023-01-27 00:00:00',1),(23,'Dálmata',1,'2023-01-27 00:00:00',1),(24,'Dobermann',1,'2023-01-27 00:00:00',1),(25,'Dogo Argentino',1,'2023-01-27 00:00:00',1),(26,'Dogo de Burdeos',1,'2023-01-27 00:00:00',1),(27,'Fila Brasilero',1,'2023-01-27 00:00:00',1),(28,'Fox Terrier',1,'2023-01-27 00:00:00',1),(29,'Galgo',1,'2023-01-27 00:00:00',1),(30,'Galgo Afgano',1,'2023-01-27 00:00:00',1),(31,'Golden Retriever',1,'2023-01-27 00:00:00',1),(32,'Gran Danés',1,'2023-01-27 00:00:00',1),(33,'Husky Siberiano',1,'2023-01-27 00:00:00',1),(34,'Jack Russell Terrier',1,'2023-01-27 00:00:00',1),(35,'Labrador',1,'2023-01-27 00:00:00',1),(36,'Mastín Napolitano',1,'2023-01-27 00:00:00',1),(37,'Mestizo',1,'2023-01-27 00:00:00',1),(38,'Ovejero Alemán',1,'2023-01-27 00:00:00',1),(39,'Ovejero Belga',1,'2023-01-27 00:00:00',1),(40,'Ovejero Malinois',1,'2023-01-27 00:00:00',1),(41,'Pekinés',1,'2023-01-27 00:00:00',1),(42,'Pincher',1,'2023-01-27 00:00:00',1),(43,'Pitbull',1,'2023-01-27 00:00:00',1),(44,'Pointer',1,'2023-01-27 00:00:00',1),(45,'Pomerania',1,'2023-01-27 00:00:00',1),(46,'Pug',1,'2023-01-27 00:00:00',1),(47,'Rhodesian',1,'2023-01-27 00:00:00',1),(48,'Rottwailer',1,'2023-01-27 00:00:00',1),(49,'Samoyedo',1,'2023-01-27 00:00:00',1),(50,'San Bernardo',1,'2023-01-27 00:00:00',1),(51,'Schanauzer',1,'2023-01-27 00:00:00',1),(52,'Setter Inglés',1,'2023-01-27 00:00:00',1),(53,'Setter Irlandés',1,'2023-01-27 00:00:00',1),(54,'Shar Pei',1,'2023-01-27 00:00:00',1),(55,'Terranova ',1,'2023-01-27 00:00:00',1),(56,'Viejo Pastor Inglés',1,'2023-01-27 00:00:00',1),(57,'Weimaraner',1,'2023-01-27 00:00:00',1),(58,'Yorkshire',1,'2023-01-27 00:00:00',1),(59,'Angora',2,'2023-01-27 00:00:00',1),(60,'Bengalí',2,'2023-01-27 00:00:00',1),(61,'Europeo',2,'2023-01-27 00:00:00',1),(62,'Imalaya',2,'2023-01-27 00:00:00',1),(63,'Persa',2,'2023-01-27 00:00:00',1),(64,'Siamés',2,'2023-01-27 00:00:00',1),(65,'Canario',3,'2023-01-27 00:00:00',1),(66,'Cobayo',3,'2023-01-27 00:00:00',1),(67,'Conejo',3,'2023-01-27 00:00:00',1),(68,'Cotorra',3,'2023-01-27 00:00:00',1),(69,'Gallina',3,'2023-01-27 00:00:00',1),(70,'Ganso',3,'2023-01-27 00:00:00',1),(71,'Hamster',3,'2023-01-27 00:00:00',1),(72,'Hurón',3,'2023-01-27 00:00:00',1),(73,'Loro',3,'2023-01-27 00:00:00',1),(74,'Paloma',3,'2023-01-27 00:00:00',1),(75,'Pato',3,'2023-01-27 00:00:00',1),(76,'Tortuga',3,'2023-01-27 00:00:00',1);
/*!40000 ALTER TABLE `raza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock` (
  `idStock` int NOT NULL AUTO_INCREMENT,
  `idProducto` varchar(45) NOT NULL,
  `StockTotal` int NOT NULL,
  PRIMARY KEY (`idStock`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (1,'2',100),(2,'3',0),(3,'4',0),(4,'5',0),(5,'6',0),(6,'7',0);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sucursales` (
  `idsucursal` int NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Calle` varchar(200) DEFAULT NULL,
  `Altura` varchar(200) DEFAULT NULL,
  `Provincia` int DEFAULT NULL,
  `Localidad` int DEFAULT NULL,
  `CodigoPostal` varchar(200) DEFAULT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idsucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` VALUES (1,'Pulpejitos 44','44',NULL,2,2315,'1900',1);
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoatencion`
--

DROP TABLE IF EXISTS `tipoatencion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoatencion` (
  `idTipoAtencion` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idTipoAtencion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoatencion`
--

LOCK TABLES `tipoatencion` WRITE;
/*!40000 ALTER TABLE `tipoatencion` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipoatencion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidadesdemedicion`
--

DROP TABLE IF EXISTS `unidadesdemedicion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidadesdemedicion` (
  `idUnidadesDeMedicion` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idUnidadesDeMedicion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidadesdemedicion`
--

LOCK TABLES `unidadesdemedicion` WRITE;
/*!40000 ALTER TABLE `unidadesdemedicion` DISABLE KEYS */;
INSERT INTO `unidadesdemedicion` VALUES (1,'Unidades','2023-01-27 00:00:00',1),(2,'Kilos','2023-01-27 00:00:00',1);
/*!40000 ALTER TABLE `unidadesdemedicion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `idUsuario` int NOT NULL AUTO_INCREMENT,
  `Dni` varchar(10) NOT NULL,
  `Apellido` varchar(200) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Contrasenia` varchar(200) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `FechaUltimaConexion` datetime DEFAULT NULL,
  `idPerfil` int NOT NULL,
  `Estado` int NOT NULL,
  `idUsuarioAlta` int NOT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'1234','Admin','Admin','nJWttVYrEbw=','2023-02-07 00:00:00','2023-02-07 00:00:00',1,1,1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarioporsucursal`
--

DROP TABLE IF EXISTS `usuarioporsucursal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarioporsucursal` (
  `idusuarioPorSucursal` int NOT NULL AUTO_INCREMENT,
  `idUsuario` int NOT NULL,
  `idSucursal` int NOT NULL,
  `idUsuarioAlta` int NOT NULL,
  PRIMARY KEY (`idusuarioPorSucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarioporsucursal`
--

LOCK TABLES `usuarioporsucursal` WRITE;
/*!40000 ALTER TABLE `usuarioporsucursal` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarioporsucursal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vacunacion`
--

DROP TABLE IF EXISTS `vacunacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vacunacion` (
  `idVacunacion` int NOT NULL AUTO_INCREMENT,
  `NombreCampaña` varchar(200) NOT NULL,
  `Lote` varchar(200) DEFAULT NULL,
  `FechaAplicacion` datetime NOT NULL,
  `FechaProximaAplicacion` datetime DEFAULT NULL,
  `idMascota` int NOT NULL,
  `Descripcion` varchar(400) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idVacunacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacunacion`
--

LOCK TABLES `vacunacion` WRITE;
/*!40000 ALTER TABLE `vacunacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `vacunacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ventas` (
  `idventa` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `PrecioTotalDeVenta` decimal(10,2) NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idventa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'bksi9gvlsu8lbmkjd1p7'
--

--
-- Dumping routines for database 'bksi9gvlsu8lbmkjd1p7'
--
/*!50003 DROP PROCEDURE IF EXISTS `SP_Actualizar_Producto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Actualizar_Producto`(IN 
idProducto_in int,
CodigoProducto_in varchar(200),
idCategoriaProducto_in int,
Descripcion_in varchar(200),
idMarca_in int,
idUnidadDeMedicion_in int,
PrecioDeVenta_in decimal(10,2),
FechaDeAlta_in datetime,
idUsuario_in int)
BEGIN
Update productos set
CodigoProducto  = CodigoProducto_in,
idCategoriaProducto = idCategoriaProducto_in,
Descripcion  = Descripcion_in,
idMarca = idMarca_in,
idUnidadDeMedicion = idUnidadDeMedicion_in,
PrecioDeVenta = PrecioDeVenta_in,
FechaAlta = FechaDeAlta_in,
idUsuario = idUsuario_in
where idProducto = idProducto_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Actualizar_Stock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Actualizar_Stock`(IN 
idProducto_in int,
StockActualizado_in int)
BEGIN
update stock
set StockTotal = StockActualizado_in
where idProducto = idProducto_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_BuscarClientePorDni` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_BuscarClientePorDni`(IN
 NroDni_in varchar(200))
BEGIN
Select * From clientes where
Dni = NroDni_in
order by idcliente desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_BuscarProductoPorCodigo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_BuscarProductoPorCodigo`(IN 
descripcion_in varchar(200))
BEGIN
select p.idProducto,
 p.CodigoProducto,
 p.Descripcion,
 m.Nombre as NombreMarca 
from productos p
left join stock s on (p.idProducto = s.idProducto)
inner join marcas m on(p.idMarca = m.idMarca) 
where p.CodigoProducto = descripcion_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_BuscarProveedorPorID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_BuscarProveedorPorID`(IN
 IdProveedor_in int)
BEGIN
Select * From proveedores where
 (idProveedor = IdProveedor_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarCategorias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarCategorias`()
BEGIN
Select * From categoriaproductos order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarClientePorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarClientePorId`(IN 
idCliente_in int)
BEGIN
Select * From clientes where
 (idCliente = idCliente_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarClientes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarClientes`()
BEGIN
Select * From clientes limit 17;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarEspecies` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarEspecies`()
BEGIN
Select * From especies order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarMarcas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarMarcas`()
BEGIN
Select * From marcas order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarMascotaPorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarMascotaPorId`(IN 
idMascotaSeleccionada_in int)
BEGIN
select MA.*, CLI.idCliente as idCliente, CLI.Dni as DniCliente, CLI.Apellido as ApellidoCliente, CLI.Nombre as NombreCliente, ES.Nombre as NombreEspecie, RA.Nombre as NombreRaza  from mascotas as MA
inner join clientes as CLI on MA.idCliente = CLI.idCliente
inner join especies as ES on MA.idEspecie = ES.idEspecie
inner join raza as RA on MA.idRaza = RA.idRaza
where MA.idMascota = idMascotaSeleccionada_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarMascotas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarMascotas`()
BEGIN
select MA.*, ES.Nombre as NombreEspecie, RA.Nombre as NombreRaza  from mascotas as MA
inner join clientes as CLI on MA.idCliente = CLI.idCliente
inner join especies as ES on MA.idEspecie = ES.idEspecie
inner join raza as RA on MA.idRaza = RA.idRaza
limit 17;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarMascotasPorFiltros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarMascotasPorFiltros`(in
dni_in varchar(200),
nombreMascota_in varchar(200),
especie_in int,
raza_in int)
BEGIN
select MA.*, ES.Nombre as NombreEspecie, RA.Nombre as NombreRaza  from mascotas as MA
inner join clientes as CLI on MA.idCliente = CLI.idCliente
inner join especies as ES on MA.idEspecie = ES.idEspecie
inner join raza as RA on MA.idRaza = RA.idRaza
where 
(
(CLI.Dni = dni_in OR dni_in = '')
AND
(MA.Nombre = nombreMascota_in OR nombreMascota_in = '') -- ó ''
AND
(MA.idEspecie = especie_in OR especie_in = 0) -- ó 0
AND
(MA.idRaza = raza_in OR raza_in = 0)
);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarProductos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarProductos`()
BEGIN
Select P.*,S.StockTotal as Stock, M.Nombre as MarcaProducto From productos as P
INNER JOIN stock as S ON(P.idProducto = S.idProducto)
INNER JOIN marcas as M on(P.idMarca = M.idMarca)
order by P.FechaAlta desc limit 20;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarProveedores` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarProveedores`()
BEGIN
Select * From proveedores order by NombreEmpresa asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarRazas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarRazas`(IN 
idEspecieSeleccionada_in int)
BEGIN
Select * From raza
where idEspecie = idEspecieSeleccionada_in
order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ListarSucursales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ListarSucursales`()
BEGIN
Select * From sucursales order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_listaUnidadMedicion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_listaUnidadMedicion`()
BEGIN
Select * From unidadesdemedicion order by Nombre asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_Stock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_Stock`(IN 
idProducto_in int)
BEGIN
Select * From stock where(idProducto_in is null or idProducto = idProducto_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ValidarClienteExistente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ValidarClienteExistente`(IN
 Dni_in varchar(200))
BEGIN
Select * From clientes where(Dni = Dni_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consultar_ValidarEmpresaExistente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consultar_ValidarEmpresaExistente`(IN
 NombreEmpresa_in varchar(200))
BEGIN
Select * From proveedores where(NombreEmpresa = NombreEmpresa_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Consulta_ValidarCodigoExistente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Consulta_ValidarCodigoExistente`(
IN CodigoProducto_in varchar(200))
BEGIN
Select * From productos where(CodigoProducto = CodigoProducto_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Editar_EditarCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Editar_EditarCliente`(IN 
idCliente_in int,
 Apellido_in varchar(200), 
Nombre_in varchar(200),
 Email_in varchar(200),
 Telefono_in varchar(200), 
   idUsuario_in int)
BEGIN
Update clientes set
Apellido  = Apellido_in,
Nombre  = Nombre_in,
Email  = Email_in,
Telefono  = Telefono_in,
idUsuario = idUsuario_in
where idCliente = idCliente_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Editar_EditarMascota` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Editar_EditarMascota`(IN 
idMascota_in int,
Nombre_in varchar(200), 
FechaNacimiento_in datetime, 
idEspecie_in int,
idRaza_in int,
idCliente_in int,
FechaDeAlta_in datetime,
idUsuario_in int)
BEGIN
Update mascotas set
Nombre  = Nombre_in,
FechaNacimiento  = FechaNacimiento_in,
idEspecie  = idEspecie_in,
idRaza  = idRaza_in,
idCliente = idCliente_in,
FechaAlta = FechaDeAlta_in,
idUsuario = idUsuario_in
where idMascota = idMascota_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Editar_EditarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Editar_EditarProveedor`(IN 
idProveedor_in int,
NombreEmpresa_in varchar(200),
Contacto_in varchar(200),
Email_in varchar(200),
Calle_in varchar(200),
Altura_in varchar(200),
Telefono_in varchar(200),
idUsuario_in int)
BEGIN
Update proveedores set
NombreEmpresa  = NombreEmpresa_in,
NombreContacto  = Contacto_in,
Email  = Email_in,
Calle  = Calle_in,
Altura  = Altura_in,
Telefono  = Telefono_in,
idUsuario  = idUsuario_in
where idProveedor = idProveedor_in;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_insertar_AltaCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_insertar_AltaCliente`(IN 
Dni_in varchar(200), 
Apellido_in varchar(200), 
Nombre_in varchar(200),
Email_in varchar(200),
Telefono_in varchar(200),
FechaDeAlta_in datetime,
idUsuario_in int)
BEGIN insert into clientes
(Dni,Apellido,Nombre,Telefono,Email,FechaAlta,idUsuario)  
values (Dni_in,Apellido_in, Nombre_in,Telefono_in,Email_in,FechaDeAlta_in,
 idUsuario_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_insertar_AltaProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_insertar_AltaProveedor`(IN 
NombreEmpresa_in varchar(200),
Contacto_in varchar(200),
Email_in varchar(200),
Calle_in varchar(200),
Altura_in varchar(200),
Telefono_in varchar(200),
idUsuario_in int)
BEGIN insert into proveedores
(NombreEmpresa,
NombreContacto,
Email,
Calle,
Altura,
Telefono,
idUsuario)  
values (NombreEmpresa_in,Contacto_in,Email_in,Calle_in,Altura_in,
Telefono_in,idUsuario_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Insertar_HistorialIngresoDeStock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Insertar_HistorialIngresoDeStock`(IN
idProducto_in int,
CantidadStockDeCompra_in int,
ValorUnitarioDeCompra_in decimal(10,2),
ValorTotalDeCompra_in decimal(10,2),
idMovimietoAltaStock_in int,
idSucursal_in int)
BEGIN insert into historialStockPorProducto
(idProducto,
Cantidad, 
ValorUnitario,
ValorTotal,
idIngresoStock,
idSucursal)  
values (idProducto_in,
CantidadStockDeCompra_in,
ValorUnitarioDeCompra_in,
ValorTotalDeCompra_in,
idMovimietoAltaStock_in,
idSucursal_in);
select LAST_INSERT_ID() as ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_insertar_InsertarMascota` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_insertar_InsertarMascota`(IN 
Nombre_in varchar(200), 
FechaNacimiento_in datetime, 
idEspecie_in int,
idRaza_in int,
idCliente_in int,
FechaDeAlta_in datetime,
idUsuario_in int)
BEGIN insert into mascotas
(Nombre,FechaNacimiento,idEspecie,idRaza,idCliente,FechaAlta,idUsuario)  
values (Nombre_in,FechaNacimiento_in, idEspecie_in,idRaza_in,idCliente_in,FechaDeAlta_in,
 idUsuario_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Insertar_MovimientoAltaStock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Insertar_MovimientoAltaStock`(IN
idProveedor_in int,
FechaFactura_in datetime,
Remito_in varchar(200),
MontoTotal_in decimal(10,2),
FechaRegistro_in datetime,
idUsuario_in int)
BEGIN insert into ingresodestock
(idProveedor,
FechaFactura, 
Remito,
MontoTotal,
FechaRegistro,
idUsuario)  
values (idProveedor_in,FechaFactura_in,Remito_in,
MontoTotal_in,FechaRegistro_in, idUsuario_in);
select LAST_INSERT_ID() as ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Insertar_Producto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Insertar_Producto`(IN CodigoProducto_in varchar(200),
idCategoriaProducto_in int,
 Descripcion_in varchar(200),
 idMarca_in int,
 idUnidadDeMedicion_in int,
 PrecioDeVenta_in decimal(10,2),
 FechaDeAlta_in datetime,
idUsuario_in int)
BEGIN insert into productos(
CodigoProducto,
idCategoriaProducto,
Descripcion,
idMarca,
idUnidadDeMedicion,
PrecioDeVenta,
FechaAlta, 
idUsuario)  
values (CodigoProducto_in,
idCategoriaProducto_in,
Descripcion_in,
idMarca_in,
idUnidadDeMedicion_in,
PrecioDeVenta_in,
FechaDeAlta_in,
idUsuario_in);
select LAST_INSERT_ID() as ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Insertar_Stock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `SP_Insertar_Stock`(IN idProducto_in int,
Cantidad_in int)
BEGIN insert into stock(idProducto,StockTotal)  
values (idProducto_in, Cantidad_in);
select LAST_INSERT_ID() as ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ValidarProductoExistente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`uqv4i9vwt1msz5bm`@`%` PROCEDURE `ValidarProductoExistente`(
IN CodigoProducto_in varchar(200))
BEGIN
Select * From productos where(CodigoProducto_in is null or CodigoProducto = CodigoProducto_in);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-27 15:41:03
