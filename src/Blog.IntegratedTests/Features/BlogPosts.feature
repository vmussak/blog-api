Feature: BlogPosts

A short summary of the feature

@tag1
Scenario: Create a new post
	Given A post with title='The Post' and content='Hello'
	When Call the endpoint '/api/posts'
	Then A new post should be created with 0 comments
