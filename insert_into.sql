INSERT INTO Computer (CompID, MfgName, MFGModel, ProcType) VALUES ('B121', 'Bantam', '48X', '486DX');
INSERT INTO Computer (CompID, MfgName, MFGModel, ProcType) VALUES ('B221', 'Bantam', '48D', '486DX2');
INSERT INTO Computer (CompID, MfgName, MFGModel, ProcType) VALUES ('C007', 'Cody', 'D1', '486DX');
INSERT INTO Computer (CompID, MfgName, MFGModel, ProcType) VALUES ('M759', 'Lemmin', 'GRL', '486SX');

INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (123, 'Melissa', 'Mendez', '874-736-8752');
INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (124, 'Ramon', 'Alvarez', '121-234-5462');
INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (562, 'Betty', 'Feinstein', '871-653-6723');
INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (611, 'Melissa', 'Dinh', '296-363-6452');
INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (745, 'Jonathan', 'Smith', '312-653-8234');
INSERT INTO Employee (EmpNum, EmpFirst, EmpLast, EmpPhone) VALUES (823, 'Tina', 'Duarte', '708-234-7723');

INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (23556, 'C007', 123, 'Accounting');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (32808, 'M759', 611, 'Accounting');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (37691, 'B121', 124, 'Sales');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (57772, 'C007', 562, 'Info Systems');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (59836, 'B221', 124, 'Home');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (63721, 'M759', 611, 'Home');
INSERT INTO PC (TagNum, CompID, EmpNum, Location) VALUES (77740, 'M759', 562, 'Home');

INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('AC01', 'Boise Accounting', '3.00', 'Accounting', 725.83);
INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('DB32', 'Manta', '1.50', 'Database', 380.00);
INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('DB33', 'Manta', '2.10', 'Database', 430.18);
INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('SS11', 'Limitless View', '5.30', 'Spreadsheet', 271.95);
INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('WP08', 'Words & More', '2.00', 'Word Processing', 185.00);
INSERT INTO Package (PackID, PackName, PackVers, PackType, PackCost) VALUES ('WP09', 'Freeware Processing', '4.27', 'Word Processing', 30.00);

INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('AC01', 32808, '2025-09-13', 745.95);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('AC01', 63721, '2025-04-02', 867.56);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('DB32', 32808, '2025-12-03', 380.00);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('DB32', 37691, '2025-06-15', 380.00);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('DB33', 57772, '2025-05-27', 412.77);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('WP08', 32808, '2024-01-12', 185.00);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('WP08', 37691, '2024-06-15', 227.50);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('WP08', 57772, '2023-05-27', 170.24);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('WP09', 59836, '2022-10-30', 35.00);
INSERT INTO Software (PackID, TagNum, InstDate, SoftCost) VALUES ('WP09', 77740, '2024-05-27', 35.00);
