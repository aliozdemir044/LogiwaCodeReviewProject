using System;

namespace Logiwa.Core.Interfaces
{
    /// <summary>
    /// Tüm loglama işlemini gerçekleştirir. Kullanılacak sınıf containera ilgili katmanda register edilmiştir.
    /// Author : Ali Özdemir
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Bilgilendirme amaçlı log yazmak için kullanılır.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="tags">string</param>
        void Info(string message, string tags = "");

        /// <summary>
        /// Trace logging için kullanılır.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="tags">string</param>
        void Trace(string message, string tags = "");

        /// <summary>
        /// Debug seviyesindeki loglar için kullanılır.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="tags">string</param>
        void Debug(string message, string tags = "");

        /// <summary>
        /// Uyarı loglarını yazmak için kullanılır.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="tags">string</param>
        void Warning(string message, string tags = "");

        /// <summary>
        /// Hataları loglamak için kullanılır.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="exception">Exception</param>
        /// <param name="tags">string</param>
        void Error(string message, Exception exception, string tags = "");

        /// <summary>
        /// Mutlaka düzeltilmesi gereken hataları loglar.
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="exception">Exception</param>
        /// <param name="tags">string</param>
        void Fatal(string message, Exception exception, string tags = "");
    }
}