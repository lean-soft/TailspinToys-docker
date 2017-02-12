/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Inventory Statuses */
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('In Stock');
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('Back Order');
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('Pre-order');
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('Special Order');
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('Discontinued');
INSERT INTO [dbo].[InventoryStatus] ([Description]) VALUES ('Currently Unavailable');

/* Order Statuses */
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (1, 'New');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (2, 'Submitted');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (3, 'Verified');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (4, 'Charged');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (5, 'Packaging');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (6, 'Shipped');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (7, 'Returned');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (8, 'Cancelled');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (9, 'Refunded');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (10, 'Closed');
INSERT INTO [dbo].[OrderStatus] ([OrderSTatusID], [Description]) VALUES (99, 'Not Checked Out');

/* Delivery Method */
INSERT INTO [dbo].[DeliveryMethod] ([Description]) VALUES ('Shipped');
INSERT INTO [dbo].[DeliveryMethod] ([Description]) VALUES ('Download');
INSERT INTO [dbo].[DeliveryMethod] ([Description]) VALUES ('Email');

/* Shipping Methods */
INSERT INTO [dbo].[ShippingMethods] ([ShippingMethodID], [Carrier], [ServiceName], 
	[RatePerPound], [BaseRate], [EstimatedDelivery], [DaysToDeliver]) VALUES
	(1,	'FedEx', 'Overnight', 3, 12, 'Next Morning By 9AM', 1);
INSERT INTO [dbo].[ShippingMethods] ([ShippingMethodID], [Carrier], [ServiceName], 
	[RatePerPound], [BaseRate], [EstimatedDelivery], [DaysToDeliver]) VALUES
	(2, 'FedEx', 'Next Day', 2, 10, 'End of Next Business Day', 1);
INSERT INTO [dbo].[ShippingMethods] ([ShippingMethodID], [Carrier], [ServiceName], 
	[RatePerPound], [BaseRate], [EstimatedDelivery], [DaysToDeliver]) VALUES
	(3, 'USPS', 'Priority Mail', 1, 5, '2-3 Business Days', 3);
INSERT INTO [dbo].[ShippingMethods] ([ShippingMethodID], [Carrier], [ServiceName], 
	[RatePerPound], [BaseRate], [EstimatedDelivery], [DaysToDeliver]) VALUES
	(4, 'USPS', 'Ground', 1, 1, '3-5 Business Days', 4);
	
/* Tax Rates */
INSERT INTO [dbo].[TaxRates] ([Rate], [Region], [Country]) VALUES
	(0.0825, 'CA', 'US');
INSERT INTO [dbo].[TaxRates] ([Rate], [Region], [Country]) VALUES
	(0.0645, 'HI', 'US');

/* Product Categories */
INSERT INTO [dbo].[Categories] ([Code], [Title]) VALUES ('model', 'Model Airplanes');
INSERT INTO [dbo].[Categories] ([Code], [Title]) VALUES ('paper', 'Paper Airplanes');

/* Products */
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('modnwt', 1, 'Northwind Trader', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'nwt', 1, 1,
	'Move cargo in style with the Northwind Trader.');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('model', 'modnwt');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modnwt', 'en', 'Summary', 0, 
	'Our new Northwind Trader cargo plane is the perfect next addition to your flying fleet.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modnwt', 'en', 'From The Manufacturer', 0, 
	'The Northwind Trader model is ready to carry cargo around the globe. Or outfit it for passenger travel. The Northwind Trader is our largest model airplane. Complete with customization options for almost any configuration, the Northwind Trader is a perfect gift for seasoned modelers and expert pilots. Checkout the enormous wingspan.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modnwt', 'en', 'Technical Details', 0, 
	'<ul><li><b>Weight</b>: 6 lbs</li><li><b>Height</b>: 6"</li><li><b>Wingspan</b>: 30"</li><li><b>Special Feature</b>: Patented balanced power engines, cargo and passenger customization kits</li></ul>');
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('modfcf', 1, 'Fourth Coffee Flyer', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'fcf', 1, 1,
	'The Fourth Coffee Flyer is a model airplane for the highly caffeinated.');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('model', 'modfcf');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modfcf', 'en', 'Summary', 0, 
	'Show off your stunt piloting abilities with the ultimate in tight acrobatic planes.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modfcf', 'en', 'From The Manufacturer', 0, 
	'Intentionally twitchy controls, including our tightest fly-by-wire configuration ever, make the Fourth Coffee Flyer the most exciting model in this catalog. Fly circles around your friends and improve your repair skills as you learn to fly this plane. For advanced pilots only.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modfcf', 'en', 'Technical Details', 0, 
	'<ul><li><b>Weight</b>: 2 lbs</li><li><b>Height</b>: 3"</li><li><b>Wingspan</b>: 9"</li><li><b>Special Feature</b>: Dual-twitch fly-by-wire control kit, instant spike stunt engine, minor crash repair kit</li></ul>');
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('modtrr', 1, 'Trey Research Rocket', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'trr', 1, 1,
	'The best of our modern design with self-stabilizing controls');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('model', 'modtrr');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modtrr', 'en', 'Summary', 0, 
	'The Trey Research Rocket is our modern stunt model airplane.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modtrr', 'en', 'From The Manufacturer', 0, 
	'Fast, easy to control and full of plenty of surprises, the Trey Research Rocket is a good starter airplane. Build up your stunt portfolio with this exciting, but forgiving model airplane.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('modtrr', 'en', 'Technical Details', 0, 
	'<ul><li><b>Weight</b>: 1.5 lbs</li><li><b>Height</b>: 2"</li><li><b>Wingspan</b>: 12"</li><li><b>Special Feature</b>: Trainer landing rig, "How to fly in style" stunt guide video</li></ul>');
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('papwts', 1, 'Wingtip Toys Stunt Plane', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'wts', 1, 1,
	'Throw our namesake plane and it may never come back to earth');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('paper', 'papwts');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwts', 'en', 'Summary', 0, 
	'You will not believe this is a paper airplane.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwts', 'en', 'From The Manufacturer', 0, 
	'This old school airplane will out soar and outlast any other paper airplane you can buy. We have been improving this design for over 10 years, so you can trust it will perform when you throw it.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwts', 'en', 'Technical Details', 0, 
	'<ul><li><b>Wingspan</b>: 10"</li><li><b>Special Feature</b>: Stunt folding options</li></ul>');
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('papwwi', 1, 'World Wide Importer', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'wwi', 1, 1,
	'The ultimat luxury item, in paper');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('paper', 'papwwi');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwwi', 'en', 'Summary', 0, 
	'Hang this paper airplane from the ceiling and dream of a life in the clouds.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwwi', 'en', 'From The Manufacturer', 0, 
	'This is a highly detailed non-flying paper airplane designed for display.');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papwwi', 'en', 'Technical Details', 0, 
	'<ul><li><b>Wingspan</b>: 14"</li></ul>');
INSERT INTO [dbo].[Products] (
	[SKU], [DeliveryMethodID], [ProductName], [BasePrice], [WeightInPounds],
	[DateAvailable], [InventoryStatusID], [EstimatedDelivery], [AllowPreOrder], [AmountOnHand],
	[DefaultImageFile], [IsTaxable], [AllowBackOrder],
	[Blurb]) VALUES
	('papcce', 1, 'Contoso Cloud Explorer', 50, 1.0000,
	'2010-02-01 00:00:00.000', 2, '2-3 Weeks', 1, 10,
	'cce', 1, 1,
	'The perfect start plane');
INSERT INTO [dbo].[Categories_Products] ([CategoryCode], [SKU]) VALUES ('paper', 'papcce');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papcce', 'en', 'Summary', 0, 
	'This paper airplane is the perfect starter kit for any aspiring Tailspin Toys pilot (or mechanic).');
INSERT INTO [dbo].[ProductDescriptors] ([SKU], [LanguageCode], [Title], [IsDefault], [Body]) VALUES
	('papcce', 'en', 'Technical Details', 0, 
	'<ul><li><b>Wingspan</b>: 6"</li><li><b>Special Feature</b>: World of paper and model airplanes book</li></ul>');


INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('modnwt', 'papwwi');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('papwwi', 'modnwt');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('papwwi', 'papcce');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('papcce', 'papwwi');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('modfcf', 'modtrr');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('modfcf', 'papwts');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('modtrr', 'modfcf');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('modtrr', 'papwts');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('papwts', 'modfcf');
INSERT INTO [dbo].[Products_Related] ([SKU], [RelatedSKU]) VALUES ('papwts', 'modtrr');