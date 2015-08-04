Feature: MyCalculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add two numbers
	Given 在第一個輸入項輸入 50
	And 在第二個輸入項輸入 70
	When 按下 Add 按鈕
	Then 螢幕上的結果應為 120