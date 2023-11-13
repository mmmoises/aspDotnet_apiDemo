namespace apiweb.exception;


[Serializable]
public class LogicException : System.Exception
{
    public LogicException() { }
    public LogicException(string message) : base(message) { }
    public LogicException(string message, System.Exception inner) : base(message, inner) { }
    protected LogicException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}