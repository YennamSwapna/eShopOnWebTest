Feature: CreateCatalogItem

Scenario: Add a Catalog Item	
	When I send Create Catalog Item Request
	Then Validate Catalog is created