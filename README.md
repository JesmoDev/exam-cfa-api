# exam-cfa-api
An Api using ASP .NET Core and Entity Framework

# API-Endpoints
endpoint: `api/`

## Products
endpoint: `api/products`

### Get All Products
endpoint: GET `api/products`

### Get Product
endpoint: GET `api/products/:id`

### Create Product
endpoint: POST `api/products`

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

### Update Product
endpoint: PUT `api/products/:id`

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
endpoint: DELETE `api/products/:id`

