using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.Core.Types
{
    /// <summary>
    /// Contract katmanlardan mesaj dönerken kullanılır.
    /// </summary>
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Contract katmanlardan mesaj dönerken data iletilecekse kullanılır.
    /// </summary>
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }

}
