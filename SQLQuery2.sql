CREATE PROCEDURE GetAllInvoices
AS
BEGIN
    SELECT
        Id,
        ProductName,
        Price
    FROM Invoice;
END;