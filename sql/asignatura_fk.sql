ALTER TABLE `gcce`.`Asignatura` 
ADD INDEX `cod_titulo_idx` (`cod_titulo` ASC) VISIBLE;
;
ALTER TABLE `gcce`.`Asignatura` 
ADD CONSTRAINT `cod_titulo`
  FOREIGN KEY (`cod_titulo`)
  REFERENCES `gcce`.`Titulacion` (`cod_titulo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;