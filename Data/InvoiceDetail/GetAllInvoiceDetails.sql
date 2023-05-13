DECLARE @VarCustomerID VARCHAR(100) = :CustomerID
SELECT id.InvoiceDetail_ID 
	, id.Qty 
	, id.Price 
	, id.TotalItbis 
	, id.SubTotal 
	, id.Total 
	, id.Customer_ID 
	, c.CustomerName
FROM InvoiceDetail id
	INNER JOIN Customer c ON c.Customer_ID = id.Customer_ID 
 WHERE (id.Customer_ID = @VarCustomerID OR ISNULL(@VarCustomerID, '') = '')
 ORDER BY c.CustomerName