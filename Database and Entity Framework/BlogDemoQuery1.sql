--Saved Queries require you re-connect in VS to run || Choose Server (localdb)\MSSQLLocalDB || and BlogDemo 
-- See History for saved connection

--INSERT INTO BlogPosts (Title, Body)
--VALUES
--	('First Post', 'This is my first post!'),
--	('Second Post', 'This is my second post!')

SELECT * from BlogPostComments

SELECT * from BlogPosts


--INSERT INTO BlogPostComments (BlogPostID, Comment)
--VALUES (1, 'This post is great')

--SELECT bp.Id, bp.TITLE, bpc.Comment
--FROM BlogPosts bp
--INNER JOIN BlogPostComments bpc ON bp.Id = bpc.BlogPostId

--DELETE FROM BlogPostComments WHERE BlogPostId = 1
