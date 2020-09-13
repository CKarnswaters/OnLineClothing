INSERT INTO items (CategoryID, Title, Price, ItemDescription, Image) 
VALUES (
(SELECT ID FROM categories WHERE Category = 'Hat'),
'Baseball Cap',
9.99,
'A casual black baseball cap to wear to events or just for fun!',
'BaseballCap.png'),(
(SELECT ID FROM categories WHERE Category = 'Hat'),
'Bowler Cap',
19.99,
'A fancy bowler cap to wear to your next group meeting!',
'BowlerCap.png'),(
(SELECT ID FROM categories WHERE Category = 'Hat'),
'Sunhat',
15.99,
'A beautiful sunhat to keep you in the shade whether working or chilling!',
'Sunhat.png'),(
(SELECT ID FROM categories WHERE Category = 'Hat'),
'Top Hat',
39.99,
'A very fancy top hat to wear to a formal event or out on the town!',
'TopHat.png'),(
(SELECT ID FROM categories WHERE Category = 'Pants'),
'Dress Pants',
39.99,
'A fancy pair of black dress pants to wear for a formal event!',
'DressPants.png'),(
(SELECT ID FROM categories WHERE Category = 'Pants'),
'Jeans',
19.99,
'A simple pair of blue jeans, good for most occasions!',
'Jeans.png'),(
(SELECT ID FROM categories WHERE Category = 'Pants'),
'Running Pants',
9.99,
'A pair of loose pants to help with freedom of movement when running!',
'RunningPants.png'),(
(SELECT ID FROM categories WHERE Category = 'Pants'),
'Skirt',
24.99,
'A flowing skirt that is great for formal events!',
'Skirt.png'),(
(SELECT ID FROM categories WHERE Category = 'Pants'),
'Pajama Pants',
14.99,
'A pair of pajama pants which are comfortable to sleep or lounge in!',
'SleeperPants.png'),(
(SELECT ID FROM categories WHERE Category = 'Shirt'),
'Button Up Shirt',
29.99,
'A simple gray button up shirt that you can wear for work!',
'ButtonUp.png'),(
(SELECT ID FROM categories WHERE Category = 'Shirt'),
'Graphic T-Shirt',
9.99,
'A t-shirt with a nice design on the front of it!',
'GraphicTee.png'),(
(SELECT ID FROM categories WHERE Category = 'Shirt'),
'Long Sleeve Button Up Shirt',
39.99,
'A long sleeved blue variation of our button up shirt!',
'LongSleeve.png'),(
(SELECT ID FROM categories WHERE Category = 'Shirt'),
'Polo Shirt',
24.99,
'A short sleeved professional looking shirt good for small businesses',
'Polo.png'),(
(SELECT ID FROM categories WHERE Category = 'Shirt'),
'Sweater',
29.99,
'A warm sweater good for the winter or just for relaxing at home',
'Sweater.png'),(
(SELECT ID FROM categories WHERE Category = 'Shoes'),
'Boots',
39.99,
'A good pair of boots good for working, hiking and more!',
'Boots.png'),(
(SELECT ID FROM categories WHERE Category = 'Shoes'),
'Flats',
9.99,
'Flats to go with a nice outfit, comfortable to wear!',
'Flats.png'),(
(SELECT ID FROM categories WHERE Category = 'Shoes'),
'Running Shoes',
19.99,
'Running shoes for joggers and people who are on the go!',
'RunningShoes.png'),(
(SELECT ID FROM categories WHERE Category = 'Shoes'),
'Sandals',
5.99,
'Comfortable sandals for walking around on hot summer days',
'Sandals.png'),(
(SELECT ID FROM categories WHERE Category = 'Shoes'),
'Work Shoes',
29.99,
'Anti-slip work environment shoes for getting the job done!',
'WorkShoes.png')




