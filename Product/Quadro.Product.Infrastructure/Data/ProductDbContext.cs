namespace Quadro.Product.Infrastructure.Data;

using System.Text.Json;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Quadro.Product.Domain;
public class ProductDbContext
{

    private readonly IAmazonDynamoDB _amazonDynamoDB;
    public ProductDbContext(IAmazonDynamoDB amazonDynamoDB)
    {
        _amazonDynamoDB = amazonDynamoDB;
    }

    private async Task<bool> PutItemAsync(Product product, CancellationToken cancellationToken = default)
    {

        var productData = new ProductData
        {
            Id = product.Id.ToString(),
            Name = product.Name,
            Category = product.Category,
            Description = product.Description ,
            Price = product.UnitPrice!.Amount,
            CurrencyCode = product.UnitPrice.Currency.Code
        };

        var json = JsonSerializer.Serialize(productData);
        var itemAsDocument = Document.FromJson(json);
        var itemAsAttributes = itemAsDocument.ToAttributeMap();

        var request = new PutItemRequest
        {
            TableName = "products",
            Item = itemAsAttributes
        };

        var response = await _amazonDynamoDB.PutItemAsync(request, cancellationToken);
        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
    }

    public Task<bool> Create(Product product, CancellationToken cancellationToken = default) => PutItemAsync(product, cancellationToken);

    public Task<bool> Update(Product product, CancellationToken cancellationToken = default) => PutItemAsync(product, cancellationToken);


    public async Task<bool> Delete(Guid Id, CancellationToken cancellationToken = default)
    {
        var request = new DeleteItemRequest
        {
            TableName = "products",
            Key = new Dictionary<string, AttributeValue>
            {
              {"pk",new AttributeValue{S=Id.ToString()}},
              {"sk",new AttributeValue{S=Id.ToString()}},
            }
        };

        var response = await _amazonDynamoDB.DeleteItemAsync(request, cancellationToken);
        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
    }

    public async Task<Product> GetById(Guid Id, CancellationToken cancellationToken = default)
    {
        var request = new GetItemRequest
        {
            TableName = "products",
            Key = new Dictionary<string, AttributeValue>
            {
              {"pk",new AttributeValue{S=Id.ToString()}},
              {"sk",new AttributeValue{S=Id.ToString()}},
            }

        };

        GetItemResponse response = await _amazonDynamoDB.GetItemAsync(request, cancellationToken);
        return ConvertToProduct(response.Item);
    }

    public async Task<List<Product>> ListAll(CancellationToken cancellationToken = default)
    {
        var request = new ScanRequest
        {
            TableName = "products"
        };

        var response = await _amazonDynamoDB.ScanAsync(request, cancellationToken);
        return response.Items.Select(item => ConvertToProduct(item)).ToList();
    }

    private Product ConvertToProduct(Dictionary<string, AttributeValue> kvp)
    {
        var json = Document.FromAttributeMap(kvp);
        var productData = JsonSerializer.Deserialize<ProductData>(json);
        return new Product
        {
            Id = Guid.Parse(productData!.Id),
            Name = productData.Name!,
            Category = productData.Category!,
            Description = productData.Description,
            UnitPrice = Money.Of(productData.Price, productData.CurrencyCode)
        };
    }

}
