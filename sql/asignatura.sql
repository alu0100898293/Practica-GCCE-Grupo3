CREATE TABLE `gcce`.`Asignatura` (
  `cod_asignatura` VARCHAR(45) NOT NULL,
  `cod_titulo` VARCHAR(45) NULL,
  `dificultad` VARCHAR(45) NULL,
  `profesor` VARCHAR(45) NULL,
  `cred_asignatura` INT NULL,
  `nom_asignatura` VARCHAR(45) NULL,
  `curso` INT NULL,
  `cuatrimestre` INT NULL,
  `tipo_asignatura` VARCHAR(45) NULL,
  `especial` VARCHAR(45) NULL,
  PRIMARY KEY (`cod_asignatura`));