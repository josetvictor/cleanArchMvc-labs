﻿namespace cleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidator : Exception
    {
        public DomainExceptionValidator(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidator(error);
        }
    }
}
