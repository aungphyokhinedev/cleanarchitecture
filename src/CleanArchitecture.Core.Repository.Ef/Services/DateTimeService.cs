using CleanArchitecture.Core.Service;

namespace CleanArchitecture.Core.Repository.Ef
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeOffset Now => DateTime.Now.ToUniversalTime();
    }
}