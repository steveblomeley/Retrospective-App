using Prism.Navigation;

namespace Retrospective.Helpers
{
    public static class NavigationParametersExtensions
    {
        public static bool TryGetParam<T>(this NavigationParameters parameters, string paramKey, out T paramValue)
        {
            if (parameters.TryGetValue<object>(paramKey, out var paramObject))
            {
                if (paramObject is T paramCastToType)
                {
                    paramValue = paramCastToType;
                    return true;
                }
            }

            paramValue = default(T);
            return false;
        }
    }
}