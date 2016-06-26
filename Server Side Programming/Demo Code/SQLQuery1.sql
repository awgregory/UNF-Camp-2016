--INSERT INTO BlogPosts (Title, Body)
--VALUES
--	('First Post', 'This is my first post!'),
--	('Second Post', 'This is my second post!')

SELECT * from BlogPostComments

--INSERT INTO BlogPostComments (BlogPostID, Comment)
--VALUES (1, 'This post is great')

--SELECT bp.Id, bp.TITLE, bpc.Comment
--FROM BlogPosts bp
--INNER JOIN BlogPostComments bpc ON bp.Id = bpc.BlogPostId

DELETE FROM BlogPostComments WHERE BlogPostId = 1

