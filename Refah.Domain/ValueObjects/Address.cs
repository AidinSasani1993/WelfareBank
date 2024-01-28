using Refah.Domain.Contract;

namespace Refah.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        #region [-ctors-]
        public Address()
        {

        }

        public Address(string street,
                       string city,
                       string state,
                       string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }
        #endregion

        #region [-props-]
        public String Street { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; } 
        #endregion
    }
}
