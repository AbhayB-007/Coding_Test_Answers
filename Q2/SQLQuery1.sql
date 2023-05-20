Create PROCEDURE GetJsonValues
AS
BEGIN
    DECLARE @json NVARCHAR(MAX) = '
    [
        {"userid":"1234", "result":"User is absent"},
        {"userid":"4567", "result":"User is Present"},
        {"userid":"7890", "result":"User is late"}
    ]';
    
    --Get result for userid = 7890
    SELECT JSON_VALUE(value, '$.result') as result
    FROM OPENJSON(@json)
    WHERE JSON_VALUE(value, '$.userid') = '7890';

    --Get userid for result = Present
    SELECT JSON_VALUE(value, '$.userid') as userid
    FROM OPENJSON(@json)
    WHERE JSON_VALUE(value, '$.result') = 'User is Present';
END;

EXEC GetJsonValues;
--drop procedure GetJsonValues

