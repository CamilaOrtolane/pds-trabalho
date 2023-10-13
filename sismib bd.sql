create database Sismib;
use Sismib;

create table endereco(
id_end int primary key auto_increment ,
numero_end int,
rua_end varchar(100),
bairro_end varchar(50)
);

insert into endereco values(null, '1670', "rua das flores", "diamante");
insert into endereco values(null, '1671', "rua das pedras", "sao luis");
insert into endereco values(null, '1672', "rua das mangueiras", "industrial");
insert into endereco values(null, '1673', "rua das castanheiras", "rio branco");
select * from endereco;

create table cliente(
id_cli int primary key auto_increment,
nome_cli varchar(60),
cpf_cli varchar(20),
rg_cli int,
estado_civil_cli enum('Solteira(o)', 'Casada(o)', 'Namorando'),
data_nasc_cli date,
cidade_cli varchar(50),
estado_cli enum ('Acre', 'Alagoas', 'Amapá', 'Amazonas', 'Bahia', 'Ceará', 'Espírito Santo', 'Goiás', 'Maranhão', 'Mato Grosso', 'Mato Grosso do Sul', 'Minas Gerais', 'Pará', 'Paraíba', 'Paraná', 'Pernambuco', 'Piauí', 'Rio de Janeiro', 'Rio Grande do Norte', 'Rio Grande do Sul', 'Rondônia', 'Roraima', 'Santa Catarina', 'São Paulo', 'Sergipe', 'Tocantins', 'Distrito Federal'),
telefone_cli varchar(20),
profissao_cli varchar(20),
tipo_resi_cli varchar(20),
nome_pai_cli varchar(60),
nome_mae_cli varchar(60),
id_end_fk int,
foreign key (id_end_fk) references endereco(id_end)
);

insert into cliente values(null, "Julia", "043.616.612-78", 1536812, 'Solteira(o)', '2006-08-18', "Ji-Paraná", 'Rondônia', "(69) 99913-0309", "Nefrologista", "propria", "Paulo", "Verceni", null);
insert into cliente values(null, "Camila", "043.616.612-73", 1536787, 'Solteira(o)', '2006-08-17', "Ji-Paraná", 'Rondônia', "(69) 99913-0306", "DBA", "propria", "Pai da camila", "Mae da camila", null);
insert into cliente values(null, "Domenique", "043.616.612-75", 1536864, 'Solteira(o)', '2006-08-16', "Ji-Paraná", 'Rondônia', "(69) 99913-0303", "Professora de TI", "propria", "Pai da dome", "Mae da", null);
insert into cliente values(null, "Vitor", "043.616.612-76", 1536377, 'Solteira(o)', '2006-08-15', "Ji-Paraná", 'Rondônia', "(69) 99913-0319", "DBA", "propria", "Pai do vitor", "Mae do vitor", null);
insert into cliente values(null, "Pedro", "043.616.612-77", 1472589, 'Namorando', '2006-08-14', "Ji-Paraná", 'Rondônia', "(69) 99913-0317", "DBA", "propria", "pai do pedro", "Mae do pedro", null);
select * from cliente;

create table funcionario(
id_fun int primary key auto_increment, 
nome_fun varchar(60),
cpf_fun varchar(20),
rg_fun int,
estado_civil_fun enum('Solteira(o)', 'Casada(o)', 'Namorando'),
data_nasc_fun date,
cidade_fun varchar(50),
estado_fun enum ('Acre', 'Alagoas', 'Amapá', 'Amazonas', 'Bahia', 'Ceará', 'Espírito Santo', 'Goiás', 'Maranhão', 'Mato Grosso', 'Mato Grosso do Sul', 'Minas Gerais', 'Pará', 'Paraíba', 'Paraná', 'Pernambuco', 'Piauí', 'Rio de Janeiro', 'Rio Grande do Norte', 'Rio Grande do Sul', 'Rondônia', 'Roraima', 'Santa Catarina', 'São Paulo', 'Sergipe', 'Tocantins', 'Distrito Federal'),
telefone_fun varchar(20),
tipo_resi_fun varchar(20),
nome_pai_fun varchar(60),
nome_mae_fun varchar(60),
setor_fun varchar(20),
salario_fun double,
carga_horaria_fun time,
funcao_fun varchar(50),
horas_extras_fun time,
remuneracao_extra_fun double,
id_end_fk int,
foreign key (id_end_fk) references endereco(id_end)
);

insert into funcionario values(null, "Julia", "043.616.612-78", 1536812, 'Solteira(o)', '2006-08-18', "Ji-Paraná", 'Rondônia', "(69) 99913-0309", "propria", "Paulo", "Verceni", "ADM", 6000,'04:00:00',"ADm de banco de dados",'00:00:00', 00.00 , null);
insert into funcionario values(null, "Camila", "043.616.612-73", 1536787, 'Solteira(o)', '2006-08-17', "Ji-Paraná", 'Rondônia', "(69) 99913-0306", "propria", "Pai da camila", "Mae da camila", "ADM", 6000,'04:00:00',"ADm de banco de dados",'00:00:00', 0 ,null);
insert into funcionario values(null, "Domenique", "043.616.612-75", 1536864, 'Solteira(o)', '2006-08-16', "Ji-Paraná", 'Rondônia', "(69) 99913-0303", "propria", "Pai da dome", "Mae da","ADM", 6000,'04:00:00',"ADm de banco de dados",'00:00:00', 0 ,null);
insert into funcionario values(null, "Vitor", "043.616.612-76", 1536377, 'Solteira(o)', '2006-08-15', "Ji-Paraná", 'Rondônia', "(69) 99913-0319", "propria", "Pai do vitor", "Mae do vitor", "ADM", 6000,'04:00:00',"ADm de banco de dados",'00:00:00', 0 ,null);
insert into funcionario values(null, "Pedro", "043.616.612-77", 1472589, 'Namorando', '2006-08-14', "Ji-Paraná", 'Rondônia', "(69) 99913-0317", "propria", "pai do pedro", "Mae do pedro", "ADM", 6000,'04:00:00',"ADm de banco de dados",'00:00:00', 0 ,null);
select * from funcionario;

create table fornecedor(
id_for int primary key auto_increment,
nome_fantasia_for varchar(60),
razao_social_for varchar(60),
cnpj_for varchar(20),
cidade_for varchar(50),
estado_fun enum ('Acre', 'Alagoas', 'Amapá', 'Amazonas', 'Bahia', 'Ceará', 'Espírito Santo', 'Goiás', 'Maranhão', 'Mato Grosso', 'Mato Grosso do Sul', 'Minas Gerais', 'Pará', 'Paraíba', 'Paraná', 'Pernambuco', 'Piauí', 'Rio de Janeiro', 'Rio Grande do Norte', 'Rio Grande do Sul', 'Rondônia', 'Roraima', 'Santa Catarina', 'São Paulo', 'Sergipe', 'Tocantins', 'Distrito Federal'),
id_end_fk int,
foreign key (id_end_fk) references endereco(id_end)
);

insert into fornecedor values(null, "moveis lindos", "moveis lindos S.A", '12.345.678/0001-00', "Ji-Paraná", 'Rondônia', null);
insert into fornecedor values(null, "moveis perfeitos", "moveis perfeitos S.A", '12.345.678/0002-00', "Ji-Paraná", 'Rondônia', null);
insert into fornecedor values(null, "moveis magnificos", "moveis magnificos S.A", '12.345.678/0003-00', "Ji-Paraná", 'Rondônia', null);
insert into fornecedor values(null, "moveis pequenos", "moveis pequenos S.A", '12.345.678/0004-00', "Ji-Paraná", 'Rondônia', null);
insert into fornecedor values(null, "moveis grandes", "moveis grandes S.A", '12.345.678/0051-00', "Ji-Paraná", 'Rondônia', null);
select * from fornecedor;

create table compra(
id_com int primary key auto_increment,
nome_com varchar(20),
data_com date,
valor_com double,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_for_fk int,
foreign key (id_fun_fk) references fornecedor(id_for)
);

insert into compra values(null, "moveis lindos", '2023-06-16', 2000,null, null);
insert into compra values(null, "moveis perfeitos", '2023-06-15', 2500,null, null);
insert into compra values(null, "moveis magnificos", '2023-06-14', 2400,null, null);
insert into compra values(null, "moveis pequenos", '2023-06-13', 2300,null, null);
insert into compra values(null, "moveis grandes", '2023-06-12', 2200,null, null);
select * from compra;

create table movel(
id_mov int primary key auto_increment,
nome_mov varchar(50),
materia_mov varchar(50),
descricao_mov varchar(100),
peso_mov double,
comprimento_mov double,
cor_mov varchar(20),
altura_mov double,
largura_mov double,
valor_tributos_mov double,
valor_custo_mov double,
valor_venda_mov double,
id_com_fk int,
foreign key (id_com_fk) references compra(id_com)
);

insert into movel values(null, "cadeira", "madeira", "cadeira de madeira", 3.2, 00, "branca", 00, 00, 00, 00, 500,null);
insert into movel values(null, "cadeira pequena", "madeira", "cadeira pequena", 2.2, 00, "branca", 00, 00, 00, 00, 300,null);
insert into movel values(null, "cadeira grande", "madeira", "cadeira grande", 5.2, 00, "branca", 00, 00, 00, 00, 1000,null);
insert into movel values(null, "cadeira quadrada", "madeira", "cadeira quadrada", 3.2, 00, "branca", 00, 00, 00, 00, 500,null);
insert into movel values(null, "cadeira redonda", "madeira", "cadeira redonda", 3.2, 00, "branca", 00, 00, 00, 00, 500,null);
select * from movel;

create table despesa(
id_des int primary key auto_increment,
nome_des varchar(20),
data_venc_des date,
data_pag_des date,
id_com_fk int,
foreign key (id_com_fk) references compra(id_com)
);

insert into despesa values(null,"agua", '2023-11-16', '2023-06-16', null);
insert into despesa values(null,"internet", '2023-11-15', '2023-06-15', null);
insert into despesa values(null,"energia", '2023-11-14', '2023-06-14', null);
insert into despesa values(null,"fornecedor", '2023-11-13', '2023-06-13', null);
insert into despesa values(null,"agua", '2023-11-12', '2023-06-12', null);
select * from despesa;

create table pagamento(
id_pag int primary key auto_increment,
nome_pag varchar(20),
data_pag date,
descricao_pag varchar(50),
valor_pag double,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_des_fk int,
foreign key (id_des_fk) references despesa(id_des)
);



create table reparo(
id_rep int primary key auto_increment,
nome_rep varchar(20),
descricao_rep varchar(50),
data_rep date,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_cli_fk int,
foreign key (id_cli_fk) references cliente(id_cli)
);

insert into reparo values(null, "reparo1", "perna de cadeira quebrada", '2023-06-16', null, null);
insert into reparo values(null, "reparo2", "assento de cadeira quebrada", '2023-06-15', null, null);
insert into reparo values(null, "reparo3", "encosto de cadeira quebrada", '2023-06-14', null, null);
insert into reparo values(null, "reparo4", "perna de cadeira quebrada", '2023-06-17', null, null);
insert into reparo values(null, "reparo5", "assento de cadeira quebrada", '2023-06-18', null, null);
select * from reparo;

create table entrega(
id_ent int primary key auto_increment,
data_ent date,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_cli_fk int,
foreign key (id_cli_fk) references cliente(id_cli),
id_end_fk int,
foreign key (id_end_fk) references endereco(id_end)
);
insert into entrega values(null, '2023-06-16', null, null, null);
insert into entrega values(null, '2023-06-15', null, null, null);
insert into entrega values(null, '2023-06-14', null, null, null);
insert into entrega values(null, '2023-06-13', null, null, null);
insert into entrega values(null, '2023-06-12', null, null, null);
select * from entrega;

create table servico(
id_ser int primary key auto_increment,
nome_ser varchar(20),
descricao_ser varchar(1000),
id_ent_fk int,
foreign key (id_ent_fk) references entrega(id_ent),
id_rep_fk int,
foreign key (id_rep_fk) references reparo(id_rep)
);
insert into servico values(null, '2023-06-16', "entrega", null, null);
insert into servico values(null, '2023-06-15', "reparo", null, null);
insert into servico values(null, '2023-06-14', "entrega", null, null);
insert into servico values(null, '2023-06-13', "reparo", null, null);
insert into servico values(null, '2023-06-12', "entrega", null, null);
select * from servico;

create table venda(
id_ven int primary key auto_increment,
nome_ven varchar(20),
data_ven date,
numero_ven int,
descricao varchar(50),
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_cli_fk int,
foreign key (id_cli_fk) references cliente(id_cli),
id_ser_fk int,
foreign key (id_ser_fk) references servico(id_ser),
id_mov_fk int,
foreign key (id_mov_fk) references movel(id_mov)
);
insert into venda values(null, "venda1",'2023-06-19', 101, "venda de cadeira", null, null, null, null);
insert into venda values(null, "venda2",'2023-06-18', 102, "venda de mesa", null, null, null, null);
insert into venda values(null, "venda3",'2023-06-17', 103, "venda de sofa", null, null, null, null);
insert into venda values(null, "venda4",'2023-06-16', 104, "venda de cadeira", null, null, null, null);
insert into venda values(null, "venda5",'2023-06-15', 105, "venda de bancada", null, null, null, null);
select * from venda;

create table movel_venda(
id_moven int primary key auto_increment,
id_mov_fk int,
foreign key (id_mov_fk) references movel(id_mov),
id_ven_fk int,
foreign key (id_ven_fk) references venda(id_ven)
);
