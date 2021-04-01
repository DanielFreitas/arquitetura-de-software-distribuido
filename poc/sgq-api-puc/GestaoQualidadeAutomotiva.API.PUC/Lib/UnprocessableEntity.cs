using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GestaoQualidadeAutomotiva.API.PUC.Lib
{
    public class UnprocessableEntity : ObjectResult
    {
        public UnprocessableEntity(object value)
           : base(value)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public UnprocessableEntity(ModelStateDictionary modelState)
            : this(new SerializableError(modelState))
        { }
    }
}