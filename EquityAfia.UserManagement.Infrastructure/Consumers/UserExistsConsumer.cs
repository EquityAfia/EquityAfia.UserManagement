using EquityAfia.SharedContracts;
using MassTransit;

namespace EquityAfia.UserManagement.Infrastructure.Consumers
{
    public class UserExistsConsumer : IConsumer<UserExists>
    {
        public async Task Consume(ConsumeContext<UserExists> context)
        {

            Console.WriteLine($"Checking if user exist ...");

            await Task.Delay(1000); 

            Console.WriteLine("User found successfully.");
        }
    }
}
