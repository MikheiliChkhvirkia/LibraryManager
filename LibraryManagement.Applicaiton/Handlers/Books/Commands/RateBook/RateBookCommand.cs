using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.RateBook
{
    public class RateBookCommand : IRequest
    {
        public RateBookCommand(int id, int rating)
        {
            Id = id;
            Rating = IsValid(rating);
        }

        public int Id { get; set; }
        public int Rating { get; set; }

        private static int IsValid(int rating)
        {
            if (rating > 0 && rating < 11)
            {
                return rating;
            }
            throw new Exception("Invalid Rating it should be more than 0 and less than 11");
        }
    }
}
