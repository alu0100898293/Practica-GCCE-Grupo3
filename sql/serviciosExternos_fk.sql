ALTER TABLE `gcce`.`ServiciosExternos` 
ADD INDEX `cod_alumno_idx` (`cod_alumno` ASC) VISIBLE;
;
ALTER TABLE `gcce`.`ServiciosExternos` 
ADD CONSTRAINT `cod_alumno`
  FOREIGN KEY (`cod_alumno`)
  REFERENCES `gcce`.`Alumno` (`cod_alu`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;