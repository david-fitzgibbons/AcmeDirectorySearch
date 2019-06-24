namespace AcmeTests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public static class HelperFunctions
    {
        /// <summary>
        /// Running Validation on the Models utilizing their Annotations
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(object obj)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext vc = new ValidationContext(obj);
            return Validator.TryValidateObject(obj, vc, results, true);
        }

    }
}
