﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;


namespace OtripleS.Web.Api.Models.Users.Exceptions
{
    public class FailedUserServiceException : Exception
    {
        public FailedUserServiceException(Exception innerException)
            : base(message: "Failed user service error occurred.", innerException)
        { }
    }
}
