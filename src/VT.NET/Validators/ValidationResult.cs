using System;
using System.Collections.Generic;
using System.Linq;

namespace VT.NET.Validators
{
    internal class ValidationResult
    {
        public ValidationResult()
        {
            Exceptions = new List<Exception>();
        }

        public ValidationResult(Exception exception)
        {
            Exceptions = exception != null ? new List<Exception>() { exception } : new List<Exception>();
        }

        public ValidationResult(IEnumerable<Exception> exceptions)
        {
            Exceptions = exceptions ?? new List<Exception>();
        }

        public bool IsValid => Exceptions.Count() == 0;

        public IEnumerable<string> Errors => Exceptions.Select(e => e.Message);

        public IEnumerable<Exception> Exceptions { get; }

        public void ThrowIfAny()
        {
            if (IsValid)
            {
                return;
            }

            if (Errors.Count() == 1) 
            {
                throw Exceptions.First();
            }

            throw new AggregateException(Exceptions);
        }
    }
}
