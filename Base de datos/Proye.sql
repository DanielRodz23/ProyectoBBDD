CREATE DATABASE  IF NOT EXISTS `tienda` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tienda`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: 26.252.149.4    Database: tienda
-- ------------------------------------------------------
-- Server version	8.0.29

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

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Sku` int NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Precio` double(10,2) NOT NULL,
  `Descripcion` text NOT NULL,
  `Stock` int NOT NULL,
  `Estado` bit(1) NOT NULL DEFAULT b'0',
  `Imagen` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (2,1235,'I3 11355',2000.00,'Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación Procesador de 11va Generación ',0,_binary '\0','https://www.cyberpuerta.mx/img/product/M/CP-INTEL-BX8071512100F-5950fe.jpg'),(4,1237,'I7 11900K',1000.00,'Procesador de 11va Generación',0,_binary '\0','https://ark.intel.com/content/dam/www/central-libraries/xa/en/images/intel-core-i7-badge-1440x1080.png.rendition.intel.web.64.64.png'),(5,1239,'I9 12900K',9999.00,'Procesador 5.9Ghz, Consumo 120W',1,_binary '','https://www.cyberpuerta.mx/img/product/M/CP-INTEL-BX8071512900K-a6160e.jpg'),(6,1238,'Ryzen 5 5600G',2600.00,'Procesador APU (con graficos integrados)',4,_binary '','https://www.cyberpuerta.mx/img/product/M/CP-AMD-100-100000252BOX-1.jpg'),(7,1234567,'AMD Ryzen Threadripper Pro 5955WX',22636.00,'procesador de computadora de 16 núcleos, 32 Hilos. ‎280 watts',19,_binary '','https://m.media-amazon.com/images/I/61fqEHg5ieL._AC_SY355_.jpg');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`ProyePINDAN`@`%`*/ /*!50003 TRIGGER `productos_BEFORE_INSERT` BEFORE INSERT ON `productos` FOR EACH ROW BEGIN
if (new.Stock>0) then
set new.Estado=1;
else if (new.Stock=0) then
set new.Estado=0;
end if;
end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`ProyePINDAN`@`%`*/ /*!50003 TRIGGER `productos_BEFORE_UPDATE` BEFORE UPDATE ON `productos` FOR EACH ROW BEGIN
if new.stock=0
then 
set new.estado=0;
else if new.stock>0
then 
set new.estado=1;
end if;
end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `registrocompras`
--

DROP TABLE IF EXISTS `registrocompras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registrocompras` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdUsuario` int NOT NULL,
  `IdProducto` int NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Usuarios_Compra_idx` (`IdUsuario`),
  KEY `fk_Producto_Compra_idx` (`IdProducto`),
  CONSTRAINT `fk_Producto_Compra` FOREIGN KEY (`IdProducto`) REFERENCES `productos` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_Usuarios_Compra` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registrocompras`
--

LOCK TABLES `registrocompras` WRITE;
/*!40000 ALTER TABLE `registrocompras` DISABLE KEYS */;
INSERT INTO `registrocompras` VALUES (3,5,2,1),(4,5,2,1),(5,5,2,1),(6,5,2,0),(7,5,2,1),(8,5,4,1),(9,5,4,1),(10,5,2,1),(11,5,4,2),(12,5,5,3),(13,5,7,1);
/*!40000 ALTER TABLE `registrocompras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Cliente');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Contrasena` varchar(256) NOT NULL,
  `Idrol` int NOT NULL,
  `Correo` varchar(90) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Correo_UNIQUE` (`Correo`),
  KEY `fkIdrol_idx` (`Idrol`),
  CONSTRAINT `fkIdrol` FOREIGN KEY (`Idrol`) REFERENCES `roles` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (3,'juan','40bd001563085fc35165329ea1ff5c5ecbdbbeef',2,'hgjh'),(4,'Daniel','5c933e47e10dd2c802f2e7ee6c6f5afcd3489e82',1,'dan@gmail.com'),(5,'PinedaRex','e6e33fe06d2dbf9ff6f2da145630c75a470d9d58',2,'pin@gmail.com'),(7,'Daniel 10','e6e33fe06d2dbf9ff6f2da145630c75a470d9d58',1,'dan1@gmail.com'),(8,'Daniel 3','e6e33fe06d2dbf9ff6f2da145630c75a470d9d58',2,'dan3@gmail.com'),(9,'Daniel 4','5c933e47e10dd2c802f2e7ee6c6f5afcd3489e82',2,'dan4@gmail.com'),(10,'Daniel 5','5c933e47e10dd2c802f2e7ee6c6f5afcd3489e82',1,'dan5@gmail.com');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`ProyePINDAN`@`%`*/ /*!50003 TRIGGER `usuarios_BEFORE_INSERT` BEFORE INSERT ON `usuarios` FOR EACH ROW BEGIN
	set new.Contrasena=sha1(new.Contrasena);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Dumping events for database 'tienda'
--

--
-- Dumping routines for database 'tienda'
--
/*!50003 DROP FUNCTION IF EXISTS `fnIniciarSesion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`ProyePINDAN`@`%` FUNCTION `fnIniciarSesion`(spcorreo varchar(50),
spcontraseña varchar(256)) RETURNS int
    DETERMINISTIC
BEGIN
select count(*) into @exito from usuarios where correo=spcorreo
 AND Contrasena=sha1(spcontraseña);  -- 1 si estan correctas las credenciales
select count(*) into @usuarioexist from usuarios where correo=spcorreo;  
-- 0 si no esta el correo
 set @vregreso=0;
 
/*Aqui si inicio sesion de manera exitosa*/
if (@exito=1) then
begin
select id into @id from usuarios where correo=spcorreo;
  -- insert into bitacoras(correo,observaciones,IdUsuario) values(spcorreo,"Ingreso exitoso",@id);
  set @vregreso= 1;
end;
/*Aqui validamos que el correo existe*/
else if(@usuarioexist=0) then 
begin
select id into @id from usuarios where correo=spcorreo;
   -- insert into bitacoras(observaciones,idusuario) values(concat("Usuario inexistente con el correo: ",spcorreo),@id);
   set @vregreso=2;
end;
else
begin
select id into @id from usuarios where correo=spcorreo;
    -- insert into bitacoras(correo,observaciones,idusuario) values(spcorreo,"Usuario con contraseña incorrecta",@id);
     set @vregreso=3;
end;
end if;
end if;
return @vregreso;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Registrar_Compra` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`ProyePINDAN`@`%` PROCEDURE `Registrar_Compra`(in p_IdProducto int,in p_IdUsuario int, in p_Cantidad int)
BEGIN
	select stock into @stock from productos where id=p_IdProducto;
	if @stock>0 and @stock<=p_Cantidad then
		begin
		set p_Cantidad=@stock;
		insert into RegistroCompras(IdProducto,IdUsuario,Cantidad) values (p_IdProducto , p_IdUsuario ,  p_Cantidad);
        update productos set stock=p_Cantidad-@stock where id=p_IdProducto;
		end;
	else if @stock>0 and @stock>p_Cantidad then
    begin
		insert into RegistroCompras(IdProducto,IdUsuario,Cantidad) values (p_IdProducto , p_IdUsuario ,  p_Cantidad);
        update productos set stock=@stock-p_Cantidad where id=p_IdProducto;
	end;
	end if;
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-16 19:51:44
