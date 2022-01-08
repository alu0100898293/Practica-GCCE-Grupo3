ALTER TABLE `gcce`.`matricula` 
ADD INDEX `cod_alu_idx` (`cod_alu` ASC) VISIBLE;
;
ALTER TABLE `gcce`.`matricula` 
ADD CONSTRAINT `cod_alu`
  FOREIGN KEY (`cod_alu`)
  REFERENCES `gcce`.`Alumno` (`cod_alu`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;