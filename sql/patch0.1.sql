ALTER TABLE Clients DROP CONSTRAINT uq_Clients_client_phone;
ALTER TABLE Clients DROP CONSTRAINT uq_Clients_client_paycard;
ALTER TABLE Salers DROP CONSTRAINT uq_Salers_saler_phone;
ALTER TABLE Salers DROP CONSTRAINT uq_Salers_saler_paycard;
GO