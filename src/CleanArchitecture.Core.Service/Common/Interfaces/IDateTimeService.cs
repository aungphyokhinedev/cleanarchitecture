namespace CleanArchitecture.Core.Service
{
    public interface IDateTimeService
    {
        DateTimeOffset Now { get; }
    }
}