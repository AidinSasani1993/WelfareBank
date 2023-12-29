﻿namespace Refah.Application.Contract.Operation
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult Succedded(string message)
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }

        public OperationResult NotFound(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
