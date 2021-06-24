Feature: CreateCatalogItem

Scenario: Add a Catalog Item
	Given I input CatalogBrandId 1
	And I input CatalogTypeId 2
	And I input Description "test"
	And I input Name "testing"
	And I input PictureUri "test 123"
	And I input Price 1.23m
	When I send Create Catalog Item Request
	Then Validate Catalog is created