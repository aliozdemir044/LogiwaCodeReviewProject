using Logiwa.Core.Interfaces;
using System;

namespace Logiwa.Core.Logging
{
    public class NLogManager : ILogManager
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void Debug(string message, string tags = "")
        {
            logger.Debug($"message: {message}, tags: {tags}");
        }
        public void Error(string message, Exception exception, string tags = "")
        {
            logger.Error(exception, $"message: {message}, tags: {tags}");
        }
        public void Fatal(string message, Exception exception, string tags = "")
        {
            logger.Fatal(exception, $"message: {message}, tags: {tags}");
        }
        public void Info(string message, string tags = "")
        {
            logger.Info($"message: {message}, tags: {tags}");
        }
        public void Trace(string message, string tags = "")
        {
            logger.Trace($"message: {message}, tags: {tags}");
        }
        public void Warning(string message, string tags = "")
        {
            logger.Warn($"message: {message}, tags: {tags}");
        }
    }
}
