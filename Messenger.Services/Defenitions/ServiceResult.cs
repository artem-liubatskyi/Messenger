namespace Messenger.Services.Defenitions
{
    public class ServiceResult<TResult>
    {
        public TResult Result { get; set; }
        public bool IsSuccessed { get; set; }
        public string ErrorMessage { get; set; }
    }
}
