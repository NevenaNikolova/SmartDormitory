﻿namespace DormitorySystem.Common.Abstractions
{
    public interface IApiProvider
    {
        string ReturnResponse(string url, string header);
    }
}