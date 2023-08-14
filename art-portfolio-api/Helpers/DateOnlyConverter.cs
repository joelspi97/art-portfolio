using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace art_portfolio_api.Helpers
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base( dateOnly => 
                        dateOnly.ToDateTime(TimeOnly.MinValue),
                        dateTime => DateOnly.FromDateTime(dateTime) ) { }
    }
}
