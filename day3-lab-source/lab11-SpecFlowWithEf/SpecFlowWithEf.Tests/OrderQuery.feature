Feature: OrderQuery


Scenario: 依據姓名、訂單日期起、訂單日期迄條件，查出顧客的訂單
	Given 查詢條件為
	| CustomerId | OrderDateStart | OrderDateEnd |
	| Joey       | 2014-07-03     | 2014-07-07   |
	And 預計Customers資料應有
	| CustomerID | CompanyName |
	| Joey       | SkillTree   |
	And 預計Orders資料應有
	| CustomerID | OrderDate  | ShipCity |
	| Joey       | 2014-07-02 | Taipei   |
	| Joey       | 2014-07-03 | Taipei   |
	| Joey       | 2014-07-04 | Changhua |
	| Joey       | 2014-07-05 | Changhua |
	| Joey       | 2014-07-08 | Changhua |
	When 呼叫Query方法
	Then 查詢結果應為
	| CustomerID | OrderDate  | ShipCity |
	| Joey       | 2014-07-03 | Taipei   |
	| Joey       | 2014-07-04 | Changhua |
	| Joey       | 2014-07-05 | Changhua |

#Scenario: 依據姓名、訂單日期起的條件，查出顧客的訂單
#	Given 查詢條件為
#	| CustomerId | OrderDateStart | OrderDateEnd |
#	| Joey       | 2014-07-03     |              |
#	And 預計Customers資料應有
#	| CustomerID | CompanyName |
#	| Joey       | SkillTree   |
#	And 預計Orders資料應有
#	| CustomerID | OrderDate  | ShipCity |
#	| Joey       | 2014-07-02 | Taipei   |
#	| Joey       | 2014-07-03 | Taipei   |
#	| Joey       | 2014-07-04 | Changhua |
#	| Joey       | 2014-07-05 | Changhua |
#	| Joey       | 2014-07-08 | Changhua |
#	When 呼叫Query方法
#	Then 查詢結果應為
#	| CustomerID | OrderDate  | ShipCity |
#	| Joey       | 2014-07-03 | Taipei   |
#	| Joey       | 2014-07-04 | Changhua |
#	| Joey       | 2014-07-05 | Changhua |
#	| Joey       | 2014-07-08 | Changhua |
#
#Scenario: 依據姓名、訂單日期迄的條件，查出顧客的訂單
#	Given 查詢條件為
#	| CustomerId | OrderDateStart | OrderDateEnd |
#	| Joey       |                | 2014-07-04   |
#	And 預計Customers資料應有
#	| CustomerID | CompanyName |
#	| Joey       | SkillTree   |
#	And 預計Orders資料應有
#	| CustomerID | OrderDate  | ShipCity |
#	| Joey       | 2014-07-02 | Taipei   |
#	| Joey       | 2014-07-03 | Taipei   |
#	| Joey       | 2014-07-04 | Changhua |
#	| Joey       | 2014-07-05 | Changhua |
#	| Joey       | 2014-07-08 | Changhua |
#	When 呼叫Query方法
#	Then 查詢結果應為
#	| CustomerID | OrderDate  | ShipCity |
#	| Joey       | 2014-07-02 | Taipei   |
#	| Joey       | 2014-07-03 | Taipei   |
#	| Joey       | 2014-07-04 | Changhua |