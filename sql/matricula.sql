CREATE TABLE `gcce`.`matricula` (
  `cod_matricula` INT NOT NULL,
  `cod_alu` INT NULL,
  `cred_aprobados` INT NULL,
  `cred_matriculados` VARCHAR(45) NULL,
  `year` INT NULL,
  `poat` VARCHAR(45) NULL,
  `nuevo_ingreso` VARCHAR(45) NULL,
  `coste_credito` INT NULL,
  `beca` VARCHAR(45) NULL,
  `cancela_matricula` VARCHAR(45) NULL,
  PRIMARY KEY (`cod_matricula`));