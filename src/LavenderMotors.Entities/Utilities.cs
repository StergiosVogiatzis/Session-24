using System.Runtime.CompilerServices;

namespace LavenderMotors.Entities;

internal static class Utilities
{
    public static Exception CreateUnboundValueAccessException([CallerMemberName] string paramName = null!)
    {
        return new ArgumentException("The parameter is not bound to a value.", paramName);
    }
}
