-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema acesse
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema acesse
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `acesse` DEFAULT CHARACTER SET utf8 ;
USE `acesse` ;

-- -----------------------------------------------------
-- Table `acesse`.`ace_acessibilidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`ace_acessibilidade` (
  `ace_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `ace_nome` VARCHAR(120) NOT NULL,
  PRIMARY KEY (`ace_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`loc_local`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`loc_local` (
  `loc_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `loc_nome` VARCHAR(120) NOT NULL,
  `loc_descricao` VARCHAR(1000) NOT NULL,
  `loc_categoria` VARCHAR(120) NOT NULL,
  `ace_acessibilidade_ace_codigo` INT(11) NOT NULL,
  `loc_tipo` ENUM('privado', 'público') NOT NULL,
  PRIMARY KEY (`loc_codigo`),
  INDEX `fk_loc_local_ace_acessibilidade1_idx` (`ace_acessibilidade_ace_codigo` ASC),
  CONSTRAINT `fk_loc_local_ace_acessibilidade1`
    FOREIGN KEY (`ace_acessibilidade_ace_codigo`)
    REFERENCES `acesse`.`ace_acessibilidade` (`ace_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`acess_local`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`acess_local` (
  `ace_acessibilidade_ace_codigo` INT(11) NOT NULL,
  `loc_local_loc_codigo` INT(11) NOT NULL,
  PRIMARY KEY (`ace_acessibilidade_ace_codigo`, `loc_local_loc_codigo`),
  INDEX `fk_acess_local_loc_local1_idx` (`loc_local_loc_codigo` ASC),
  CONSTRAINT `fk_acess_local_ace_acessibilidade1`
    FOREIGN KEY (`ace_acessibilidade_ace_codigo`)
    REFERENCES `acesse`.`ace_acessibilidade` (`ace_codigo`),
  CONSTRAINT `fk_acess_local_loc_local1`
    FOREIGN KEY (`loc_local_loc_codigo`)
    REFERENCES `acesse`.`loc_local` (`loc_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`usu_usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`usu_usuario` (
  `usu_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `usu_email` VARCHAR(240) NOT NULL,
  `usu_senha` VARCHAR(120) NOT NULL,
  `usu_datacadastro` DATETIME NOT NULL,
  `usu_perfil` ENUM('Comum', 'Administrador') NULL DEFAULT NULL,
  PRIMARY KEY (`usu_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`end_endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`end_endereco` (
  `end_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `end_logradouro` VARCHAR(120) NOT NULL,
  `end_numero` VARCHAR(45) NOT NULL,
  `end_bairro` VARCHAR(60) NOT NULL,
  `end_cidade` VARCHAR(120) NOT NULL,
  `end_estado` VARCHAR(3) NOT NULL,
  `end_cep` VARCHAR(45) NOT NULL,
  `usu_usuario_usu_codigo` INT(11) NOT NULL,
  `loc_local_loc_codigo` INT(11) NOT NULL,
  PRIMARY KEY (`end_codigo`),
  INDEX `fk_end_endereco_usu_usuario1_idx` (`usu_usuario_usu_codigo` ASC),
  INDEX `fk_end_endereco_loc_local1_idx` (`loc_local_loc_codigo` ASC),
  CONSTRAINT `fk_end_endereco_loc_local1`
    FOREIGN KEY (`loc_local_loc_codigo`)
    REFERENCES `acesse`.`loc_local` (`loc_codigo`),
  CONSTRAINT `fk_end_endereco_usu_usuario1`
    FOREIGN KEY (`usu_usuario_usu_codigo`)
    REFERENCES `acesse`.`usu_usuario` (`usu_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`img_imagem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`img_imagem` (
  `img_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `img_descricao` VARCHAR(1000) NOT NULL,
  `img_data` DATETIME NULL DEFAULT NULL,
  `loc_local_loc_codigo` INT(11) NOT NULL,
  `pub_publicolugar_pub_codigo` INT(11) NOT NULL,
  PRIMARY KEY (`img_codigo`),
  INDEX `fk_img_imagem_loc_local1_idx` (`loc_local_loc_codigo` ASC),
  CONSTRAINT `fk_img_imagem_loc_local1`
    FOREIGN KEY (`loc_local_loc_codigo`)
    REFERENCES `acesse`.`loc_local` (`loc_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`pes_pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`pes_pessoa` (
  `pes_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `pes_nome` VARCHAR(60) NOT NULL,
  `pes_sobrenome` VARCHAR(120) NOT NULL,
  `pes_cpf` VARCHAR(14) NULL DEFAULT NULL,
  `pes_rg` VARCHAR(12) NULL DEFAULT NULL,
  `usu_usuario_usu_codigo` INT(11) NOT NULL,
  PRIMARY KEY (`pes_codigo`),
  INDEX `fk_pes_pessoa_usu_usuario1_idx` (`usu_usuario_usu_codigo` ASC),
  CONSTRAINT `fk_pes_pessoa_usu_usuario1`
    FOREIGN KEY (`usu_usuario_usu_codigo`)
    REFERENCES `acesse`.`usu_usuario` (`usu_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `acesse`.`vis_visualizacoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acesse`.`vis_visualizacoes` (
  `vis_codigo` INT(11) NOT NULL AUTO_INCREMENT,
  `vis_datavisualizacao` DATETIME NULL DEFAULT NULL,
  `loc_local_loc_codigo` INT(11) NOT NULL,
  PRIMARY KEY (`vis_codigo`),
  INDEX `fk_vis_visualizacoes_loc_local1_idx` (`loc_local_loc_codigo` ASC),
  CONSTRAINT `fk_vis_visualizacoes_loc_local1`
    FOREIGN KEY (`loc_local_loc_codigo`)
    REFERENCES `acesse`.`loc_local` (`loc_codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
