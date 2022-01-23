CREATE TABLE `gcce`.`matricula` (
  `cod_matricula` VARCHAR(45) NOT NULL,
  `cod_alu` VARCHAR(45) NULL,
  `cred_aprobados` INT NULL,
  `cred_matriculados` VARCHAR(45) NULL,
  `year` INT NULL,
  `poat` VARCHAR(45) NULL,
  `nuevo_ingreso` VARCHAR(45) NULL,
  `coste_credito` FLOAT NULL,
  `beca` VARCHAR(45) NULL,
  `cancela_matricula` VARCHAR(45) NULL,
  PRIMARY KEY (`cod_matricula`));