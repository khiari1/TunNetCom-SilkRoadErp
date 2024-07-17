﻿namespace TunNetCom.SilkRoadErp.Sales.Api.Features.Customers.DeleteCustomer;

public class DeleteCustomerCommandHandler(SalesContext _context,
    ILogger<DeleteCustomerCommandHandler> _logger) : IRequestHandler<DeleteCustomerCommand, Result>
{
    public async Task<Result> Handle(DeleteCustomerCommand deleteCustomerCommand, CancellationToken cancellationToken)
    {
        _logger.LogEntityDeletionAttempt(
            "Customer",
            deleteCustomerCommand.Id);

        var client = await _context.Client.FindAsync(deleteCustomerCommand.Id);

        if (client is null)
        {
            _logger.LogEntityNotFound("Customer", deleteCustomerCommand.Id);

            return Result.Fail("client_not_found");
        }

        _context.Client.Remove(client);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogEntityDeleted(
            "Customer",
            deleteCustomerCommand.Id);

        return Result.Ok();
    }
}
