# exam-cfa-api
An Api using ASP .NET Core and Entity Framework

# API-Endpoints 

## Base Url: https://exam-cfa-api.herokuapp.com

# Products `/products`

### Get All Products
endpoint: GET `/products`  
This enpoint includes optional filter queries:  
category, type, brand, colors, sizes.  
Example: `/products?category=1&type=1&brand=1&color=1&size=1`  
Colors and sizes are arrays and can therefor be used multiple times in the query to filter for multiple colors or sizes:  
Example: `/products?colors=1&colors=2&sizes=1&sizes=2&sizes=3`  
This will return all products that contains at least one of the colors and one of the sizes in the query.

### Get Product
endpoint: GET `/products/:id`

### Create Product
endpoint: POST `/products`

```cs
{
  "name": string,
  "description": string,
  "price": int,
  "images": string[],
  "category": int,
  "type": int,
  "brand": int,
  "colors": int[],
  "sizes": int[]
}
```
Category, type and brand are id references  
Colors and sizes are arrays of id references

### Update Product
endpoint: PUT `/products/:id`

```cs
{
  "name": string,
  "description": string,
  "price": int,
  "images": string[],
  "category": int,
  "type": int,
  "brand": int,
  "colors": int[],
  "sizes": int[]
}
```
Category, type and brand are id references  
Colors and sizes are arrays of id references

You only need to provide the fields that you want to update. Example:

```json
{
  "name": "Cool T-shirt",
  "description": "The description of the very cool t-shirt",
  "price": 159,
  "sizes": [1, 3, 4]
}
```
### DELETE Product
endpoint: DELETE `/products/:id`

<br/>

# Suppliers `/suppliers`

### Get All
endpoint: GET `/suppliers`

### Get
endpoint: GET `/suppliers/:id`  
This endpoint has an optional parameter to include products in the response: `includeProducts`  
example: 
`/suppliers/1?includeProducts=true`

### Create
endpoint: GET `/suppliers`
```cs
{
  "name": string
  "address": string
  "email": string
}
```
### Update
endpoint: GET `/suppliers/:id`
```cs
{
  "name": string
  "address": string
  "email": string
}
```
You only need to provide the fields that you want to update. Example:
```cs
{
  "name": "name updated"
}
```
### Delete
endpoint: GET `/suppliers/:id`

<br/>

# Categories, Types & Brands
endpoint Categories: `/categories`  
endpoint Types: `/types`   
endpoint Brands: `/brands`

Everything here is the same for all, except the endpoints. In the examples we will use: `enpoint`.

### Get All
endpoint: GET `/endpoint`

### Get
endpoint: GET `/endpoint/:id`

### Create
endpoint: GET `/endpoint`
```cs
{
  "name": string
  "description": string
}
```
### Update
endpoint: GET `/endpoint/:id`
```cs
{
  "name": string
  "description": string
}
```
You only need to provide the fields that you want to update. Example:

```json
{
  "name": "Updated Name",
}
```
### Delete
endpoint: GET `/endpoint/:id`

</br>

# Colors & Sizes
endpoint Colors: `/colors`  
endpoint Sizes: `/sizes`

Everything here is the same for both, except the endpoints. In the examples we will use: `enpoint`.

### Get All
endpoint: GET `/endpoint`

### Get
endpoint: GET `/endpoint/:id`

### Create
endpoint: GET `/endpoint`
```cs
{
  "name": string
}
```
### Update
endpoint: GET `/endpoint/:id`
```cs
{
  "name": string
}
```
### Delete
endpoint: GET `/endpoint/:id`