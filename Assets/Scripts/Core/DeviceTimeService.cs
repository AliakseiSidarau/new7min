using System;

namespace Core
{
    public class DeviceTimeService: ITimeService
    {
        public long Now => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}