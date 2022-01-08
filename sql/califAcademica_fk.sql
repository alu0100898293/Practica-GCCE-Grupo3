ALTER TABLE `gcce`.`CalifAcademica` 
ADD INDEX `cod_matricula_idx` (`cod_matricula` ASC) VISIBLE,
ADD INDEX `cod_alumno_idx` (`cod_alu` ASC) VISIBLE,
ADD INDEX `cod_titulo_idx` (`cod_titulo` ASC) VISIBLE,
ADD INDEX `cod_profesor_idx` (`cod_profesor` ASC) VISIBLE,
ADD INDEX `cod_asignatura_idx` (`cod_asignatura` ASC) VISIBLE;
;
ALTER TABLE `gcce`.`CalifAcademica` 
ADD CONSTRAINT `cod_matricula`
  FOREIGN KEY (`cod_matricula`)
  REFERENCES `gcce`.`matricula` (`cod_matricula`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `cod_alu`
  FOREIGN KEY (`cod_alu`)
  REFERENCES `gcce`.`Alumno` (`cod_alu`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `cod_titulo`
  FOREIGN KEY (`cod_titulo`)
  REFERENCES `gcce`.`Titulacion` (`cod_titulo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `cod_profesor`
  FOREIGN KEY (`cod_profesor`)
  REFERENCES `gcce`.`Profesor` (`cod_prof`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `cod_asignatura`
  FOREIGN KEY (`cod_asignatura`)
  REFERENCES `gcce`.`Asignatura` (`cod_asignatura`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;