public class ResultDto<T> where T : class
{
    public ResultDto(bool isSuccess, T data = null, string errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Data = data;
    }

    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; }
    public T Data { get; }
}