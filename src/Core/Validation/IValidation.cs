namespace Core.Validation
{
    public interface IValidation<T>
    {
        void Validate(T model);
    }
}
