    namespace KamaCake.Application.Wrappers
    {
        public class ServiceResponse<T>
        {
            public T Value { get; set; }
        public bool isSuccess { get; set; } = true;   // əməliyyat uğurlu olub-olmadığını göstərir
        public string Message { get; set; } = string.Empty;
        public ServiceResponse()
            {
            
            }
            public ServiceResponse(T value)
            {
                Value=value;
            }
        }
    }
