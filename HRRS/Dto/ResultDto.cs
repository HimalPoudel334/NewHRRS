public class ResultDto<T> where T : class
{
    public ResultDto(bool isSuccess, T data = null, string errorMessage = null)
    {
        this.isSuccess = isSuccess;
        this.errorMessage = errorMessage;
        this.data = data;
    }

    public bool isSuccess { get; set; }
    public string errorMessage { get; }
    public T data { get; }
}