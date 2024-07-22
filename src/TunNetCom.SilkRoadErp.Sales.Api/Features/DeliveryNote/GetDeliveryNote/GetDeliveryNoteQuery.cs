﻿namespace TunNetCom.SilkRoadErp.Sales.Api.Features.DeliveryNote.GetDeliveryNote;

public record GetDeliveryNoteQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword) : IRequest<PagedList<DeliveryNoteResponse>>;

