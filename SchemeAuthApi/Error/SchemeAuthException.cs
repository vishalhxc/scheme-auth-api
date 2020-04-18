using System;
using System.Collections.Generic;

namespace SchemeAuthApi.Error
{
    public class SchemeAuthException : Exception
    {
        private static List<string> _messages;
        public List<string> Messages { get { return _messages; } }
        public SchemeAuthException(List<string> messages)
            : base(string.Join(";", messages))
        {
            _messages = messages;
        }
        public SchemeAuthException(List<string> messages, Exception exception)
            : base(string.Join(";", messages, exception)) { }
    }

    public class ConflictException : SchemeAuthException
    {
        public ConflictException(List<string> messages)
            : base(messages) { }
        public ConflictException(List<string> messages, Exception exeption)
            : base(messages, exeption) { }
    }

}