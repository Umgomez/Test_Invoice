SELECT c.Customer_ID 
	, c.CustomerName 
	, c.[Address] 
	, ct.CustomerTypeDisplay 
	, cs.CustomerStatusDisplay 
FROM Customer c
	INNER JOIN CustomerStatus cs ON cs.CustomerStatus_ID = c.CustomerStatus_ID 
		INNER JOIN CustomerType ct ON ct.CustomerType_ID = c.CustomerType_ID 
ORDER BY c.CustomerName