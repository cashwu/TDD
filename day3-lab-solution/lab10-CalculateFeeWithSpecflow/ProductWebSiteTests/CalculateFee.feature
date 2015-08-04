Feature: CalculateFee
	In order to 節省計算運費的時間
	As a PM
	I want to 依據商品資訊跟貨運商，算出對應運費

Scenario Outline: 依據商品資訊，算出每一間貨運商需付出的運費
	Given 在商品頁面
	And 商品名稱輸入 book
	And 重量輸入 10
	And 長輸入 30
	And 寬輸入 20
	And 高輸入 10
	And 物流商選擇 <shipper>
	When 按下計算運費的按鈕
	Then 物流商名稱應為 <shipperName>
	And 運費結果應為 <fee>
	Examples: 
	| shipper | shipperName | fee    |
	| 黑貓      | 黑貓          | 200    |
	| 新竹貨運    | 新竹貨運        | 254.16 |
	| 郵局      | 郵局          | 180    |
