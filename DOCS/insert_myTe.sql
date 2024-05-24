USE DB_MYTE;
GO
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Desenvolvedor Front-End');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Desenvolvedor Back-End');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Engenheiro de Software');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Analista de Segurança da Informação');
INSERT INTO TB_CARGOS (nomeCargo) VALUES ('Administrador de Banco de Dados');

INSERT INTO TB_COLABORADORES (cpf, id_cargo, administrador) VALUES ('76493417805', 1, 1); -- Desenvolvedor Front-End, administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, administrador) VALUES ('61212235886', 2, 0); -- Desenvolvedor Back-End, não administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, administrador) VALUES ('49827505807', 3, 0); -- Engenheiro de Software, não administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, administrador) VALUES ('96438992844', 4, 1); -- Analista de Segurança da Informação, administrador
INSERT INTO TB_COLABORADORES (cpf, id_cargo, administrador) VALUES ('99715464858', 5, 0); -- Administrador de Banco de Dados, não administrador

INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS001', 'Desenvolvimento de sistema de gestão de vendas', 1);
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS001', 'Desenvolvimento de sistema de gestão de vendas', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS002', 'Desenvolvimento de sistema de controle de estoque', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS003', 'Desenvolvimento de aplicativo mobile para controle financeiro', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS004', 'Desenvolvimento de plataforma de e-commerce', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS005', 'Integração de sistemas legados', 2); -- Non-chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS006', 'Atualização de tecnologia em sistema de RH', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS007', 'Desenvolvimento de sistema de gestão de projetos', 1); -- Chargeability
INSERT INTO TB_WBS (codigo, descricao, tipo) VALUES ('WBS008', 'Implementação de CRM corporativo', 1); -- Chargeability

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