
## Kullanılan Teknolojiler

**API:** .NET 5.0
**UI:** SwaggerUI
**Database:** Entityframeworkcore Inmemory
**Log:** NLog
**DesignPatters:** Domain Driven Design Patterns, Generic Repository Pattern




  
## Bilgisayarınızda Çalıştırın

Projeyi klonlayın

```bash
  git clone https://github.com/aliozdemir044/LogiwaCodeReviewProject.git
```

Proje dizinine gidin

```bash
  cd \LogiwaCodeReviewProject
```


 Bilgisayarınızda Çalıştırın

```bash
  dotnet run
```

  
## API Kullanımı

#### Tüm ürünleri getir

```http
  GET /api/product/get_all_products
```


#### Ürün oluştur.

```http
  POST /api/product/create_product
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| CreateModel      | `object` | **Gerekli**. { "title": "string", "description": "string", "categoryId": int,"stockQuantity": int,"isActive": bool}|

#### ID'ye göre ürün getirir.

```http
  GET /api/product/get_product_by_id
```

#### Ürün günceller.
```http
  POST /api/product/Update_product
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| Update      | `object` | **Gerekli**. { "Id":"int","title": "string", "description": "string", "categoryId": int,"stockQuantity": int,"isActive": bool}|

  #### Title, Description veya Kategori adına göre ürün getirir.

```http
  POST /api/product/search_product
```
| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| searchText      | `string` | **Gerekli**. Aranacak değer|

  #### Stok miktarının aralığına göre ürün getirir.

```http
  POST /api/product/search_product_by_stock_quantity_range
```
| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| minValue      | `int` | **Gerekli**. Aranacak minimum değer|
| maxValue      | `int` | **Gerekli**. Aranacak maximum değer|

 #### Ürün siler.

```http
  POST /api/product/delete_product
```
| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| id      | `int` | **Gerekli**. Aranacak minimum değer|


## Yazarlar ve Teşekkür

- [Ali Özdemir](https://www.github.com/aliozdemir044) tasarım ve geliştirme için.

  
