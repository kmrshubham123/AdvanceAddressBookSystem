create procedure  SpAddressBook
@FirstName varchar(25),
@LastName varchar(25),
@address varchar(50),
@City varchar(20),
@State varchar(20),
@Zip int,
@PhoneNumber varchar(15),
@Email varchar(50),
@Type varchar(25)
AS
	INSERT INTO AddressBook(FirstName, LastName, address, City, State, Zip, PhoneNumber, Email,Type)  
	VALUES(@FirstName ,@LastName, @address, @City, @State, @Zip, @PhoneNumber, @Email,@Type);
RETURN 0