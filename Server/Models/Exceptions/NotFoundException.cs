// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Server.Models.Doctor.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid userId, string actor)
            : base(message: $"Couldn't find {actor} with id: {userId}.") { }
    }
}
