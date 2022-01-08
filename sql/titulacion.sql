CREATE TABLE `gcce`.`Titulacion` (
  `cod_titulo` INT NOT NULL,
  `num_asignaturas` INT NULL,
  `num_cursos` INT NULL,
  `tip_titulacion` VARCHAR(45) NULL,
  `tip_estudios` VARCHAR(45) NULL,
  `total_creditos` INT NULL,
  `p_abandono` INT NULL,
  PRIMARY KEY (`cod_titulo`));