﻿using TunNetCom.SilkRoadErp.Sales.Contracts.Providers;
namespace TunNetCom.SilkRoadErp.Sales.Api.Features.Providers.GetProviderById;

public class GetProviderByIdQueryHandler(SalesContext _context, ILogger<GetProviderByIdQueryHandler> _logger)
    : IRequestHandler<GetProviderByIdQuery, Result<ProviderResponse>>
{
    public async Task<Result<ProviderResponse>> Handle(GetProviderByIdQuery getProviderByIdQuery, CancellationToken cancellationToken)
    {
        _logger.LogFetchingEntityById("Provider", getProviderByIdQuery.Id);

        var provider = await _context.Fournisseur.FindAsync(getProviderByIdQuery.Id);
        if (provider is null)
        {
            _logger.LogEntityNotFound("Provider", getProviderByIdQuery.Id);
            return Result.Fail("provider_not_found");
        }

        _logger.LogEntityFetchedById("Provider", getProviderByIdQuery.Id);
        return provider.Adapt<ProviderResponse>();
    }
}