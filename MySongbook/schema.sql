CREATE DATABASE MySongbook;

GO

USE MySongbook;

GO

-- Security Table Scripts
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);

CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


-- Custom MySongbook Tables --

CREATE TABLE Song
(
	song_number int identity(1, 1),
	title varchar(40) not null,
	composer varchar(50) not null, 
	lyricist varchar(50), 
	source_material varchar(30),
	genre varchar(40) not null,
	gender varchar(15), 
	voice_part varchar(20), 

	CONSTRAINT pk_songnumber PRIMARY KEY(song_number),
);

CREATE TABLE userInfo_song
(
	user_id nvarchar(128), 
	song_number int, 

	CONSTRAINT fk_userSong_userInfo FOREIGN KEY(user_id) REFERENCES AspNetUsers(Id),
	CONSTRAINT fk_userSong_song FOREIGN KEY(song_number) REFERENCES song(song_number),
	CONSTRAINT pk_userinfo_song PRIMARY KEY(user_id, song_number), 

);

CREATE TABLE Forum
(
	post_id int identity(1, 1),
	forum_post varchar(500) not null,
	display_name varchar(30) not null,
	post_date DateTime not null,

	CONSTRAINT pk_id PRIMARY KEY(post_id),
);


-- Starter Song Data --

INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Dancing Through Life', 'Schwartz, Stephen', 'Schwartz, Stephen','Wicked', 'Contemporary Musical Theatre Uptempo', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Journey to the Past', 'Flaherty, Stephen', 'Ahrens, Lynn', 'Anastasia', 'Contemporary Musical Theatre Ballad', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Dyin Aint So Bad', 'Wildhorn, Frank', 'Black, Don', 'Bonnie and Clyde', 'Contemporary Musical Theatre Ballad', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Much More', 'Schmidt, Harvey', 'Jones, Tom', 'The Fantasticks', 'Classical Musical Theatre Uptempo', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Cant Say No', 'Rodgers, Richard', 'Hammerstein II, Oscar', 'Oklahoma!', 'Classical Musical Theatre Uptempo', 'Female', 'Alto')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('It All Fades Away', 'Brown, Jason Robert', 'Brown, Jason Robert', 'The Bridges of Madison County', 'Contemporary Musical Theatre Ballad', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Il Mondo Era Vuoto', 'Guettel, Adam', 'Guettel, Adam', 'The Light in the Piazza', 'Contemporary Musical Theatre Ballad', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Im Not Afraid of Anything', 'Brown, Jason Robert', 'Brown, Jason Robert', 'Songs for a New World', 'Contemporary Musical Theatre Uptempo', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Youll Be Back', 'Miranda, Lin-Manuel', 'Mirand, Lin-Manuel', 'Hamilton', 'Contemporary Musical Theatre Uptempo', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Bring Him Home', 'Schonberg, Claude-Michel', 'Kretzmer, Herbert & Boublil, Alain', 'Les Miserables', 'Contemporary Musical Theatre Ballad', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Hold On', 'Simon, Lucy', 'Norman, Marsha', 'The Secret Garden', 'Contemporary Musical Theatre Ballad', 'Female', 'Alto')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Everlasting', 'Miller, Chris', 'Tysen, Nathan', 'Tuck Everlasting', 'Contemporary Musical Theatre Ballad', 'Female', 'Child')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Till I Hear You Sing', 'Webber, Andrew Lloyd', 'Slater, Glenn', 'Love Never Dies', 'Contemporary Musical Theatre Ballad', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Luck Be a Lady', 'Loesser, Frank', 'Loesser, Frank', 'Guys and Dolls', 'Classical Musical Theatre Uptempo', 'Male', 'Bass-Baritone')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Part of Your World', 'Menken, Alan', 'Ashman, Howard', 'The Little Mermaid', 'Disney', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('If I Didnt Believe In You', 'Brown, Jason Robert', 'Brown, Jason Robert', 'The Last Five Years', 'Contemporary Musical Theatre Ballad', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Goodbye', 'Salzman, Joshua', 'Cunningham, Ryan', 'I Love You Becuase', 'Contemporary Musical Theatre Uptempo', 'Male', 'Bari-Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('The Light in the Piazza', 'Guettel, Adam', 'Guettel, Adam', 'The Light in the Piazza', 'Contemporary Musical Theatre Ballad', 'Female', 'Soprano')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Barely Breathing', 'Sheik, Duncan', 'Sheik, Duncan', 'Duncan Sheik', 'Pop/Rock/Country', 'Male', 'Bari-Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Perfect', 'Morissette, Alanis', 'Morissette, Alanis', 'Alanis Morissette', 'Pop/Rock/Country', 'Female', 'Mezzo')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('Go the Distance', 'Menken, Alan', 'Zippel, David', 'Hercules', 'Disney', 'Male', 'Tenor')
INSERT INTO song (title, composer, lyricist, source_material, genre, gender, voice_part) VALUES('One Second and a Million Miles', 'Brown, Jason Robert', 'Brown, Jason Robert', 'The Bridges of Madison County', 'Contemporary Musical Theatre Ballad', 'Either/Both', 'Duet')

INSERT INTO forum (forum_post, display_name) VALUES ('Feel free to leave a note for your fellow voice teachers! Find a useful link or article? Share it here!', 'Shane');