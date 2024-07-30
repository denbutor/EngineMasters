namespace EngineMasters_BackEnd.Data.Interfaces;

public interface IBaseResponse<T>
{
    T Data { get; set; }
}