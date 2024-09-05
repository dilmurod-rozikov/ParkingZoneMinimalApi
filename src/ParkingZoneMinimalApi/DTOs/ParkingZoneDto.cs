using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ParkingZoneMinimalApi.DTOs
{
    public class ParkingZoneDto : IParsable<ParkingZoneDto>
    {
        [Key]
        public int Id { get; init; }

        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        [MinLength(10)]
        public string Address { get; set; }

        public DateOnly CreatedDate { get; init; } = new DateOnly();

        public static ParkingZoneDto Parse(string s, IFormatProvider? provider)
        {
            try
            {
                return JsonSerializer.Deserialize<ParkingZoneDto>(s, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Invalid JSON format.", nameof(s), ex);
            }
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ParkingZoneDto result)
        {
            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }
    }
}
