Use AnimalRescuerBase
select * from account
CREATE TABLE dbo.Account (
	ID_Account INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Account PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	Role NVARCHAR(MAX) NOT NULL,
	Password NVARCHAR(MAX) NOT NULL,
	Mail VARCHAR(50) NOT NULL,
	Balance INT NOT NULL,
	Number VARCHAR(50) NOT NULL,
	CardInformation NVARCHAR(MAX) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Age INT NOT NULL
);

CREATE TABLE dbo.Animal (
	ID_Animal INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Animal PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	AnimalInfo NVARCHAR(MAX) NOT NULL,
	ImageUrl NVARCHAR(MAX) NOT NULL,
);

CREATE TABLE dbo.Donations (
	ID_Donations INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Donations PRIMARY KEY,
	ID_Account INT NOT NULL,
	ID_Animal INT NOT NULL,
	Donation INT NOT NULL,
);


CREATE TABLE dbo.Comment(
	ID_Comment INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Comments PRIMARY KEY,
	UserMail VARCHAR(50) NOT NULL,
	ID_Animal INT NOT NULL,
	CommentText NVARCHAR(MAX) NOT NULL,
);


CREATE TABLE dbo.Subcription (
ID_Subcription INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Subscription PRIMARY KEY,
Mail VARCHAR(50) NOT NULL,
);

CREATE TABLE dbo.FeedBackMessage (
ID_FeedBackMessage INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_FeedBackMessage PRIMARY KEY,
UserMail VARCHAR(50) NOT NULL,
UserName NVARCHAR(MAX) NOT NULL,
MessageSubject NVARCHAR(MAX) NOT NULL,
Text NVARCHAR(MAX) NOT NULL,
);

ALTER TABLE Account ADD UNIQUE (Mail);

ALTER TABLE Donations ADD CONSTRAINT FK0_Donations FOREIGN KEY (ID_Account) REFERENCES Account(ID_Account);
ALTER TABLE Donations ADD CONSTRAINT FK1_Donations FOREIGN KEY (ID_Animal) REFERENCES Animal(ID_Animal);
ALTER TABLE Comment ADD CONSTRAINT FK0_Comment FOREIGN KEY (UserMail) REFERENCES Account(Mail);
ALTER TABLE Comment ADD CONSTRAINT FK1_Comment FOREIGN KEY (ID_Animal) REFERENCES Animal(ID_Animal);
ALTER TABLE Subcription ADD CONSTRAINT FK0_Subscription FOREIGN KEY (Mail) REFERENCES Account(Mail);
ALTER TABLE FeedBackMessage ADD CONSTRAINT FK0_FeedBackMessage FOREIGN KEY (UserMail) REFERENCES Account(Mail);

insert into Account(Name, Role, Password, Mail, Balance, Number, CardInformation, DateOfBirth, Age) values('Admin','admin','admin1234','admin@gmail.com',0,0,' ','1900.05.05',0)
insert into Animal(Name, AnimalInfo,ImageUrl) Values(N'Кошка Дуся',
N'Кошка Дуся поступила к нам совсем недавно. Причина ее визита -  Калицивироз - инфекционное заболевание кошек, проявляющееся в типичных случаях повышением температуры, конъюнктивитом, изъязвлением слизистых ротовой и носовой полостей, хромотой.
Для того, чтобы Дуся смогла вернуться к ее главным занятиям - гонкой за мячом и обнимашками с игрушками, ей необходима ваша помощь. Ваша поддержка - шаг на пути выздоровления нашей самой ласковой кошечки.',
'https://cdn.recyclemag.ru/content/0/07eeefe18f444ce06ad3546be8437db3.jpg')
insert into Animal(Name, AnimalInfo,ImageUrl) Values(N'Пес Шарик',
N'Пес Шарик - это наша гордость. До недавнего времени он участвовал в соревнованиях и занимал первые места. Причина остановки его деятельности - дисплазия. К сожалению, 
диагноз был выявлен слишком поздно, поэтому Шарику требуются средства на операцию по замене сустава. Только с Вашей поддержкой наш чемпион сможет снова оказаться на вершине пьедестала.',
'https://i.istravest.ru/photos/2018/01/650x486_pQRJKeWytY9lIf7x83D4.jpg')
insert into Animal(Name, AnimalInfo,ImageUrl) Values(N'Сова Соня',
N'Диагноз совы Сони - туберкулез. Данное заболевание оказывает сильное влияние на состояние птицы, но мы все чаще и чаще слышим заветное "Угу". Ваша финансовая поддержка поможет сове как можно скорее выбраться из клетки.'
,'https://sklad.freeimg.ru/rsynced_images/owl-1400061_1280.jpg')

insert into Animal(Name, AnimalInfo,ImageUrl) Values(N'Енот Степа',
N'Енот Степа - наш главный чистюля. Он бережно стирал все на своем пути, пока не повредил лапы в бою. Ваша поддержка поможет Степе вернуться к выполнению любимых хлопот.',
'https://aif-s3.aif.ru/images/016/157/3cce4489aa7360c774c3461ee5e28bfc.jpg')
insert into Animal(Name, AnimalInfo,ImageUrl) Values(N'Манул Крепыш',
N'Манул - невероятно пушистый, ленивый и редкий зверь. К сожалению, при контакте с кошкой Манул Крепыш подхватил серьезное инфекционное заболевание и теперь его здоровье в наших с Вами руках.
Мы будем очень благодарны каждому, кто окажет финансовую поддержку любой суммой.',
'https://aif-s3.aif.ru/images/016/157/77c3a8b19fdf6c6f0426b4dfd55b3a6e.jpg')