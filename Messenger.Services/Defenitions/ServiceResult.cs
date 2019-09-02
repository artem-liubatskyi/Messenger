namespace Messenger.Services.Defenitions
{
    public class ServiceResult<TResult>
    {
        public ServiceResult(TResult result)
        {
            Result = result;
            IsSuccessed = true;
        }

        public ServiceResult(TResult result, string errorMessage) : this(result)
        {
            IsSuccessed = false;
            ErrorMessage = errorMessage;
        }

        public TResult Result { get; set; }
        public bool IsSuccessed { get; set; }
        public string ErrorMessage { get; set; }
    }
}
