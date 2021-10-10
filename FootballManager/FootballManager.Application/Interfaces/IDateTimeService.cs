using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
