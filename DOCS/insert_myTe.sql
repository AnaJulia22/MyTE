USE DB_MYTE;
GO
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Desenvolvedor Front-End');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Desenvolvedor Back-End');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Engenheiro de Software');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Analista de Segurança da Informação');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Administrador de Banco de Dados');

INSERT INTO TB_COLABORADORES (cpf, id_cargo, nome, perfil ) VALUES ('76493417805', 1, 'Clarice Lispector', 'GESTOR DE PROJETOS'); -- Desenvolvedor Front-End, administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, nome, perfil) VALUES ('61212235886', 2, 'Machado de Assis', 'COLABORADOR'); -- Desenvolvedor Back-End, não administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, nome, perfil) VALUES ('49827505807', 3, 'Eça de Queiróz', 'ADMIN'); -- Engenheiro de Software, não administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, nome, perfil) VALUES ('96438992844', 4, 'Fernando Pessoa', 'GESTOR DE PROJETOS'); -- Analista de Segurança da Informação, administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, nome, perfil) VALUES ('99715464858', 5, 'Vinicius de Moraes', 'COLABORADOR'); -- Administrador de Banco de Dados, não administrador

INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBSPDR001', 'Day Off', 1);
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBSPDR002', 'Férias', 1);
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBSPDR003', 'Sem tarefa', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS001', 'Desenvolvimento de aplicativo mobile para controle financeiro', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS002', 'Desenvolvimento de plataforma de e-commerce', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS003', 'Integração de sistemas legados', 2); -- Non-chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS004', 'Atualização de tecnologia em sistema de RH', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS005', 'Desenvolvimento de sistema de gestão de projetos', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS006', 'Implementação de CRM corporativo', 1); -- Chargeability

-- Registro de dias e horas para colaborador 1
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-01 08:00:00', 1, '76493417805', '2024-05-01', 8);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-02 08:00:00', 2, '76493417805', '2024-05-02', 7);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-03 08:00:00', 3, '76493417805', '2024-05-03', 8);
 
-- Registro de dias e horas para colaborador 2
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-01 08:00:00', 4, '61212235886', '2024-05-01', 8);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-02 08:00:00', 5, '61212235886', '2024-05-02', 7);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-03 08:00:00', 6, '61212235886', '2024-05-03', 8);
 
-- Registro de dias e horas para colaborador 3
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-01 08:00:00', 7, '49827505807', '2024-05-01', 8);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-02 08:00:00', 8, '49827505807', '2024-05-02', 7);
INSERT INTO TB_REGISTRO_DIAS_HORAS (data_registro, id_wbs, cpf, dia, horas) VALUES ('2024-05-03 08:00:00', 1, '49827505807', '2024-05-03', 8);