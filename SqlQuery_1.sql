CREATE PROC showwishnames
@username VARCHAR(20)
AS
SELECT name
FROM Wishlist
WHERE username = @username;
GO