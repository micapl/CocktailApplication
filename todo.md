To do list: (fill [x] when finished)

### creating classes:
- [] create class user
- [] create class cocktail
- [] create class ingredient
- [] create class tag
- [] create class drinking session
- [] create class user history entry
- [] bonus: put some entries in database to make sure it works
---
### changing relations between classes:
- [] allow users to create cocktails
- [] allow users to hide/show cocktails
- [] allow users to have and add friends
- [] allow users to add ingredients to their bar
- [] allow users to favourite cocktails
- [] add ingredient list to cocktails
- [] make ingredients able to be in multiple recipes
- [] make cocktails have tags
- [] make users have a drinking history
- [] allow users to add to their drinking history
- [] allow drinking sessioss to consist of cocktails
---
### deleting and hiding cocktails: 
- [] check if a cocktail is created by user
##### if user owned:
- [] delete cocktail locally
- [] delete record of cocktail
- [] give feedback to user about deleting
##### if not owned by user:
- [] add cocktail to user's hidden list [create a hidden list?]: #
- [] give feedback to user about hiding
---
### updating the database:
- [] allow user with admin privileges to post new cocktails
- [] allow user with admin privileges to update existing cocktails
- [] validate admin role of user
- [] insert the admin user's update to the database
- [] give feedback about success
- [] retrieve last database synchronisation timestamp on user login
- [] add/update cocktaild edited after date of synchronisation
- [] give feedback about recency of database
- [] update synchronisation timestamp
- [] show user dashboard with latest data

##### optional:
- [] add a user made database
- [] allow users to share their own cocktails 
- [] allow users to edit their cocktails
---
### giving user privileges:
- [] allow admin to manage global database
- [] allow users to register
- [] allow users to log in
- [] allow users to create cocktails
- [] allow users to edit owned cocktails
- [] allow users to delete owned cocktails
- [] allow users to hide public cocktails
- [] allow users to manage ingredients in their bar
- [] allow users to use "calculate available cocktails" function
- [] allow users to scale servings of cocktails
- [] allow users to favourite/unfavourite recipes
- [] allow users to manage tags [should we though? self-owned cocktails sure, but not public]: #
- [] allow users to log drinking sessions
- [] allow users to tag friends in drinking sessions
- [] allow users to view statistics
- [] allow users to get recommendations
- [] allow users to add each other as friends
- [] allow users to share cocktail recipes with friends