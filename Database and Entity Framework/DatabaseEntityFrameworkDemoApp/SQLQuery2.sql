--Saved Queries require you connect again when you run || Choose Server (localdb)\MSSQLLocalDB and BlogDemo || See History for saved connection

-- You don't have to comment all sql queries out, just hightlight the one you want to run


--INSERT INTO BlogPosts (Title, Body)
--VALUES
--	('First Post', 'This is my first post!'),
--	('Second Post', 'This is my second post!')

--SELECT * from BlogPostComments

--select * from blogposts
--where BlogPosts.BODY
--like '%post%'


--INSERT INTO BlogPostComments (BlogPostID, Comment)
--VALUES (1, 'This post is great')

SELECT bp.Id, bp.TITLE, bpc.Comment
FROM BlogPosts bp
INNER JOIN BlogPostComments bpc ON bp.Id = bpc.BlogPostId

SELECT bp.Id, bp.TITLE, bpc.Comment
FROM BlogPosts bp
LEFT JOIN BlogPostComments bpc ON bp.Id = bpc.BlogPostId

--DELETE FROM BlogPostComments WHERE BlogPostId = 1
