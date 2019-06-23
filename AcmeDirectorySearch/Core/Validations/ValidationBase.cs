namespace AcmeDirectorySearch.Core.Validations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Creates a standard validation layer for checking the Domain Models
    /// and their validation attributes before sending to the persistence 
    /// layers
    /// </summary>
    public abstract class ValidationBase
    {
        internal void Validate()
        {
            ValidationContext vc = new ValidationContext(this);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, vc, results, true);

            if (!isValid)
            {
                throw new InvalidOperationException(string.Concat(results.Select(vr => vr.ErrorMessage + "; ")));
            }
        }

    }
}
