# exam-cfa-api
An Api using ASP .NET Core and Entity Framework

# API-Endpoints 

# Products
endpoint: `/products`

### Get All Products
endpoint: GET `/products`

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