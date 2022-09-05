using RectangleApp.Interfaces;

namespace RectangleApp.Services
{
    public class ValidatorService : IValidatorService
    {
        #region Implement Interface
        public bool IsObjectValid(object obj)
        {
            return obj != null;
        }
        #endregion
    }
}
