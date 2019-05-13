USE `chtr`;
insert into `rooms`(Id, Name) Values 
	('42ab8242-ce98-4dd3-9778-46fa4390e217', 'General'),
	('c0bbd374-e592-46eb-8c33-9a826f4c80fa', 'Random'),
	('10e37786-2206-4d87-9ee3-eb37c6619257', 'Dev');

insert into `users`(Id, UserName, FullName) Values 
	('0adc7077-1682-4830-b5c2-4603977fc19a', 'rugj', 'Rune Gjedde'), 
	('cb884606-9854-4bdd-9627-780939511604', 'arbj', 'Arne Bjarntsen'),
	('5e103e2b-a5ae-4074-85ef-0637c80dbc11', 'gero', 'Geir Roland');
  
insert into `userroomrelation`(UserId, RoomId) Values
	('0adc7077-1682-4830-b5c2-4603977fc19a','42ab8242-ce98-4dd3-9778-46fa4390e217'),
	('0adc7077-1682-4830-b5c2-4603977fc19a','c0bbd374-e592-46eb-8c33-9a826f4c80fa'),
	('cb884606-9854-4bdd-9627-780939511604','c0bbd374-e592-46eb-8c33-9a826f4c80fa'),
	('cb884606-9854-4bdd-9627-780939511604','10e37786-2206-4d87-9ee3-eb37c6619257'),
	('5e103e2b-a5ae-4074-85ef-0637c80dbc11','42ab8242-ce98-4dd3-9778-46fa4390e217');