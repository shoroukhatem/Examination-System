namespace ExaminationSystem.Core.Bases
{
    public class ResponseHandler
    {

        public ResponseHandler()
        {

        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public Response<T> Success<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,
                Succeeded = true,
                Message = "Added Successfully"
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> Created<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,
                Succeeded = true

            };
        }
    }
}
