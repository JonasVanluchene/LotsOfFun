using LotsOfFun.Model;

namespace LotsOfFun.Ui.Mvc.Helper.Validate
{
    public static class Validator
    {
        public static bool TryCreateAddress(
            string? street,
            string? number,
            string? unit,
            string? postalCode,
            string? city,
            out Address? address)
        {
            bool isEmpty = string.IsNullOrWhiteSpace(street)
                           && string.IsNullOrWhiteSpace(number)
                           && string.IsNullOrWhiteSpace(postalCode)
                           && string.IsNullOrWhiteSpace(city);

            bool isFilled = !string.IsNullOrWhiteSpace(street)
                            && !string.IsNullOrWhiteSpace(number)
                            && !string.IsNullOrWhiteSpace(postalCode)
                            && !string.IsNullOrWhiteSpace(city);

            if (isEmpty)
            {
                address = null;
                return true; // Valid: address omitted
            }

            if (isFilled)
            {
                address = new Address
                {
                    Street = street,
                    Number = number,
                    UnitNumber = unit,
                    PostalCode = postalCode,
                    City = city
                };
                return true;
            }

            // Some fields filled, others missing – invalid
            address = null;
            return false;
        }
    }
}
