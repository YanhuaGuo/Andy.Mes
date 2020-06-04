using System;

namespace Andy.Mes.Core
{
    public class Result
    {
        public bool IsSuss { get; set; }

        public string Message { get; set; }


        public static Result CreateResult(bool succ, string message)
        {
            return  new Result() { IsSuss = succ, Message = message };
        }
    }
}
