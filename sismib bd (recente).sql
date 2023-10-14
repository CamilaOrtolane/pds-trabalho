# PROJETO SisMib 
# Alunas : Camila Ortolane, Julia de Freitas, Kauane Marcolino             Turma:3A

create database Sismib;
use Sismib;

create table cliente(
id_cli int primary key auto_increment,
nome_cli varchar(60) not null,
cpf_cli varchar(20),
rg_cli int,
estado_civil_cli varchar(20),
data_nasc_cli date,
telefone_cli varchar(20),
profissao_cli varchar(20),
tipo_resi_cli varchar(20),
rua_cli varchar(20),
cidade_cli varchar(20),
estado_cli varchar(20),
pais_cli varchar(20)
);

create table funcionario(
id_fun int primary key auto_increment, 
nome_fun varchar(60) not null,
cpf_fun varchar(20),
rg_fun int,
estado_civil_fun varchar(20),
data_nasc_fun date,
telefone_fun varchar(20),
setor_fun varchar(20),
salario_fun double,
carga_horaria_fun time,
funcao_fun varchar(50),
horas_extras_fun time,
remuneracao_extra_fun double,
rua_fun varchar(20),
cidade_fun varchar(20),
estado_fun varchar(20),
pais_fun varchar(20)
);

create table caixa(
id_cai int primary key auto_increment,
total_sai_cai double not null,
total_ent_cai double not null,
saldo_ini_cai double not null,
saldo_fin_cai double not null,
data_cai date not null,
hora_cai time,
numero_cai int,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario (id_fun)
);

create table fornecedor(
id_for int primary key auto_increment,
nome_fantasia_for varchar(60),
razao_social_for varchar(60),
cnpj_for varchar(20) not null,
rua_for varchar(20),
cidade_for varchar(20),
estado_for varchar(20),
pais_for varchar(20)
);

create table compra(
id_com int primary key auto_increment,
nome_com varchar(20),
data_com date,
valor_com double not null,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_for_fk int,
foreign key (id_for_fk) references fornecedor(id_for)
);

create table movel(
id_mov int primary key auto_increment,
nome_mov varchar(50) not null,
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

create table despesa(
id_des int primary key auto_increment,
nome_des varchar(20),
data_venc_des date,
data_pag_des date,
id_com_fk int,
foreign key (id_com_fk) references compra(id_com)
);

create table pagamento(
id_pag int primary key auto_increment,
nome_pag varchar(20),
data_pag date,
descricao_pag varchar(50),
valor_pag double,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_des_fk int,
foreign key (id_des_fk) references despesa(id_des),
id_cai_fk int,
foreign key (id_cai_fk) references caixa(id_cai)
);

create table servico(
id_ser int primary key auto_increment,
nome_ser varchar(20) not null,
descricao_ser varchar(1000)
);

create table venda(
id_ven int primary key auto_increment,
nome_ven varchar(20),
data_ven date,
descricao_ven varchar(50),
valor_ven double not null,
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun),
id_cli_fk int,
foreign key (id_cli_fk) references cliente(id_cli),
id_ser_fk int,
foreign key (id_ser_fk) references servico(id_ser),
id_mov_fk int,
foreign key (id_mov_fk) references movel(id_mov)
);

create table movel_venda(
id_moven int primary key auto_increment,
id_mov_fk int not null,
foreign key (id_mov_fk) references movel(id_mov),
id_ven_fk int not null,
foreign key (id_ven_fk) references venda(id_ven)
);

create table Recebimento(
id_rec int primary key auto_increment,
data_rec date,
parcela_rec varchar(50),
valor_rec double not null,
vencimento_rec date,
id_ven_fk int,
foreign key (id_ven_fk) references venda(id_ven),
id_cai_fk int,
foreign key (id_cai_fk) references caixa(id_cai)
);

delimiter $$ 
create procedure salvarCliente(nome varchar(60), cpf varchar(20), rg int, estado_civil varchar(20), dataNasc date, telefone varchar(20), profissao varchar(20),tipo_resi varchar(20), rua varchar(20), cidade varchar(20), estado varchar(20), pais varchar(20))
begin
declare verifi_cpf varchar(20);
set verifi_cpf = (select cpf_cli from cliente where (cpf_cli = cpf));
if (nome <> '') then 
	if (verifi_cpf = '') or (verifi_cpf is null) then 
        insert into cliente values (null, nome, cpf,rg, estado_civil, dataNasc, telefone, profissao, tipo_resi, rua, cidade, estado, pais);
		select concat('O cliente ', nome, ' foi salvo com sucesso!') as Confirmacao;
	else
		select 'O CPF informado já EXISTE na base de dados!' as Alerta;
    end if; 

else 
	select 'Os campos NOME e CPF são obrigatorios!' as Alerta;
end if;
end;
$$ delimiter ;

call salvarCliente ("Vitor", "043.616.612-76", 1536377, 'Solteira(o)', '2006-08-15',"(69) 99913-0319", "DBA", "propria",'Morango','Bela','Acre','Brasil');
call salvarCliente("Pedro", "043.616.612-77", 1472589, 'Namorando', '2006-08-14',"(69) 99913-0317", "DBA", "propria", 'Laranja','Beterraba','Rondonia','Brasil');
call salvarCliente("Julia", "043.616.612-78", 1536812, 'Solteira(o)', '2006-08-18', "(69) 99913-0309", "Nefrologista", "propria", 'Hibisco','Ji-Paraná','Rondonia','Brasil');

select * from cliente;

delimiter $$ 
create procedure salvarFuncionario (nome varchar(60), cpf varchar(20), rg int, estado_civil varchar(20), dataNasc date, telefone varchar(20),setor varchar(20), salario double, carga_hora time,funcao varchar(50), hora_extra time, remuneracao_extra double, rua varchar(20), cidade varchar(20), estado varchar(20), pais varchar(20))
begin
declare verifi_cpf varchar(20);
set verifi_cpf = (select cpf_fun from funcionario where (cpf_fun = cpf));
if (nome <> '') then 
	if (verifi_cpf = '') or (verifi_cpf is null) then 
        insert into funcionario values (null, nome, cpf,rg, estado_civil, dataNasc, telefone,setor,salario,carga_hora,funcao, hora_extra,remuneracao_extra, rua, cidade, estado, pais);
		select concat('O funcionario ', nome, ' foi salvo com sucesso!') as Confirmacao;
	else
		select 'O CPF informado já EXISTE na base de dados!' as Alerta;
    end if; 

else 
	select 'Os campos NOME e CPF são obrigatorios!' as Alerta;
end if;

end;
$$ delimiter ;

call salvarFuncionario ('Luiz','123.456.789-89', 1234567, 'Casado','1988-06-08','(69)1234-4555','Venda',1500.00,'12:00:00','Atender','',0.00,'Flor','Ouro preto','Rondonia','Brasil');
call salvarFuncionario ('Carlos','089.456.789-89', 894567, 'Solteiro','1989-07-15','(69)7888-4555','Serviço',1600.00,'12:00:00','Conserto','',0.00,'Caramelo','Urupa','Rondonia','Brasil');
call salvarFuncionario ('Luiza','123.789.156-89', 1458567, 'Divorciada','1978-12-25','(69)7899-4555','Venda',1500.00,'12:00:00','Atender','',0.00,'Feliz','Rio de Janeiro','Rio de Janeiro','Brasil');
select * from Funcionario;

delimiter $$
create procedure salvarFornecedor(nome_fan varchar(100), razao_social varchar(100), cnpj varchar(25), rua varchar(100),cidade varchar(100), estado varchar(100), pais varchar(100))
begin

declare teste_cnpj varchar(25);
set teste_cnpj = (select cnpj_for from fornecedor where (cnpj_for = cnpj));

if (teste_cnpj = '') or (teste_cnpj is null) then 
	        insert into fornecedor values (null, nome_fan, razao_social, cnpj,rua, cidade, estado, pais);               
        select 'Dados salvos com sucesso' as Confirmacao;
	else
    select 'O cnpj já existe na base de dados' as Erro;

	end if;
 
end;

$$ delimiter ; 

call salvarFornecedor("moveis lindos", "moveis lindos S.A", '12.345.678/0001-00', 'São João',"Ji-Paraná", 'Rondônia','Brasil');
call salvarFornecedor ("moveis perfeitos", "moveis perfeitos S.A", '12.345.678/0002-00','Flor de Liz', "Ji-Paraná", 'Rondônia','Brasil');
call salvarFornecedor("moveis magnificos", "moveis magnificos S.A", '12.345.678/0003-00', 'Casa Preta',"Ji-Paraná", 'Rondônia', 'Brasil');
select * from Fornecedor;

Delimiter $$
create procedure salvarCaixa(total_sai double, total_ent double, saldo_ini double,saldo_fin double, dia date, hora time, numero int, fk_fun int)
begin

declare fk_funciona int;
set fk_funciona = (select id_fun from funcionario where (id_fun = fk_fun));

if (total_ent is not null) and (total_sai is not null) then
    if(saldo_fin is not null) and (saldo_ini is not null) then
        if(dia is not null) then
            insert into caixa values (null, total_sai, total_ent, saldo_ini, saldo_fin, dia, hora, numero,fk_fun);
            select 'Os dados do Caixa foram inseridos com sucesso' as Confirmação;
        else 
            select 'Uma data precisa ser informada' as Erro;
        end if;
    else 
        select 'Os saldos devem ser registrados no caixa, por favor insira os dados correspondentes' as Erro;
    end if;
else
    select 'Os dados de entrada e saída do caixa devem ser preenchidos' as Erro;
end if;

end;
$$ Delimiter ; 

call salvarCaixa(1000, 2000,500,1500.00,'2023-03-03','08:00:00',1, 1);
call salvarCaixa(500, 2050,200,1750.00,'2023-04-04','09:00:00',2, 3);
call salvarCaixa(1000, 2550,300,1850.00,'2023-05-05','07:00:00',3, 2);
select * from Caixa;

delimiter $$
create procedure salvarCompra(nome varchar(20), dataCom date, valor double, fk_fun int, fk_for int)
begin
declare fk_funcionario int;
declare fk_fornecedor int;
set fk_funcionario = (select id_fun from funcionario where (id_fun = fk_fun));
set fk_fornecedor = (select id_for from fornecedor where (id_for = fk_for));

if (valor is not null) then 
		insert into Compra values (null,nome, dataCom, valor, fk_fun, fk_for);
		select 'A Compra foi salva com sucesso!' as Confirmacao;
    else 
     select 'Você não informou o valor da compra' as Alerta;
	end if;
end;
$$ delimiter ;
call salvarCompra('Parafuso', '2023-05-06', 440.00, 1,2);
call salvarCompra('Armário', '2023-06-16', 9500.00, 2,3);
call salvarCompra('Televisão', '2023-05-06', 2000.00, 3,1);
select * from Compra;

delimiter $$ 
create procedure salvarMovel (nome varchar(50), material varchar(50), descricao varchar(100),
 peso double, comprimento double, cor varchar(50), altura double, largura double, valor_tributo double, valor_custo double, valor_ven double, fk_com int)
 begin

 declare fk_compra int;
set fk_compra = (select id_com from compra where (id_com = fk_com));

 if (nome <> '') then 
	insert into Movel values (null,nome, material, descricao, peso, comprimento, cor, altura, largura, valor_tributo, valor_custo, valor_ven, fk_com);
    select 'Móvel salvo com sucesso!' as Confirmacao;
 else 
	select 'Você não informou o nome do móvel' as Alerta;
end if;
end;

call salvarMovel ("cadeira", "madeira", "cadeira de madeira", 3.2, 00, "branca", 10, 50, 40, 30, 500, 1);
call salvarMovel ("cadeira pequena", "madeira", "cadeira pequena", 2.2, 00, "branca", 30, 20, 10, 80, 300,2);
call salvarMovel ("cadeira grande", "madeira", "cadeira grande", 5.2, 00, "branca", 90, 30, 60, 90, 1000,3);
select * from Movel;

$$ delimiter ;

delimiter $$ 
create procedure salvarDespesa(nome varchar(20), data_venc date, data_pag date, fk_com int)
begin

declare fk_compra int;
set fk_compra = (select id_com from compra where (id_com = fk_com));

if (nome <> '') then
	insert into Despesa values (null, nome, data_venc, data_pag, fk_com);
    select 'Despesa salvo com sucesso!' as Confirmacao;
else 
	select 'Você não informou o nome da despesa' as Alerta;
end if;
end;
$$ delimiter ;
call salvarDespesa("agua", '2023-11-16', '2023-06-16', 3);
call salvarDespesa("internet", '2023-11-15', '2023-06-15', 1);
call salvarDespesa("energia", '2023-11-14', '2023-06-14', 2);
select * from Despesa;

delimiter $$ 
create procedure salvarPagamento(nome varchar(20), data_pag date, descricao varchar(50), valor double, fk_fun int, fk_des int, fk_cai int)
begin

declare fk_funcionario int;
declare fk_despesa int;
declare fk_caixa int;
set fk_funcionario = (select id_fun from funcionario where (id_fun = fk_fun));
set fk_despesa = (select id_des from despesa where (id_des = fk_des));
set fk_caixa = (select id_cai from caixa where (id_cai = fk_cai));

if (nome <> '') then
	insert into Pagamento values (null, nome, data_pag, descricao,valor, fk_fun, fk_des, fk_cai);
    select 'Pagamento salvo com sucesso!' as Confirmacao;
else 
	select 'Você não informou o nome do pagamento' as Alerta;
end if;
end;
$$ delimiter ;
call salvarPagamento("agua", '2023-12-19', '',100.00, 3, 2, 1);
call salvarPagamento("Energia", '2023-01-16', '',550.00, 1, 3, 2);
call salvarPagamento("internet", '2023-09-23', '',100.00, 2, 2, 1);
select * from Pagamento; 

delimiter $$ 
create procedure salvarServico(nome varchar(20), descricao varchar(1000))
begin

if (nome <> '') then
	insert into Servico values (null, nome, descricao);
    select 'Serviço salvo com sucesso!' as Confirmacao;
else 
	select 'Você não informou o nome do serviço' as Alerta;
end if;
end;
$$ delimiter ;
call salvarServico("entrega",'Armário');
call salvarServico( "reparo",'Geladeira' );
call salvarServico("entrega",'Fogão' );
select * from servico;

delimiter $$ 
create procedure salvarVenda(nome varchar(20), data_ven date, descricao varchar(50), valor double, fk_fun int, fk_cli int, fk_ser int, fk_mov int)
begin

declare fk_funcionario int;
declare fk_cliente int;
declare fk_servico int;
declare fk_movel int;
set fk_funcionario = (select id_fun from funcionario where (id_fun = fk_fun));
set fk_cliente = (select id_cli from cliente where (id_cli = fk_cli));
set fk_servico = (select id_ser from servico where (id_ser = fk_ser));
set fk_movel = (select id_mov from movel where (id_mov = fk_mov));

if (valor is not null ) then
	insert into Venda values (null, nome, data_ven, descricao,valor, fk_fun, fk_cli, fk_ser, fk_mov);
    select 'Venda salva com sucesso!' as Confirmacao;
else 
	select 'Você não informou o valor da venda' as Alerta;
end if;
end;
$$ delimiter ;
call salvarVenda("venda3",'2023-06-17', "venda de sofa", 1500.00, 3,1, 2, 3);
call salvarVenda( "venda4",'2023-06-16', "venda de cadeira", 258.50,1, 2, 1, 3);
call salvarVenda( "venda5",'2023-06-15', "venda de bancada", 2900.00,3,1, 3, 2);
select * from venda;

delimiter $$ 
create procedure salvarMovel_Venda(fk_mov int, fk_ven int)
begin

declare fk_venda int;
declare fk_movel int;
set fk_venda = (select id_ven from venda where (id_ven = fk_ven));
set fk_movel = (select id_mov from movel where (id_mov = fk_mov));
	
    if (fk_venda is not null) or (fk_movel is not null) then  
		insert into movel_venda values (null, fk_mov,fk_ven);
		select (' Foi salvo com sucesso!') as Confirmacao;
	else
		select 'A FK informada não existe na tabela de origem' as Alerta;
	 end if;			

end;
$$ delimiter ;
call salvarMovel_Venda(1,2);
call salvarMovel_Venda(3,1);
call salvarMovel_Venda(3,2);
select * from movel_venda;

delimiter $$ 
create procedure salvarRecebimento(dataRec date, parcela int, valor double, vencimento date, fk_ven int, fk_cai int)
begin

declare fk_venda int;
declare fk_caixa int;
set fk_venda = (select id_ven from venda where (id_ven = fk_ven));
set fk_caixa = (select id_cai from caixa where (id_cai = fk_cai));
	
    if (valor is not null) then  
		insert into recebimento values (null, dataRec, parcela, valor, vencimento, fk_ven, fk_cai);
		select ('Recebimento foi salvo com sucesso!') as Confirmacao;
	else
		select 'Você não informou o valor do recebimento' as Alerta;
	 end if;			

end;
$$ delimiter ;
call salvarRecebimento('2023-05-08', 15, 1500.00,'2024-05-08', 1,2);
call salvarRecebimento('2021-07-09', 1, 100.00,'2021-08-17', 3,2);
call salvarRecebimento('2023-04-15', 10, 2500.00,'2024-05-13', 2,3);
select * from Recebimento;
