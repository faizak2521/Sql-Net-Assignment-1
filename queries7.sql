-- Assignment 7 - SalesComp (5 SELECT Queries)

-- 1. Invoices with customer names
SELECT I.INV_NUMBER, I.INV_DATE, C.CUST_LNAME, C.CUST_FNAME
FROM Invoice I
JOIN Customer C ON I.CUST_CODE = C.CUST_CODE;

-- 2. Products with vendor names
SELECT P.PROD_CODE, P.PROD_DESCRIPT, V.VEND_NAME
FROM Product P
LEFT JOIN Vendor V ON P.VEND_CODE = V.VEND_CODE;

-- 3. Line items with product info
SELECT L.INV_NUMBER, L.LINE_NUMBER, P.PROD_DESCRIPT, L.LINE_UNITS, L.LINE_PRICE
FROM Line L
JOIN Product P ON L.PROD_CODE = P.PROD_CODE;

-- 4. Full invoice breakdown (customer + products)
SELECT I.INV_NUMBER, C.CUST_LNAME, P.PROD_DESCRIPT, L.LINE_UNITS, L.LINE_PRICE
FROM Line L
JOIN Invoice I ON L.INV_NUMBER = I.INV_NUMBER
JOIN Customer C ON I.CUST_CODE = C.CUST_CODE
JOIN Product P ON L.PROD_CODE = P.PROD_CODE;

-- 5. Customers and their invoices (including those with none)
SELECT C.CUST_LNAME, C.CUST_FNAME, I.INV_NUMBER
FROM Customer C
LEFT JOIN Invoice I ON C.CUST_CODE = I.CUST_CODE;