using AutoMapper;
using Basket.API.ProtoService;
using Grpc.Net.Client;
using Polly;
using UserBff.Dtos;

namespace UserBff.InterServiceCommunication.SyncDataClient
{
    public class GrpcBasketClient : IBasketClient
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly ILogger<GrpcCatalogBrandClient> logger;

        public GrpcBasketClient(
            IMapper mapper,
            IConfiguration configuration,
            ILogger<GrpcCatalogBrandClient> logger
            )
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task<bool> DeleteBasket(int userId)
        {
            var status = false;

            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, retryAttempt =>
                {
                    logger.LogWarning($"=======> Trying to Get Cart from Basket Service - Request Retry: {retryAttempt}");
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                });

            var channel = GrpcChannel.ForAddress(configuration["GrpcClient:BasketService"]);
            var client = new GrpcBasketProvider.GrpcBasketProviderClient(channel);

            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    var request = new GrpcDeleteBasketRequest { UserId = userId};
                    var cartResponse = await client.GrpcDeleteBasketAsync(request);
                    status = cartResponse.Response;

                });
            }
            catch (Exception ex)
            {
                logger.LogError($" =======> Could not Cart from Basket", ex.Message);
            }

            return status;
        }

        public async Task<ShoppingCartDto> GetBasket(int userId)
        {
            var cart = new ShoppingCartDto();

            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, retryAttempt =>
                {
                    logger.LogWarning($"=======> Trying to Get Cart from Basket Service - Request Retry: {retryAttempt}");
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                });

            var channel = GrpcChannel.ForAddress(configuration["GrpcClient:BasketService"]);
            var client = new GrpcBasketProvider.GrpcBasketProviderClient(channel);

            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    var request = new GrpcGetBasketRequest { UserId = userId };
                    var cartResponse = await client.GrpcGetBasketAsync(request);
                    cart = mapper.Map<ShoppingCartDto>(cartResponse);
                    //var items = mapper.Map<List<ShoppingCartItemDto>>(cartResponse.Items);
                    //items.ForEach(x => cart.Items.Add(x));

                });
            }
            catch (Exception ex)
            {
                logger.LogError($" =======> Could not Cart from Basket", ex.Message);
            }

            return cart;
        }

        public async Task<bool> UpdateBasket(ShoppingCartDto cart)
        {
            var status = false;

            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, retryAttempt =>
                {
                    logger.LogWarning($"=======> Trying to Get Cart from Basket Service - Request Retry: {retryAttempt}");
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                });

            var channel = GrpcChannel.ForAddress(configuration["GrpcClient:BasketService"]);
            var client = new GrpcBasketProvider.GrpcBasketProviderClient(channel);

            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    var grpcCart = mapper.Map<GrpcShoppingCart>(cart);
                    var cartResponse = await client.GrpcUpdateBasketAsync(grpcCart);
                    status = cartResponse.Response;

                });
            }
            catch (Exception ex)
            {
                logger.LogError($" =======> Could not Cart from Basket", ex.Message);
            }

            return status;
        }
    }
}
