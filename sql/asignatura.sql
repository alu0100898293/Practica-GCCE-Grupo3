CREATE TABLE `gcce`.`Asignatura` (
  `cod_asignatura` INT NOT NULL,
  `cod_titulo` INT NULL,
  `dificultad` VARCHAR(45) NULL,
  `cred_asignatura` INT NULL,
  `nom_asignatura` VARCHAR(45) NULL,
  `curso` INT NULL,
  `cuatrimestre` INT NULL,
  `tipo_asignatura` VARCHAR(45) NULL,
  `especial` VARCHAR(45) NULL,
  PRIMARY KEY (`cod_asignatura`));