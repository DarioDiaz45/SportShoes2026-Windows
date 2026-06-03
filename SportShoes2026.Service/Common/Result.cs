namespace SportShoes2026.Service.Common
{
    public class Result
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;
        public bool IsConcurrencyConflict { get; set; }

        public List<string> Errors { get; }

        private Result(bool success, List<string> errors, bool isConcurrencyConflict=false)
        {
            IsSuccess = success;
            Errors = errors;
            IsConcurrencyConflict = isConcurrencyConflict;
        }

        public static Result Success()
        {
            return new Result(true, new List<string>());
        }

        public static Result Failure(string error)
        {
            return new Result(false, new List<string> { error });
        }

        public static Result Failure(List<string> errors)
        {
            return new Result(false, errors);
        }

        public static Result ConcurrencyFailure(string error)
        {
            return new Result(false, new List<string> { error }, true);
        }
    }
}

