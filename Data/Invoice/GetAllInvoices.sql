DECLARE @VarCustomerID VARCHAR(100) = :CustomerID
SELECT i.Invoice_ID
	, i.TotalItbis 
	, i.SubTotal 
	, i.Total 
	, i.Customer_ID 
	, c.CustomerName
	, i.InvoiceDetail_ID 
FROM Invoice i
	INNER JOIN Customer c ON c.Customer_ID = i.Customer_ID 
 WHERE (i.Customer_ID = @VarCustomerID OR ISNULL(@VarCustomerID, '') = '')
 ORDER BY c.CustomerName