﻿namespace LoadingContainers.Exceptions;
using System;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
        
    }
}