/*
Ejercicio 6 – Consultas MySQL
Consultas solicitadas: 
1. Obtener el nombre y precio de todos los productos cuyo stock sea mayor a 10, ordenados de mayor a menor precio. 
2. Obtener el total vendido por producto (sumar cantidad en la tabla ventas) y mostrar solo aquellos productos que hayan vendido más de 3 unidades.
*/
SELECT 
	Nombre, 
	Precio 
FROM 
	Productos
WHERE
	Stock > 2
ORDER BY 
	Precio ASC
	
	
SELECT 
	p.Id,
	p.Nombre, 
	SUM(v.Cantidad) AS TotalVendido
FROM 
	Productos p
JOIN 
	Ventas v ON p.Id = v.ProductoId
GROUP BY 
	p.Id, p.Nombre
HAVING 
	SUM(v.Cantidad) > 3
	
