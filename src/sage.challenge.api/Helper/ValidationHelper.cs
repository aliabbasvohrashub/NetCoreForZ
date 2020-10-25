using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace sage.challenge.api.Helper
{
    public static class ValidationHelper
    {
        public static string GetAllValidationErrors(this ModelStateDictionary modelState)
        {
            string errors = string.Empty;
            foreach (var item in modelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    errors += err.ErrorMessage.ToString();
                }
            }
            return errors;
        }
    }
}
