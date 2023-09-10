namespace TransportForLondon.RoadStatusChecker.Helper
{
    using System.ComponentModel.DataAnnotations;

    public class ValidationHelper
    {
        public static bool ValidateObject<T>(T obj)
        {
            var context = new ValidationContext(obj, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, validationResults, true);

            if (!isValid)
            {
                DisplayValidationErrors(validationResults);
            }

            return isValid;
        }

        private static void DisplayValidationErrors(List<ValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }
    }
}